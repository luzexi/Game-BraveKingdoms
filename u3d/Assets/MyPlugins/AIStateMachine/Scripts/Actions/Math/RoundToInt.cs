using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math",  
	       description = "Rounds a float to int.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Mathf.RoundToInt.html")]
	[System.Serializable]
	public class RoundToInt : StateAction {
		[Tooltip("Value to round.")]
		public FloatParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public IntParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.RoundToInt (value.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Mathf.RoundToInt (value.Value);
		}
	}
}