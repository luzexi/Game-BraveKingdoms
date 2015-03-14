using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math",  
	       description = "Subtracts the value of one expression from another.",
	       url = "http://msdn.microsoft.com/en-us/library/wch5w409.aspx")]
	[System.Serializable]
	public class Subtract : StateAction {
		[Tooltip("First operand.")]
		public FloatParameter first;
		[Tooltip("Second operand.")]
		public FloatParameter second;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = first.Value - second.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = first.Value - second.Value;
		}
	}
}