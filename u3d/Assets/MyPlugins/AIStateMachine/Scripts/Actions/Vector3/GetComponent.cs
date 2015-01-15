using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityVector3{
	[Info (category = "Vector/Vector3",    
	       description = ".",
	       url = "")]
	[System.Serializable]
	public class GetComponent : StateAction {
		[Tooltip("Vector to use.")]
		public Vector3Parameter vector;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("X component of the vector.")]
		public FloatParameter x;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Y component of the vector.")]
		public FloatParameter y;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Z component of the vector.")]
		public FloatParameter z;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			x.Value = vector.Value.x;
			y.Value = vector.Value.y;
			z.Value = vector.Value.z;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			x.Value = vector.Value.x;
			y.Value = vector.Value.y;
			z.Value = vector.Value.z;
		}
	}
}