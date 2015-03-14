using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;
namespace StateMachine.Action{
	[Info (category = "GameObject",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class GetProperty : GameObjectAction {
		[ComponentInfo]
		public string component;
		[ReflectionInfo("component", ReflectionType.FieldsAndProperties,false)]
		public string property;

		[ReflectionReturnInfo("component","property",typeof(int))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Int field to store.")]
		public IntParameter storeInt;

		[ReflectionReturnInfo("component","property",typeof(float))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Float field to store.")]
		public FloatParameter storeFloat;

		[ReflectionReturnInfo("component","property",typeof(string))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("String field to store.")]
		public StringParameter storeString;

		[ReflectionReturnInfo("component","property",typeof(bool))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Bool field to store.")]
		public BoolParameter storeBool;

		[ReflectionReturnInfo("component","property",typeof(UnityEngine.Object))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Object field to store.")]
		public ObjectParameter storeObj;

		[ReflectionReturnInfo("component","property",typeof(Color))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Color field to store.")]
		public ColorParameter storeColor;

		[ReflectionReturnInfo("component","property",typeof(Vector3))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Vector3 field to store.")]
		public Vector3Parameter storeVector3;

		[ReflectionReturnInfo("component","property",typeof(List<>))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("List field to store.")]
		public ListParameter storeList;

		[ReflectionReturnInfo("component","property",typeof(object))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("object field to store.")]
		public SystemObjectParameter storeSystemObject;


		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			if (string.IsNullOrEmpty (component)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the component parameter is empty. Action disabled!");
				return;
			}

			if (string.IsNullOrEmpty (property)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the property parameter is empty. Action disabled!");
				return;
			}
			DoGetProperty ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoGetProperty ();
		}
	
		private void DoGetProperty(){
			Type componentType=UnityTools.GetType(component);
			if(componentType == null){
				componentType=UnityTools.GetType("UnityEngine."+component);
			}
			if (componentType != null && gameObject.Value != null && ((GameObject)gameObject.Value).GetComponent (componentType) != null) {
				
				Component behaviour = ((GameObject)gameObject.Value).GetComponent (componentType);
				FieldInfo info = behaviour.GetType ().GetField (property);
				if (info != null) {
					if (info.FieldType == typeof(int) || info.FieldType==typeof(KeyCode)) {
						storeInt.Value = (int)info.GetValue (behaviour);
					} else if (info.FieldType == typeof(float)) {
						storeFloat.Value = (float)info.GetValue (behaviour);
					} else if (info.FieldType == typeof(bool)) {
						storeBool.Value = (bool)info.GetValue (behaviour);
					} else if (info.FieldType == typeof(string)) {
						storeString.Value = (string)info.GetValue (behaviour);
					} else if (info.FieldType == typeof(Color)) {
						storeColor.Value = (Color)info.GetValue (behaviour);
					} else if (info.FieldType == typeof(Vector3)) {
						storeVector3.Value = (Vector3)info.GetValue (behaviour);
					}else if (info.FieldType.IsGenericType && info.FieldType.GetGenericTypeDefinition() == typeof(List<>)) {
						storeList.Value = ((IList)info.GetValue (behaviour)).Cast<object>().ToList();
					}else if (info.FieldType == typeof(UnityEngine.Object) || info.FieldType.IsSubclassOf(typeof(UnityEngine.Object))) {
						storeObj.Value = (UnityEngine.Object)info.GetValue (behaviour);
					}

					storeSystemObject.Value= info.GetValue(behaviour);

				} else {

					PropertyInfo propertyInfo = behaviour.GetType ().GetProperty (property);
					if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType==typeof(KeyCode)) {
						storeInt.Value = (int)propertyInfo.GetValue (behaviour, null);
					} else if (propertyInfo.PropertyType == typeof(float)) {
						storeFloat.Value = (float)propertyInfo.GetValue (behaviour, null);
					} else if (propertyInfo.PropertyType == typeof(bool)) {
						storeBool.Value = (bool)propertyInfo.GetValue (behaviour, null);
					} else if (propertyInfo.PropertyType == typeof(string)) {
						storeString.Value = (string)propertyInfo.GetValue (behaviour, null);
					} else if (propertyInfo.PropertyType == typeof(Color)) {
						storeColor.Value = (Color)propertyInfo.GetValue (behaviour, null);
					} else if (propertyInfo.PropertyType == typeof(Vector3)) {
						storeVector3.Value = (Vector3)propertyInfo.GetValue (behaviour, null);
					}else if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>)) {
						storeList.Value = ((IList)info.GetValue (behaviour)).Cast<object>().ToList();
					}else if (propertyInfo.PropertyType == typeof(UnityEngine.Object) || propertyInfo.PropertyType.IsSubclassOf(typeof(UnityEngine.Object))) {
						storeObj.Value = (UnityEngine.Object)propertyInfo.GetValue (behaviour,null);
					}
					storeSystemObject.Value=propertyInfo.GetValue(behaviour,null);
				}
			} 
		}
	}
}