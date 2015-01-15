using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "Returns a raised to the specified power.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.Exp.html")]
	[System.Serializable]
	public class Exp : StateAction {
		[Tooltip("The value to use.")]
		public FloatParameter power;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.Exp (power.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Exp (power.Value);
		}
	}
}