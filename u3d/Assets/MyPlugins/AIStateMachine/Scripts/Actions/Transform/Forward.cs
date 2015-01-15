using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Transform",    
	       description = "The blue axis of the transform in world space.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Transform-forward.html")]
	[System.Serializable]
	public class Forward : GameObjectAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public Vector3Parameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			store.Value = ((GameObject)gameObject.Value).transform.forward;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = ((GameObject)gameObject.Value).transform.forward;
		}
	}
}