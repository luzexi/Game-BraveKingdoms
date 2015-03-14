using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityVector3{
	[Info (category = "Vector/Vector3",  
	       description = "Returns the angle in degrees between from and to.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Vector3.Angle.html")]
	[System.Serializable]
	public class Angle : StateAction {
		[Tooltip("The angle extends round from this vector.")]
		public Vector3Parameter from;
		[Tooltip("The angle extends round to this vector.")]
		public Vector3Parameter to;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Vector3.Angle (from.Value, to.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Vector3.Angle (from.Value, to.Value);
		}
	}
}