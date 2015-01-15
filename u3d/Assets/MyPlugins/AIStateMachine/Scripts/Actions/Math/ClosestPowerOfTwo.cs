using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "Returns the closest power of two value.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.ClosestPowerOfTwo.html")]
	[System.Serializable]
	public class ClosestPowerOfTwo : StateAction {
		[Tooltip("The value to use.")]
		public IntParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public IntParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.ClosestPowerOfTwo (value.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.ClosestPowerOfTwo (value.Value);
		}
	}
}