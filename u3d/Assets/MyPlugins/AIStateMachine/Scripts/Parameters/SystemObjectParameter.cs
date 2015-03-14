using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace StateMachine{
	[System.Serializable]
	public class SystemObjectParameter : NamedParameter {
		private object value;
		
		public object Value
		{
			get{
				if(!IsConstant){
					SystemObjectParameter param=(SystemObjectParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(SystemObjectParameter)GlobalParameterCollection.GetParameter(Reference);
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
					SystemObjectParameter param=(SystemObjectParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(SystemObjectParameter)GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						param.value=value;
					}
				}
			}
		}

		protected override void OnEnable ()
		{
			base.OnEnable ();
			IsConstant = false;
		}
	}
}