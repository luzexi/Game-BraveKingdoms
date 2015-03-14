using UnityEngine;
using System.Collections;

namespace StateMachine{
	[System.Serializable]
	public class ColorParameter : NamedParameter {
		[SerializeField]
		private Color value=Color.white;
		
		public Color Value
		{
			get{
				if(!IsConstant){
					ColorParameter param=(ColorParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(ColorParameter)GlobalParameterCollection.GetParameter(Reference);
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
					ColorParameter param=(ColorParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(ColorParameter)GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						param.value=value;
					}
				}
			}
		}

		public static implicit operator Color(ColorParameter value)
		{
			return value.Value;
		}
	}
}