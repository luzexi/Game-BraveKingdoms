using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Vector/Vector3",    
	       description = "Distance between two Vector3 points.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Vector3.Distance.html")]
	[System.Serializable]
	public class Distance : StateAction {
		[Tooltip("Vector3 value.")]
		public Vector3Parameter a;
		[Tooltip("Vector3 value.")]
		public Vector3Parameter b;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Vector3.Distance (a.Value, b.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Vector3.Distance (a.Value, b.Value);
		}
	}
}