using UnityEngine;
using System.Collections;
using System.Reflection;

namespace StateMachine{
	[System.Serializable]
	public class FloatParameter : NamedParameter {
		private PropertyInfo propertyInfo;
		[SerializeField]
		private float value;
		public float Value
		{
			get{
				if(!IsConstant){
					NamedParameter param=stateMachine.GetPrameter(Reference);
					if(param== null){
						param=GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						if(propertyInfo == null){
							propertyInfo=param.GetType().GetProperty("Value");
						}
						return System.Convert.ToSingle(propertyInfo.GetValue(param,null));
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
						if(param is IntParameter){
							(param as IntParameter).Value=System.Convert.ToInt32(value);
						}else{
							(param as FloatParameter).value=value;
						}
					}
				}
			}
		}

		public static implicit operator float (FloatParameter parameter) {
			return parameter.Value;
		}

	}
}