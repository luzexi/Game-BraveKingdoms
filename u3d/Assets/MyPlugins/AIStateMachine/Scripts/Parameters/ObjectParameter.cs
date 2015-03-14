using UnityEngine;
using System.Collections;

namespace StateMachine{
	[System.Serializable]
	public class ObjectParameter : NamedParameter {
		[SerializeField]
		private bool fromSceneInstance;
		public bool FromSceneInstance{
			get{
				return fromSceneInstance;
			}
			set{
				fromSceneInstance=value;
			}
		}

		/*[SerializeField]
		private int sceneId;
		public int SceneId{
			get{
				return sceneId;
			}
			set{
				sceneId=value;
			}
		}*/

		[SerializeField]
		private Object value;
		
		public Object Value
		{
			get{
				if(!IsConstant){
					ObjectParameter param=(ObjectParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(ObjectParameter)GlobalParameterCollection.GetParameter(Reference);
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
					ObjectParameter param=(ObjectParameter)stateMachine.GetPrameter(Reference);
					if(param== null){
						param=(ObjectParameter)GlobalParameterCollection.GetParameter(Reference);
					}
					if(param != null){
						param.value=value;
					}
				}
			}
		}
	}
}