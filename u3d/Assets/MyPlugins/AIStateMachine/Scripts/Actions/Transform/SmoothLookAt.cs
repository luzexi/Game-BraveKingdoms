using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Transform",   
	       description = "Rotates the transform smooth towards the target.",
	       url = "")]
	[System.Serializable]
	public class SmoothLookAt : GameObjectAction {
		[Tooltip("Position to look at.")]
		public Vector3Parameter position;
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.None,false)]
		[Tooltip("GameObject to look at.")]
		public ObjectParameter target;
		[Tooltip("The angular speed in degrees/second to rotate the game object.")]
		public FloatParameter speed;
		[Tooltip("If set to true, the game object will be rotated only in y axis.")]
		public BoolParameter inY;


		private Quaternion lastRotation;
		private Quaternion desiredRotation;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			lastRotation =((GameObject)gameObject.Value).transform.rotation;
			desiredRotation = lastRotation;
		}
		
		public override void OnUpdate ()
		{
			Transform gameObjectTransform = ((GameObject)gameObject.Value).transform;
			Vector3 targetPosition =(position != null? position.Value:Vector3.zero);

			if(target.Value != null){
				Transform targetTransform=((GameObject)target.Value).transform;
			 	targetPosition = targetTransform.position;
			}
			Vector3 gameObjectPosition = gameObjectTransform.position;

			targetPosition.y = (inY.Value ? gameObjectPosition.y : targetPosition.y);

			Vector3 diff = targetPosition - gameObjectPosition;
			if (diff != Vector3.zero && diff.sqrMagnitude > 0)
			{
				desiredRotation = Quaternion.LookRotation(diff);
			}
			
			lastRotation = Quaternion.Slerp(lastRotation, desiredRotation, speed.Value * Time.deltaTime);
			gameObjectTransform.rotation = lastRotation;
		}
	}
}