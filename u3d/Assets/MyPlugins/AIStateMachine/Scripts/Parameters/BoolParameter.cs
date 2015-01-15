using UnityEngine;
using System.Collections;

namespace StateMachine{
	[System.Serializable]
	public class BoolParameter : NamedParameter {
		[SerializeField]
		private bool value;
		
		public bool Value
		{
			get{
				if(!IsConstant){
					BoolParameter param=(BoolParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(BoolParameter)GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						return param.value;
					}
				}
				return this.value;
			}
			set{
				this.value = value;
				if(!IsConstant){
					BoolParameter param=(BoolParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(BoolParameter)GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						param.value=value;
					}
				}
			}
		}

		public static implicit operator bool(BoolParameter value)
		{
			return value.Value;
		}
	}
}