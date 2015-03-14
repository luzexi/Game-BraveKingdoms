using System;
using System.Reflection;

namespace StateMachine{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class ReflectionReturnInfoAttribute : Attribute {
		public string referenceComponent;
		public string referenceField;
		public Type returnType;

		public ReflectionReturnInfoAttribute(string referenceComponent, string referenceField,Type returnType){
			this.referenceComponent = referenceComponent;
			this.referenceField = referenceField;
			this.returnType = returnType;

		}
	}

}