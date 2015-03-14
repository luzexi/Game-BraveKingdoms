using UnityEngine;
using System.Collections;

namespace StateMachine{
	[System.Serializable]
	public class Vector2Parameter : NamedParameter {
		[SerializeField]
		private Vector2 value;
		
		public Vector2 Value
		{
			get{
				if(!IsConstant){
					Vector2Parameter param=(Vector2Parameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(Vector2Parameter)GlobalParameterCollection.GetParameter(Reference);
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
					NamedParameter param=stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(BoolParameter)GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						if(param.GetType() == typeof(Vector2Parameter)){
							(param as Vector2Parameter).Value=value;
						}else{
							(param as Vector3Parameter).Value=value;
						}
					}
				}
			}
		}

		public static implicit operator Vector2(Vector2Parameter value)
		{
			return value.Value;
		}
	}
}