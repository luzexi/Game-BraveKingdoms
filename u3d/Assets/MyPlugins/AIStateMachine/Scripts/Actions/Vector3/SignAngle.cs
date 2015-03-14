using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityVector3{
	[Info (category = "Vector/Vector3",   
	       description = "",
	       url = "")]
	[System.Serializable]
	public class SignAngle : StateAction {
		[Tooltip("")]
		public Vector3Parameter from;
		[Tooltip("")]
		public Vector3Parameter to;
		[Tooltip("")]
		public Vector3Parameter up;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (to.Value == Vector3.zero) {
				store.Value=0.0f;
				return;
			}
			// Create a float to store the angle between the facing of the enemy and the direction it's travelling.
			float angle = Vector3.Angle(from.Value, to.Value);
			// Find the cross product of the two vectors (this will point up if the velocity is to the right of forward).
			Vector3 normal = Vector3.Cross(from.Value, to.Value);
			// The dot product of the normal with the upVector will be positive if they point in the same direction.
			angle *= Mathf.Sign(Vector3.Dot(normal, up.Value));
			// We need to convert the angle we've found from degrees to radians.
			angle *= Mathf.Deg2Rad;
			store.Value= angle;
			if (!everyFrame) {
				Finish();		
			}
		}

		public override void OnUpdate ()
		{
			if (to.Value == Vector3.zero) {
				store.Value=0.0f;
				return;
			}
			// Create a float to store the angle between the facing of the enemy and the direction it's travelling.
			float angle = Vector3.Angle(from.Value, to.Value);
			// Find the cross product of the two vectors (this will point up if the velocity is to the right of forward).
			Vector3 normal = Vector3.Cross(from.Value, to.Value);
			// The dot product of the normal with the upVector will be positive if they point in the same direction.
			angle *= Mathf.Sign(Vector3.Dot(normal, up.Value));
			// We need to convert the angle we've found from degrees to radians.
			angle *= Mathf.Deg2Rad;
			store.Value= angle;
		}
	}
}