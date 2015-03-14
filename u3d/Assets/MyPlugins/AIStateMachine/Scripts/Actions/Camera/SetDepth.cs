using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "Camera",   
	       description = "Camera's depth in the camera rendering order. Cameras with lower depth are rendered before cameras with higher depth. Use this to control the order in which cameras are drawn if you have multiple cameras and some of them don't cover the full screen.",
	       url = "http://docs.unity3d.com/ScriptReference/Camera-depth.html")]
	[System.Serializable]
	public  class SetDepth : CameraAction {
		[Tooltip("Depth to set.")]
		public FloatParameter depth;
		
		public override void OnEnter (){
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			camera.depth = depth.Value;
		}
	}
}