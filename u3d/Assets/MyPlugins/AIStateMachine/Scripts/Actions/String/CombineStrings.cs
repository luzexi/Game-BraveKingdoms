using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "String",   
	       description = "Combines two strings into one.",
	       url = "")]
	[System.Serializable]
	public class CombineStrings : StateAction {
		[Tooltip("The first string to use.")]
		public StringParameter first;
		[Tooltip("The second string.")]
		public StringParameter second;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public StringParameter store;

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