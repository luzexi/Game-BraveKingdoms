using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Convert",   
	       description = "Converts a Bool value to a string.",
	       url = "")]
	[System.Serializable]
	public class BoolToString : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Bool value to check.")]
		public BoolParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("String to store.")]
		public StringParameter store;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("String if value is true.")]
		[DefaultValueAttribute("True")]
		public StringParameter trueString;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("String if value is false.")]
		[DefaultValueAttribute("False")]
		public StringParameter falseString;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			DoConvert ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoConvert ();
		}
		
		private void DoConvert(){
			store.Value = value.Value ? trueString.Value : falseString.Value;
		}
	}
}