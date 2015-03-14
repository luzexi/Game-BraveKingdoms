using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = ".",
	       url = "")]
	[System.Serializable]
	public class Clamp : StateAction {
		[Tooltip("The value to clamp")]
		public FloatParameter value;
		[Tooltip("Min value")]
		public FloatParameter min;
		[Tooltip("Max value")]
		public FloatParameter max;

		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.Clamp (value.Value, min.Value, max.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Mathf.Clamp (value.Value, min.Value, max.Value);
		}
	}
}