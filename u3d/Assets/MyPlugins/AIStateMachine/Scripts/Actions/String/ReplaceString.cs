using UnityEngine;
using System.Collections;
using System;

namespace StateMachine.Action{
	[Info (category = "String",   
	       description = "Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.",
	       url = "http://msdn.microsoft.com/en-us/library/czx8s9ts(v=vs.110).aspx")]
	[System.Serializable]
	public class ReplaceString : StateAction {
		[Tooltip("The string to use.")]
		public StringParameter value;
		[Tooltip("The string to be replaced.")]
		public StringParameter oldValue;
		[Tooltip("The string to replace all occurrences of oldChar.")]
		public StringParameter newValue;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public StringParameter store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = value.Value.Replace (oldValue.Value, newValue.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = value.Value.Replace (oldValue.Value, newValue.Value);
		}
	}
}