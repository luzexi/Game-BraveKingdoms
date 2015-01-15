using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Convert",   
	       description = "Converts a Bool value to an int.",
	       url = "")]
	[System.Serializable]
	public class BoolToInt : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Bool value to check.")]
		public BoolParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Int parameter to store.")]
		public IntParameter store;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Int if value is true.")]
		[DefaultValueAttribute(1)]
		public IntParameter trueInt;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Int if value is false.")]
		[DefaultValueAttribute(0)]
		public IntParameter falseInt;
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
			store.Value = value.Value ? trueInt.Value : falseInt.Value;
		}
	}
}