using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "Camera",   
	       description = "Whether or not the Camera will use occlusion culling during rendering.",
	       url = "http://docs.unity3d.com/ScriptReference/Camera-useOcclusionCulling.html")]
	[System.Serializable]
	public  class UseOcclusionCulling : CameraAction {
		[Tooltip("Value to set.")]
		public BoolParameter value;
		
		public override void OnEnter (){
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			camera.useOcclusionCulling = value.Value;
		}
	}
}