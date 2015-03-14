using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Random",   
	       description = "Returns a random number between 0.0 [inclusive] and 1.0 [inclusive] ",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Random-value.html")]
	[System.Serializable]
	public class UnitValue : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Random.value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Random.value;
		}
	}
}