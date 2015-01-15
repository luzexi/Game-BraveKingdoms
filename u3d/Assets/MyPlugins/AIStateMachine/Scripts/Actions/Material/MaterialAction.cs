using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "",   
	       description = "",
	       url = "")]
	[System.Serializable]
	public abstract class MaterialAction : StateAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("The game object to use.")]
		public ObjectParameter gameObject;
		[Tooltip("Material array index.")]
		public IntParameter index;
		protected Renderer renderer;

		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("["+stateMachine.name+"]"+"GameObject paramter in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}
			renderer = ((GameObject)gameObject.Value).renderer;
			if (renderer == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the Renderer component on the GameObject. Action disabled!");
				return;	
			}

		}
	}
}