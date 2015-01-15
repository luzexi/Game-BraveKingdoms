using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine{
	public static class CustomAttributeUtility {
		private readonly static Dictionary<Type, object[]> typeCustomAttributes;
		private readonly static Dictionary<FieldInfo, object[]> fieldCustomAttributes;
		private readonly static Dictionary<FieldInfo,GUIContent> inspectorLabelContent;

		static CustomAttributeUtility(){
			CustomAttributeUtility.typeCustomAttributes = new Dictionary<Type, object[]>();
			CustomAttributeUtility.fieldCustomAttributes = new Dictionary<FieldInfo, object[]>();
			CustomAttributeUtility.inspectorLabelContent = new Dictionary<FieldInfo, GUIContent> ();
		}
		
		public static object[] GetCustomAttributes(Type type)
		{
			object[] customAttributes;
			if (!CustomAttributeUtility.typeCustomAttributes.TryGetValue(type, out customAttributes))
			{
				customAttributes = type.GetCustomAttributes(true);
				CustomAttributeUtility.typeCustomAttributes.Add(type, customAttributes);
			}
			return customAttributes;
		}
		
		public static object[] GetCustomAttributes(FieldInfo field)
		{
			object[] customAttributes;
			if (!CustomAttributeUtility.fieldCustomAttributes.TryGetValue(field, out customAttributes))
			{
				customAttributes = field.GetCustomAttributes(true);
				CustomAttributeUtility.fieldCustomAttributes.Add(field, customAttributes);
			}
			return customAttributes;
		}

		public static string GetTooltip(this object obj)
		{
			return CustomAttributeUtility.GetTooltip(obj.GetType());
		}

		public static string GetTooltip(this Type type)
		{
			return CustomAttributeUtility.GetTooltip(CustomAttributeUtility.GetCustomAttributes(type));
		}
		
		public static string GetTooltip(this FieldInfo field)
		{
			return CustomAttributeUtility.GetTooltip(CustomAttributeUtility.GetCustomAttributes(field));
		}

		public static string GetTooltip(object[] attributes)
		{
			object[] objArray = attributes;
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				TooltipAttribute tooltipAttribute = objArray[i] as TooltipAttribute;
				if (tooltipAttribute != null)
				{
					return tooltipAttribute.Text;
				}
			}
			return string.Empty;
		}

		public static string GetInspectorLabel(this FieldInfo field)
		{
			string label = CustomAttributeUtility.GetInspectorLabel (CustomAttributeUtility.GetCustomAttributes (field));
			if(string.IsNullOrEmpty(label)){
				label=System.Text.RegularExpressions.Regex.Replace(char.ToUpper(field.Name[0]) + field.Name.Substring(1), "(?<!^)_?([A-Z])", " $1");
			}
			return label;
		}
		
		public static string GetInspectorLabel(object[] attributes)
		{
			object[] objArray = attributes;
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				InspectorLabelAttribute inspectorLabelAttribute = objArray[i] as InspectorLabelAttribute;
				if (inspectorLabelAttribute != null)
				{
					return inspectorLabelAttribute.Label;
				}
			}
			return string.Empty;
		}

		public static GUIContent GetInspectorGUIContent(this FieldInfo field)
		{
			GUIContent inspectorGUIContent;
			if (!CustomAttributeUtility.inspectorLabelContent.TryGetValue(field, out inspectorGUIContent))
			{
				inspectorGUIContent =new GUIContent(field.GetInspectorLabel(),field.GetTooltip());
				CustomAttributeUtility.inspectorLabelContent.Add(field, inspectorGUIContent);
			}
			return inspectorGUIContent;
		}

		public static Type GetObjectType(this FieldInfo field)
		{
			return CustomAttributeUtility.GetObjectType(CustomAttributeUtility.GetCustomAttributes(field));
		}
		
		public static Type GetObjectType(object[] attributes)
		{
			object[] objArray = attributes;
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				ObjectTypeAttribute objectTypeAttribute = objArray[i] as ObjectTypeAttribute;
				if (objectTypeAttribute != null)
				{
					return objectTypeAttribute.ObjectType;
				}
			}
			return typeof(UnityEngine.Object);
		}

		public static object GetDefaultValue(this FieldInfo field)
		{
			return CustomAttributeUtility.GetDefaultValue(CustomAttributeUtility.GetCustomAttributes(field));
		}
		
		public static object GetDefaultValue(object[] attributes)
		{
			object[] objArray = attributes;
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				DefaultValueAttribute defaultValueAttribute = objArray[i] as DefaultValueAttribute;
				if (defaultValueAttribute != null)
				{
					return defaultValueAttribute.DefaultValue;
				}
			}
			return null;
		}

		public static RequiredFieldAttribute GetRequiredFieldAttribute(object[] attributes){
			object[] objArray = attributes;
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				RequiredFieldAttribute requiredFieldAttribute = objArray[i] as RequiredFieldAttribute;
				if (requiredFieldAttribute != null)
				{
					return requiredFieldAttribute;
				}
			}
			return null;
		}

		public static DefaultReference GetDefaultReference(this FieldInfo field)
		{
			return CustomAttributeUtility.GetDefaultReference(CustomAttributeUtility.GetCustomAttributes(field));
		}
		
		public static DefaultReference GetDefaultReference(object[] attributes)
		{
			RequiredFieldAttribute requiredFieldAttribute = GetRequiredFieldAttribute (attributes);
			if (requiredFieldAttribute != null) {
				return requiredFieldAttribute.DefaultReference;			
			}
			return DefaultReference.Required;
		}

		public static bool IsFieldRequired(this FieldInfo field){
			return field.GetDefaultReference () == DefaultReference.Required;
		}

		public static bool IsConstantValueAllowed(this FieldInfo field)
		{
			RequiredFieldAttribute requiredFieldAttribute = CustomAttributeUtility.GetRequiredFieldAttribute (CustomAttributeUtility.GetCustomAttributes (field));
			if (requiredFieldAttribute != null) {
				return requiredFieldAttribute.AllowConstant;			
			}
			return true;
		}

		public static bool IsBindedConstantValueAllowed(this FieldInfo field)
		{
			RequiredFieldAttribute requiredFieldAttribute = CustomAttributeUtility.GetRequiredFieldAttribute (CustomAttributeUtility.GetCustomAttributes (field));
			if (requiredFieldAttribute != null) {
				return requiredFieldAttribute.AllowBindedConstant;			
			}
			return true;
		}

		public static bool HideFieldInInspector(this FieldInfo info){
			object[] objArray=CustomAttributeUtility.GetCustomAttributes(info);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				HideInInspector hideInInspectorAttribute = objArray[i] as HideInInspector;
				if (hideInInspectorAttribute != null)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsComponentInfo(this FieldInfo info){
			object[] objArray=CustomAttributeUtility.GetCustomAttributes(info);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				ComponentInfoAttribute componentInfoAttribute = objArray[i] as ComponentInfoAttribute;
				if (componentInfoAttribute != null)
				{
					return true;
				}
			}
			return false;
		}

		public static ReflectionReturnInfoAttribute GetReflectionReturnInfoAttribute(this FieldInfo field){
			object[] objArray = CustomAttributeUtility.GetCustomAttributes(field);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				ReflectionReturnInfoAttribute reflectionReturnInfoAttribute = objArray[i] as ReflectionReturnInfoAttribute;
				if (reflectionReturnInfoAttribute != null)
				{
					return reflectionReturnInfoAttribute;
				}
			}
			return null;
		}

		public static bool IsReflectionReturnInfo(this FieldInfo field){
			return field.GetReflectionReturnInfoAttribute () != null;
		}
		
		public static Type GetReflectionReturnType(this FieldInfo field){
			ReflectionReturnInfoAttribute reflectionReturnInfoAttribute = field.GetReflectionReturnInfoAttribute ();
			if (reflectionReturnInfoAttribute != null) {
				return reflectionReturnInfoAttribute.returnType;			
			}
			return null;
		}

		public static bool RequiresWrite(this FieldInfo field){
			ReflectionInfoAttribute reflectionInfoAttribute = field.GetReflectionInfoAttribute ();
			return reflectionInfoAttribute.requiresWrite;
		}

		public static Type GetReferenceReturnFieldType(this FieldInfo field,object obj){
			ReflectionReturnInfoAttribute reflectionReturnInfoAttribute = field.GetReflectionReturnInfoAttribute ();
			if (reflectionReturnInfoAttribute != null) {
				string referenceComponentParameter = (string)obj.GetType ().GetField (reflectionReturnInfoAttribute.referenceComponent).GetValue (obj);
				string referencePropertyParameter = (string)obj.GetType ().GetField (reflectionReturnInfoAttribute.referenceField).GetValue (obj);
				
				if (!string.IsNullOrEmpty (referenceComponentParameter)) {
					
					Type componentType = UnityTools.GetType (referenceComponentParameter);
					if (componentType == null) {
						componentType = UnityTools.GetType ("UnityEngine." + referenceComponentParameter);
					}
					if (componentType != null) {
						Type type = null;
						FieldInfo refFieldInfo = componentType.GetField (referencePropertyParameter);
						if (refFieldInfo != null) {
							type = refFieldInfo.FieldType;
						}
						PropertyInfo refPropertyInfo = componentType.GetProperty (referencePropertyParameter);
						if (refPropertyInfo != null) {
							type = refPropertyInfo.PropertyType;
						}
						return type;
					}
				}
			}
			return null;
		}

		public static ReflectionInfoAttribute GetReflectionInfoAttribute(this FieldInfo field){
			object[] objArray = CustomAttributeUtility.GetCustomAttributes(field);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				ReflectionInfoAttribute reflectionInfoAttribute = objArray[i] as ReflectionInfoAttribute;
				if (reflectionInfoAttribute != null)
				{
					return reflectionInfoAttribute;
				}
			}
			return null;
		}

		public static bool IsReflectionInfo(this FieldInfo field){
			return GetReflectionInfoAttribute(field) != null;
		}
		
		public static ReflectionType GetReflectionType(this FieldInfo field){
			
			ReflectionInfoAttribute reflectionInfoAttribute = field.GetReflectionInfoAttribute ();
			if (reflectionInfoAttribute != null) {
				return reflectionInfoAttribute.reflectionType;			
			}
			return ReflectionType.Fields;	
		}

		public static Type GetReflectionReferenceFieldType(this FieldInfo info, object obj){
			ReflectionInfoAttribute reflectionInfoAttribute = info.GetReflectionInfoAttribute ();

			if (reflectionInfoAttribute != null) {
				string referenceParameter = (string)obj.GetType ().GetField (reflectionInfoAttribute.referenceField).GetValue (obj);
				if (!string.IsNullOrEmpty (referenceParameter)) {
					Type componentType = UnityTools.GetType (referenceParameter);
					if (componentType == null) {
						componentType = UnityTools.GetType ("UnityEngine." + referenceParameter);
					}
					return componentType;
				}
			}
			return null;	
		}



		public static string GetCategory(this object obj){
			return GetCategory (obj.GetType ());
		}

		public static string GetCategory(this Type type){
			object[] objArray=CustomAttributeUtility.GetCustomAttributes(type);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				InfoAttribute infoAttribute = objArray[i] as InfoAttribute;
				if (infoAttribute != null)
				{
					return infoAttribute.category;
				}
			}
			return string.Empty;
		}

		public static string GetDescription(this object obj){
			return GetDescription (obj.GetType ());
		}

		public static string GetDescription(this Type type){
			object[] objArray=CustomAttributeUtility.GetCustomAttributes(type);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				InfoAttribute infoAttribute = objArray[i] as InfoAttribute;
				if (infoAttribute != null)
				{
					return infoAttribute.description;
				}
			}
			return string.Empty;
		}

		public static string GetInfoUrl(this object obj){
			return GetInfoUrl (obj.GetType ());
		}

		public static string GetInfoUrl(this Type type){
			object[] objArray=CustomAttributeUtility.GetCustomAttributes(type);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				InfoAttribute infoAttribute = objArray[i] as InfoAttribute;
				if (infoAttribute != null)
				{
					return infoAttribute.url;
				}
			}
			return string.Empty;
		}
	}
}