using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Parameter",   
	       description = "Sets the value of a global parameter.",
	       url = "")]
	[System.Serializable]
	public class SetInt : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("The parameter to use.")]
		public IntParameter parameter;
		[Tooltip("The value to set.")]
		public IntParameter value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			parameter.Value = value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			parameter.Value = value;
		}
	}
}