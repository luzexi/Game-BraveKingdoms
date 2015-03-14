using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Debug",    
	       description = "Draws a line from start to start + dir in world coordinates.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Debug.DrawRay.html")]
	[System.Serializable]
	public class DrawRay : StateAction {
		[Tooltip("Start position of the line.")]
		public Vector3Parameter start;
		[Tooltip("The direction of the ray.")]
		public Vector3Parameter direction;
		[Tooltip("Color of the ray.")]
		public ColorParameter color;
		[Tooltip("Color of the ray.")]
		public FloatParameter duration;
		[Tooltip("Color of the ray.")]
		public BoolParameter depthTest;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter(){
			Debug.DrawRay (start.Value, direction.Value, color.Value,duration.Value,depthTest.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			Debug.DrawRay (start.Value, direction.Value, color.Value,duration.Value,depthTest.Value);
		}
	}
}
