using UnityEngine;
using System.Collections;

namespace StateMachine{
	[System.Serializable]
	public class Vector3Parameter : NamedParameter {
		[SerializeField]
		private Vector3 value;
		
		public Vector3 Value
		{
			get{
				if(!IsConstant){
					NamedParameter param=stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(Vector3Parameter)GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						if(param is Vector2Parameter){
							return (param as Vector2Parameter).Value;
						}else{
							return (param as Vector3Parameter).value;
						}
					}
				}
				return this.value;
			}
			set{
				this.value = value;
				if(!IsConstant){
					NamedParameter param=stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(Vector3Parameter)GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						if(param.GetType() == typeof(Vector2Parameter)){
							(param as Vector2Parameter).Value=new Vector2(value.x,value.y);
						}else{
							(param as Vector3Parameter).value=value;
						}
					}
				}
			}
		}

		public static implicit operator Vector3(Vector3Parameter value)
		{
			return value.Value;
		}
	}
}