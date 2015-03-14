using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "Compares two floating point values if they are similar.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.Approximately.html")]
	[System.Serializable]
	public class Approximately : StateAction {
		[Tooltip("First value to use.")]
		public FloatParameter a;
		[Tooltip("Second value to use.")]
		public FloatParameter b;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public BoolParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.Approximately (a.Value, b.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Approximately (a.Value, b.Value);
		}
	}
}