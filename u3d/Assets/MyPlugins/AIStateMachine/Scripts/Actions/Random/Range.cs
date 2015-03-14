using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Random",   
	       description = "Returns a random float number between and min [inclusive] and max [inclusive].",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Random.Range.html")]
	[System.Serializable]
	public class Range : StateAction {
		[Tooltip("The minimum value")]
		public FloatParameter min;
		[Tooltip("The maximum value")]
		public FloatParameter max;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Random.Range (min.Value, max.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Random.Range (min.Value, max.Value);
		}
	}
}