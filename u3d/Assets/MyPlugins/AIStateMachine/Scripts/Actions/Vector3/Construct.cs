using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityVector3{
	[Info (category = "Vector/Vector3",    
	       description = "Constructs a new Vector3.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Vector3.html")]
	[System.Serializable]
	public class Construct : StateAction {
		[Tooltip("X component of the vector.")]
		public FloatParameter x;
		[Tooltip("Y component of the vector.")]
		public FloatParameter y;
		[Tooltip("Z component of the vector.")]
		public FloatParameter z;
		
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public Vector3Parameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = new Vector3 (x.Value, y.Value, z.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = new Vector3 (x.Value, y.Value, z.Value);
		}
	}
}