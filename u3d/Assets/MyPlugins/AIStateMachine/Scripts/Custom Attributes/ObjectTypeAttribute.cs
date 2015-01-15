using System;

namespace StateMachine{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class ObjectTypeAttribute : Attribute
	{
		private readonly Type type;
		
		public Type ObjectType{
			get{
				return this.type;
			}
		}
		
		public ObjectTypeAttribute(Type type){
			this.type = type;
		}
	}
}