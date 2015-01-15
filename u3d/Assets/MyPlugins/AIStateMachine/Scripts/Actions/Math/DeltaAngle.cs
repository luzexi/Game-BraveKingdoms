using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "Calculates the shortest difference between two given angles.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.DeltaAngle.html")]
	[System.Serializable]
	public class DeltaAngle : StateAction {
		[Tooltip("Current angle")]
		public FloatParameter current;
		[Tooltip("Target angle")]
		public FloatParameter target;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.DeltaAngle (current.Value, target.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.DeltaAngle (current.Value, target.Value);
		}
	}
}