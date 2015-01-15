using UnityEngine;
using System.Collections;

namespace StateMachine.Action.URigidbody{
	[Info (category = "Rigidbody",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class GetTrajectoryVelocity : StateAction {
		[Tooltip("Start position.")]
		public Vector3Parameter start;
		[Tooltip("End position.")]
		public Vector3Parameter target;
		[Tooltip("Time to complete.")]
		public FloatParameter time;
		[Tooltip("Multiplier in targets direction")]
		[DefaultValueAttribute(1.0f)]
		public FloatParameter multiplier;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public Vector3Parameter store;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			Vector3 dir = target.Value - start.Value;
			target.Value = target.Value + dir.normalized*multiplier.Value;
			store.Value = GetTrajectory (start.Value, target.Value, time.Value); //GetTrajectory (start.Value, target.Value, lob.Value, gravity.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{

			//store.Value = GetTrajectory (start.Value, target.Value, lob.Value, gravity.Value);
		}

		private Vector3 GetTrajectory(Vector3 origin, Vector3 target, float timeToTarget) {
			// calculate vectors
			Vector3 toTarget = target - origin;
			Vector3 toTargetXZ = toTarget;
			toTargetXZ.y = 0;
			
			// calculate xz and y
			float y = toTarget.y;
			float xz = toTargetXZ.magnitude;
			
			// calculate starting speeds for xz and y. Physics forumulase deltaX = v0 * t + 1/2 * a * t * t
			// where a is "-gravity" but only on the y plane, and a is 0 in xz plane.
			// so xz = v0xz * t => v0xz = xz / t
			// and y = v0y * t - 1/2 * gravity * t * t => v0y * t = y + 1/2 * gravity * t * t => v0y = y / t + 1/2 * gravity * t
			float t = timeToTarget;
			float v0y = y / t + 0.5f * Physics.gravity.magnitude * t;
			float v0xz = xz / t;
			
			// create result vector for calculated starting speeds
			Vector3 result = toTargetXZ.normalized;        // get direction of xz but with magnitude 1
			result *= v0xz;                                // set magnitude of xz to v0xz (starting speed in xz plane)
			result.y = v0y;                                // set y to v0y (starting speed of y plane)
			
			return result;
		}

	/*	public Vector3 GetTrajectory(Vector3 startingPosition, Vector3 targetPosition, float lob, Vector3 gravity)
		{
			float physicsTimestep = Time.fixedDeltaTime;
			float timestepsPerSecond = Mathf.Ceil(1f/physicsTimestep);
			
			//By default we set n so our projectile will reach our target point in 1 second
			float n = lob * timestepsPerSecond;
			
			Vector3 a = physicsTimestep * physicsTimestep * gravity;
			Vector3 p = targetPosition;
			Vector3 s = startingPosition;
			
			Vector3 velocity = (s + (((n * n + n) * a) / 2f) - p) * -1 / n;
			
			//This will give us velocity per timestep. The physics engine expects velocity in terms of meters per second
			velocity /= physicsTimestep;
			return velocity;
		}*/
	}
}