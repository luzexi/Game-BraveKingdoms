using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "Camera",   
	       description = "Gets the main camera.",
	       url = "")]
	[System.Serializable]
	public  class GetMainCamera : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the GameObject.")]
		public ObjectParameter store;
		public override void OnEnter (){
			store.Value=Camera.main != null ? Camera.main.gameObject : null;
		}
	}
}