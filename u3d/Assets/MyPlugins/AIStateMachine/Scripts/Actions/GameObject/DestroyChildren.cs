using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine.Action{
	[Info (category = "GameObject",    
	       description = "Destroys all children of the target.",
	       url = "")]
	[System.Serializable]
	public class DestroyChildren : GameObjectAction {
		[Tooltip("Should inactive children be destroyed?")]
		public BoolParameter includeInactive;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private Transform root;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			root = ((GameObject)gameObject.Value).transform;
			foreach(Transform transform in root){
				Destroy(transform.gameObject);
			}
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			foreach(Transform transform in root){
				Destroy(transform.gameObject);
			}
		}
	}
}