using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace StateMachine.Action{
	[Info (category = "GameObject",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class SetProperty : GameObjectAction {
		[ComponentInfo]
		public string component;
		[ReflectionInfo("component", ReflectionType.FieldsAndProperties,true)]
		public string property;

		[ReflectionReturnInfo("component","property",typeof(int))]
		[Tooltip("Int to set.")]
		public IntParameter setInt;

		[ReflectionReturnInfo("component","property",typeof(float))]
		[Tooltip("Float to set.")]
		public FloatParameter setFloat;

		[ReflectionReturnInfo("component","property",typeof(string))]
		[Tooltip("String to set")]
		public StringParameter setString;

		[ReflectionReturnInfo("component","property",typeof(bool))]
		[Tooltip("Bool to set.")]
		public BoolParameter setBool;

		[ReflectionReturnInfo("component","property",typeof(UnityEngine.Object))]
		[Tooltip("Object to set.")]
		public ObjectParameter setObj;

		[ReflectionReturnInfo("component","property",typeof(Color))]
		[Tooltip("Color to set.")]
		public ColorParameter setColor;

		[ReflectionReturnInfo("component","property",typeof(Vector3))]
		[Tooltip("Vector3 to set.")]
		public Vector3Parameter setVector3;

		[ReflectionReturnInfo("component","property",typeof(List<>))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("List to set.")]
		public ListParameter setList;

		[ReflectionReturnInfo("component","property",typeof(object))]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("object field to store.")]
		public SystemObjectParameter setSystemObject;


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

			Type componentType=UnityTools.GetType(component);
			if(componentType == null){
				componentType=UnityTools.GetType("UnityEngine."+component);
			}
			
			if (componentType != null && ((GameObject)gameObject.Value).GetComponent (componentType) != null) {
				behaviour = ((GameObject)gameObject.Value).GetComponent (componentType);
				info = behaviour.GetType ().GetField (property);
				propertyInfo = behaviour.GetType ().GetProperty(property);
			}
			DoSetProperty ();
			if (!everyFrame) {
				Finish ();
			}
		}

		private Component behaviour;
		private FieldInfo info;
		private PropertyInfo propertyInfo;

		public override void OnUpdate ()
		{
			DoSetProperty ();
		}

		private static IList MakeList(Type t)
		{
			var listType = typeof(List<>);
			var constructedListType = listType.MakeGenericType(t);
			var instance = Activator.CreateInstance(constructedListType);
			return (IList)instance;
		}

		private void DoSetProperty(){
//			Debug.Log (setString.Value);
			if(info != null){
				if (info.FieldType == typeof(int)) {
					info.SetValue(behaviour,setInt.Value);	
				} else if (info.FieldType == typeof(float)) {
					info.SetValue(behaviour,setFloat.Value);	
				} else if (info.FieldType == typeof(bool)) {
					info.SetValue(behaviour,setBool.Value);	
				} else if (info.FieldType == typeof(string)) {
					info.SetValue(behaviour,setString.Value);	
				}else if (info.FieldType == typeof(UnityEngine.Object) || info.FieldType.IsSubclassOf(typeof(UnityEngine.Object))) {
					info.SetValue(behaviour,setObj.Value);	
				}else if(info.FieldType == typeof(UnityEngine.Color)){
					info.SetValue(behaviour,setColor.Value);	
				}else if(info.FieldType == typeof(UnityEngine.Vector3)){
					info.SetValue(behaviour,setVector3.Value);	
				}else if (info.FieldType.IsGenericType && info.FieldType.GetGenericTypeDefinition() == typeof(List<>)) {
					IList list=MakeList(info.FieldType.GetGenericArguments()[0]);
					for(int i=0; i< setList.Value.Count;i++){
						list.Insert(i,setList.Value[i]);
					}
					info.SetValue(behaviour,list);	
				}else{
					info.SetValue(behaviour,setSystemObject.Value);
				}

			}else if(propertyInfo != null){
				if (propertyInfo.PropertyType == typeof(int)) {
					propertyInfo.SetValue(behaviour,setInt.Value,null);	
				} else if (propertyInfo.PropertyType == typeof(float)) {
					propertyInfo.SetValue(behaviour,setFloat.Value,null);	
				} else if (propertyInfo.PropertyType == typeof(bool)) {
					propertyInfo.SetValue(behaviour,setBool.Value,null);	
				} else if (propertyInfo.PropertyType == typeof(string)) {
					propertyInfo.SetValue(behaviour,setString.Value,null);	
				}else if (propertyInfo.PropertyType == typeof(UnityEngine.Object) || propertyInfo.PropertyType.IsSubclassOf(typeof(UnityEngine.Object))) {
					propertyInfo.SetValue(behaviour,setObj.Value,null);	
				}else if(propertyInfo.PropertyType == typeof(UnityEngine.Color)){
					propertyInfo.SetValue(behaviour,setColor.Value,null);	
				}else if(propertyInfo.PropertyType == typeof(UnityEngine.Vector3)){
					propertyInfo.SetValue(behaviour,setVector3.Value,null);	
				}else if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>)) {
					IList list=MakeList(propertyInfo.PropertyType.GetGenericArguments()[0]);
					for(int i=0; i< setList.Value.Count;i++){
						list.Insert(i,setList.Value[i]);
					}
					propertyInfo.SetValue(behaviour,list,null);		
				}else{
					propertyInfo.SetValue(behaviour,setSystemObject.Value,null);
				}
			}
		}
	}
}