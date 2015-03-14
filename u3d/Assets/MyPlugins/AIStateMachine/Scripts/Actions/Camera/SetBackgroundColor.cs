using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "Camera",   
	       description = "Sets the background color of a camera component.",
	       url = "")]
	[System.Serializable]
	public  class SetBackgroundColor : CameraAction {
		[Tooltip("Color to to set")]
		public ColorParameter color;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter (){
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			camera.backgroundColor = color.Value;
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			camera.backgroundColor = color.Value;
		}
	}
}