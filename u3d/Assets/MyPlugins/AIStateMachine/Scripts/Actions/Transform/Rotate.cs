using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Transform",  
	       description = "Applies a rotation of /eulerAngles.z/ degrees around the z axis, /eulerAngles.x/ degrees around the x axis, and /eulerAngles.y/ degrees around the y axis (in that order).",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Transform.Rotate.html")]
	[System.Serializable]
	public class Rotate : GameObjectAction {
		[Tooltip("Euler Angles")]
		public Vector3Parameter eulerAngles;
		[Tooltip("The coordinate space in which to operate.")]
		public Space space;
		[Tooltip("Use this to make your game frame rate independent.")]
		public BoolParameter deltaTime;

		Transform transform;
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			transform = ((GameObject)gameObject.Value).transform;
		}

		public override void OnUpdate ()
		{
			if (deltaTime.Value) {
				transform.Rotate (eulerAngles.Value*Time.deltaTime, space);
			} else {
				transform.Rotate (eulerAngles.Value, space);
			}
		}
	}
}