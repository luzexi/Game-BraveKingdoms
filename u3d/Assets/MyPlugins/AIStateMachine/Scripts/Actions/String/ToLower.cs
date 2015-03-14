using UnityEngine;
using System.Collections;
using System;

namespace StateMachine.Action{
	[Info (category = "String",   
	       description = "Returns a copy of this string converted to lowercase.",
	       url = "http://msdn.microsoft.com/en-us/library/e78f86at(v=vs.110).aspx")]
	[System.Serializable]
	public class ToLower : StateAction {
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
			store.Value = value.Value.ToLower ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = value.Value.ToLower ();
		}
	}
}