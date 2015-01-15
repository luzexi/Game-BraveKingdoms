using System;

namespace StateMachine{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class RequiredFieldAttribute : Attribute
	{
		private readonly DefaultReference defaultReference;
		private readonly bool allowConstant;
		private readonly bool allowBindedConstant;

		public DefaultReference DefaultReference{
			get{
				return this.defaultReference;
			}
		}

		public bool AllowConstant{
			get{
				return this.allowConstant;
			}
		}

		public bool AllowBindedConstant{
			get{
				return this.allowBindedConstant;
			}
		}

		public RequiredFieldAttribute(DefaultReference defaultReference, bool allowConstant,bool allowBindedConstant){
			this.defaultReference = defaultReference;
			this.allowConstant = allowConstant;
			this.allowBindedConstant = allowBindedConstant;
		}

		public RequiredFieldAttribute(DefaultReference defaultReference, bool allowConstant){
			this.defaultReference = defaultReference;
			this.allowConstant = allowConstant;
			this.allowBindedConstant = true;
		}

		public RequiredFieldAttribute(DefaultReference defaultReference){
			this.defaultReference = defaultReference;
			this.allowConstant = true;
			this.allowBindedConstant = true;
		}

		public RequiredFieldAttribute(){
			this.defaultReference = DefaultReference.Required;
			this.allowConstant = true;
			this.allowBindedConstant = true;
		}
	}

	public enum DefaultReference{
		None,// Field is not required, meaning don't use this field.
		Owner,// Field is required, but the owner will be set as the default value
		Required//Field is required and you need to make a reference to a parameter

	}
}