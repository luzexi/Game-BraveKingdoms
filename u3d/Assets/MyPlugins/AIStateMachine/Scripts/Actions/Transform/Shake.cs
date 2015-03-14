using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Transform",   
	       description = "",
	       url = "")]
	[System.Serializable]
	public class Shake : GameObjectAction {
		[Tooltip("")]
		public FloatParameter intensity;
		[Tooltip("")]
		public FloatParameter decay;

		private Vector3 originPosition;
		private Quaternion originRotation;
		private float shakeDecay;
		private float shakeIntensity;
		private Transform transform;
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			transform = ((GameObject)gameObject.Value).transform;
			originPosition = transform.position;
			originRotation = transform.rotation;
			shakeIntensity = intensity.Value;
			shakeDecay = decay.Value;
		}

		public override void OnUpdate ()
		{
			if (shakeIntensity > 0) {
				transform.position = originPosition + Random.insideUnitSphere * shakeIntensity;
				transform.rotation = new Quaternion (
					originRotation.x + Random.Range (-shakeIntensity, shakeIntensity) * 0.2f,
					originRotation.y + Random.Range (-shakeIntensity, shakeIntensity) * 0.2f,
					originRotation.z + Random.Range (-shakeIntensity, shakeIntensity) * 0.2f,
					originRotation.w + Random.Range (-shakeIntensity, shakeIntensity) * 0.2f);
				shakeIntensity -= shakeDecay;
			}
		}
	}
}