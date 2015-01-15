using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "Returns the smallest integer greater to or equal to f.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.Ceil.html")]
	[System.Serializable]
	public class Ceil : StateAction {
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
			store.Value = Mathf.Ceil (f.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Ceil (f.Value);
		}
	}
}