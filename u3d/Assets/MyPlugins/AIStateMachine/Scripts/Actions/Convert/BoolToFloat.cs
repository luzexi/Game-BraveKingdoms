using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Convert",   
	       description = "Converts a Bool value to a float.",
	       url = "")]
	[System.Serializable]
	public class BoolToFloat : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Bool value to check.")]
		public BoolParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Float parameter to store.")]
		public FloatParameter store;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Float if value is true.")]
		[DefaultValueAttribute(0.5f)]
		public FloatParameter trueFloat;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Float if value is false.")]
		public FloatParameter falseFloat;
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
			store.Value = value.Value ? trueFloat.Value : falseFloat.Value;
		}
	}
}