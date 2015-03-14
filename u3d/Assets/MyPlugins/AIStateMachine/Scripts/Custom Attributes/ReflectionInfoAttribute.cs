using System;
using System.Reflection;

namespace StateMachine{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class ReflectionInfoAttribute : Attribute {
		public string referenceField;
		public ReflectionType reflectionType;
		public bool requiresWrite=true;

		public ReflectionInfoAttribute(string referenceField, ReflectionType reflectionType){
			this.referenceField = referenceField;
			this.reflectionType = reflectionType;		
		}

		public ReflectionInfoAttribute(string referenceField, ReflectionType reflectionType, bool requiresWrite){
			this.referenceField = referenceField;
			this.reflectionType = reflectionType;		
			this.requiresWrite = requiresWrite;
		}
	}

	
	public enum ReflectionType{
		Fields,
		Properties,
		FieldsAndProperties,
		Methods
	}
}