using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "Returns the arc-tangent of f - the angle in radians whose tangent is f.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.Atan.html")]
	[System.Serializable]
	public class Atan : StateAction {
		[Tooltip("The value to use.")]
		public FloatParameter f;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.Atan (f.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Atan (f.Value);
		}
	}
}