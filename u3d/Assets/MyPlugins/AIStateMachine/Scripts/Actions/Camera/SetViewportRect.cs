using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "Camera",   
	       description = "Where on the screen is the camera rendered in normalized coordinates.",
	       url = "http://docs.unity3d.com/ScriptReference/Camera-rect.html")]
	[System.Serializable]
	public  class SetViewportRect : CameraAction {
		[Tooltip("Rect to set.")]
		public Rect rect;
		
		public override void OnEnter (){
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			camera.rect = rect;
		}
	}
}