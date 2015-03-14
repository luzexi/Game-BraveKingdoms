using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "Camera",   
	       description = "Sets the field of view of a camera component.",
	       url = "")]
	[System.Serializable]
	public  class SetFieldOfView : CameraAction {
		[Tooltip("Value to set.")]
		public FloatParameter fieldOfView;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter (){
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			camera.fieldOfView = fieldOfView.Value;
			if (!everyFrame) {
				Finish();			
			}
		}
		
		public override void OnUpdate ()
		{
			camera.fieldOfView = fieldOfView.Value;
		}
	}
}