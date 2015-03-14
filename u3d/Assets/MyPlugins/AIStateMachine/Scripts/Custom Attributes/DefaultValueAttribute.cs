using System;

namespace StateMachine{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class DefaultValueAttribute : Attribute
	{
		private readonly object value;
		
		public object DefaultValue{
			get{
				return this.value;
			}
		}
		
		public DefaultValueAttribute(object value){
			this.value = value;
		}
	}
}