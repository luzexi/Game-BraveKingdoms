using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "Physics",  
	       description = "True if there are any colliders overlapping the sphere defined by position and radius in world coordinates.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Physics.CheckSphere.html")]
	[System.Serializable]
	public class CheckSphere : StateCondition {
		[Tooltip("Position.")]
		public Vector3Parameter position;
		[Tooltip("Radius of the sphere")]
		public FloatParameter radius;
		[Tooltip("Layer masks can be used selectively filter game objects for example when casting rays.")]
		public LayerMask layerMask;
		[Tooltip("Does the result equals this condition.")]
		public BoolParameter equals;
		
		
		public override bool Validate ()
		{	
			return Physics.CheckSphere(position.Value,radius.Value,layerMask) == equals.Value;
		}
	}
}