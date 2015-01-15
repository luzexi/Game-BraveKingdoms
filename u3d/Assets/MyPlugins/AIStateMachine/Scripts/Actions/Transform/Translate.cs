using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Transform",  
	       description = "Moves the transform in the direction and distance of translation.",
	       url = "")]
	[System.Serializable]
	public class Translate : GameObjectAction {
		[Tooltip("Translation")]
		public Vector3Parameter translation;
		[Tooltip("The coordinate space in which to operate.")]
		public Space space;
		[Tooltip("Use this to make your game frame rate independent.")]
		public BoolParameter deltaTime;
		
		public override void OnUpdate ()
		{
			if (deltaTime.Value) {
				((GameObject)gameObject.Value).transform.Translate (translation.Value*Time.deltaTime, space);
			} else {
				((GameObject)gameObject.Value).transform.Rotate (translation.Value, space);
			}
		}
	}
}