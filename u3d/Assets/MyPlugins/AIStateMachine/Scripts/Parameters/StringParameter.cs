using UnityEngine;
using System.Collections;

namespace StateMachine{
	[System.Serializable]
	public class StringParameter : NamedParameter {
		[SerializeField]
		private string value;
		
		public string Value
		{
			get{
				if(!IsConstant){
					NamedParameter param=(NamedParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						return param.GetType().GetProperty("Value").GetValue(param,null).ToString();
					}
				}
				return this.value;
			}
			set{
				this.value = value;
				if(!IsConstant){
					NamedParameter param=(NamedParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						param.GetType().GetProperty("Value").SetValue(param,value.ToString(),null);
					}
				}
			}
		}

		public static implicit operator string(StringParameter value)
		{
			return value.Value;
		}
	}
}