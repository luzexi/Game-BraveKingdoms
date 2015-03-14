using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "Returns the angle in radians whose Tan is y/x.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.Atan2.html")]
	[System.Serializable]
	public class Atan2 : StateAction {
		[Tooltip("Y value to use.")]
		public FloatParameter y;
		[Tooltip("X value to use.")]
		public FloatParameter x;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.Atan2 (y.Value,x.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Atan2 (y.Value,x.Value);
		}
	}
}