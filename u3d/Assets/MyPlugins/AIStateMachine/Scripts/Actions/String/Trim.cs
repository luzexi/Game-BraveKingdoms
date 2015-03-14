using UnityEngine;
using System.Collections;
using System;

namespace StateMachine.Action{
	[Info (category = "String",   
	       description = "Removes all leading and trailing white-space characters from the current String object.",
	       url = "http://msdn.microsoft.com/en-us/library/t97s7bs3(v=vs.110).aspx")]
	[System.Serializable]
	public class Trim : StateAction {
		[Tooltip("The string to use.")]
		public StringParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public StringParameter store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = value.Value.Trim ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = value.Value.Trim ();
		}
	}
}