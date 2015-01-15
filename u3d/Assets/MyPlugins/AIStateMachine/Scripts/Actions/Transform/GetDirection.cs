using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Transform",  
	       description = "Get the direction of the gameObject and target.",
	       url = "")]
	[System.Serializable]
	public class GetDirection : GameObjectAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Required,false)]
		public ObjectParameter target;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("The normalized direction")]
		public Vector3Parameter normalized;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("The magnitude of the direction")]
		public FloatParameter magnitude;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("The direction")]
		public Vector3Parameter direction;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("X component of the direction.")]
		public FloatParameter x;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Y component of the direction.")]
		public FloatParameter y;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Z component of the direction.")]
		public FloatParameter z;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			Transform gameObjectTransform = ((GameObject)gameObject.Value).transform;
			Transform targetTransform=((GameObject)target.Value).transform;
			Vector3 dir = targetTransform.position - gameObjectTransform.position;
			normalized.Value = dir.normalized;
			magnitude.Value = dir.magnitude;
			direction.Value = dir;
			x.Value = dir.x;
			y.Value = dir.y;
			z.Value = dir.z;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			Transform gameObjectTransform = ((GameObject)gameObject.Value).transform;
			Transform targetTransform=((GameObject)target.Value).transform;
			Vector3 dir = targetTransform.position - gameObjectTransform.position;
			normalized.Value = dir.normalized;
			magnitude.Value = dir.magnitude;
			direction.Value = dir;
			x.Value = dir.x;
			y.Value = dir.y;
			z.Value = dir.z;
		}
	}
}