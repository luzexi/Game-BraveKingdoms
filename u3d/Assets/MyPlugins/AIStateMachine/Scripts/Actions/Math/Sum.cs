using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math",  
	       description = "Sums up two values.",
	       url = "http://msdn.microsoft.com/en-us/library/k1a63xkz.aspx")]
	[System.Serializable]
	public class Sum : StateAction {
		[Tooltip("First operand.")]
		public FloatParameter first;
		[Tooltip("Second operand")]
		public FloatParameter second;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = first.Value + second.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = first.Value + second.Value;
		}
	}
}