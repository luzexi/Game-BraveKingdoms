using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Input",   
	       description = "Last measured linear acceleration of a device in three-dimensional space.",
	       url = "http://docs.unity3d.com/ScriptReference/Input-acceleration.html")]
	[System.Serializable]
	public class GetAcceleration : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public Vector3Parameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Input.acceleration;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Input.acceleration;	
		}
	}
}