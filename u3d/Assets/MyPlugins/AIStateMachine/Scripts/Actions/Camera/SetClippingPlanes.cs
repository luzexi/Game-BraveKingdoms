using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "Camera",   
	       description = "Sets the far and near clipping distance.",
	       url = "http://docs.unity3d.com/ScriptReference/Camera-farClipPlane.html")]
	[System.Serializable]
	public  class SetClippingPlanes : CameraAction {
		[Tooltip("Distance to set.")]
		public FloatParameter nearClippingPlane;
		[Tooltip("Distance to set.")]
		public FloatParameter farClippingPlane;

		public override void OnEnter (){
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			camera.nearClipPlane = nearClippingPlane.Value;
			camera.farClipPlane = farClippingPlane.Value;
		}
	}
}