using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Vector/Vector3", 
	       description = "Returns this vector with a magnitude of 1.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Vector3-normalized.html")]
	[System.Serializable]
	public class Normalize : StateAction {
		[Tooltip("Vector3 to normalize.")]
		public Vector3Parameter vector;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public Vector3Parameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = vector.Value.normalized;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = vector.Value.normalized;
		}
	}
}