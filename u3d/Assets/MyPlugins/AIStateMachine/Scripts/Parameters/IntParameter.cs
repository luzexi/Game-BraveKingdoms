using UnityEngine;
using System.Collections;
using System.Reflection;

namespace StateMachine{
	[System.Serializable]
	public class IntParameter : NamedParameter {
		[SerializeField]
		private int value;
		private PropertyInfo info;

		public int Value
		{
			get{
				if(!IsConstant){
					NamedParameter param=stateMachine.GetPrameter(Reference);
					if(param== null){
						param=GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						if(info == null){
							info=param.GetType().GetProperty("Value");
						}
						return System.Convert.ToInt32(info.GetValue(param,null));
					}
				}
				return this.value;
			}
			set{
				this.value = value;
				if(!IsConstant){
					NamedParameter param=stateMachine.GetPrameter(Reference);
					if(param== null){
						param=GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						if(param.GetType() == typeof(FloatParameter)){
							(param as FloatParameter).Value=System.Convert.ToInt32(value);
						}else{
							(param as IntParameter).value=value;
						}
						//param.value=value;
					}
				}
			}
		}

		public static implicit operator int (IntParameter parameter) {
			return parameter.Value;
		}
	}
}