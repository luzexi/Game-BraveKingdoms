using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Transform",   
	       description = "",
	       url = "")]
	[System.Serializable]
	public class SetEulerAngles : GameObjectAction {
		[Tooltip("Euler angles to set.")]
		public Vector3Parameter eulerAngles;
		[Tooltip("Smooth multiplier.")]
		public FloatParameter smooth;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			((GameObject)gameObject.Value).transform.rotation=Quaternion.Lerp(((GameObject)gameObject.Value).transform.rotation, Quaternion.Euler(eulerAngles.Value),Time.deltaTime*smooth.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			((GameObject)gameObject.Value).transform.rotation=Quaternion.Lerp(((GameObject)gameObject.Value).transform.rotation, Quaternion.Euler(eulerAngles.Value),Time.deltaTime*smooth.Value);
		}
	}
}