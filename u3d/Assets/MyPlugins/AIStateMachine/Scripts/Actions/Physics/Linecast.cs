using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Physics",   
	       description = "Returns true if there is any collider intersecting the line between start and end.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Physics.Linecast.html")]
	[System.Serializable]
	public class Linecast : StateAction {
		[Tooltip("The starting point.")]
		public Vector3Parameter start;
		[Tooltip("The end point.")]
		public Vector3Parameter end;
		[Tooltip("Layer masks can be used selectively filter game objects for example when casting rays.")]
		public LayerMask layerMask;
		
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("The distance from the ray's origin to the impact point.")]
		public FloatParameter hitDistance;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("The normal of the surface the ray hit.")]
		public Vector3Parameter hitNormal;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("The impact point in world space where the ray hit the collider.")]
		public Vector3Parameter hitPoint;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("The GameObject of the rigidbody or collider that was hit.")]
		public ObjectParameter hitGameObject;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			RaycastHit hit;
			if (Physics.Raycast (start.Value, end.Value,out hit, layerMask)) {
				hitDistance.Value=hit.distance;
				hitNormal.Value=hit.normal;
				hitPoint.Value=hit.point;
				hitGameObject.Value=hit.transform.gameObject;
			}
			
			if (!everyFrame) {
				Finish();			
			}
		}
		
		public override void OnUpdate ()
		{	
			RaycastHit hit;
			if (Physics.Raycast (start.Value, end.Value,out hit, layerMask)) {
				hitDistance.Value=hit.distance;
				hitNormal.Value=hit.normal;
				hitPoint.Value=hit.point;
				hitGameObject.Value=hit.transform.gameObject;
			}	
		}
		
	}
}