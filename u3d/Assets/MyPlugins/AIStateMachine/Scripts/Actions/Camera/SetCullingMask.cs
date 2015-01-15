using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "Camera",   
	       description = "This is used to render parts of the scene selectively.",
	       url = "http://docs.unity3d.com/ScriptReference/Camera-cullingMask.html")]
	[System.Serializable]
	public  class SetCullingMask : CameraAction {
		[Tooltip("Mask to set.")]
		public LayerMask cullingMask;

		public override void OnEnter (){
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			camera.cullingMask = cullingMask;
		}
	}
}