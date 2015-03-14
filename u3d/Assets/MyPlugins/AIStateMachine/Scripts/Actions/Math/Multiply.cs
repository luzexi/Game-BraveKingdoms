using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math",    
	       description = "Computes the product of its operands",
	       url = "http://msdn.microsoft.com/en-us/library/z19tbbca.aspx")]
	[System.Serializable]
	public class Multiply : StateAction {
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
			store.Value = first.Value * second.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = first.Value * second.Value;
		}
	}
}