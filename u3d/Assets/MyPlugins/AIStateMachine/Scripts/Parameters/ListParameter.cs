using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace StateMachine{
	[System.Serializable]
	public class ListParameter : NamedParameter {
		private List<object> value;

		public List<object> Value
		{
			get{
				if(!IsConstant){
					ListParameter param=(ListParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(ListParameter)GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						if(param.value == null){
							param.value= new List<object>();
						}
						return param.value;
					}
				}
				if(this.value == null){
					this.value=new List<object>();
				}
				return this.value;
			}
			set{
				this.value = value;
				if(!IsConstant){
					ListParameter param=(ListParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(ListParameter)GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						param.value=value;
					}
				}
			}
		}

		public static implicit operator List<object>(ListParameter value)
		{
			return value.Value;
		}

		protected override void OnEnable ()
		{
			base.OnEnable ();
			IsConstant = false;
		}
	}
}