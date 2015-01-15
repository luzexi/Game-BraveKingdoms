using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Convert",   
	       description = "Converts a Bool value to a Color.",
	       url = "")]
	[System.Serializable]
	public class BoolToColor : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Bool value to check.")]
		public BoolParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Color parameter to store.")]
		public ColorParameter store;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Color if value is true.")]
		public ColorParameter trueColor;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Color if value is false.")]
		public ColorParameter falseColor;
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
			store.Value = value.Value ? trueColor.Value : falseColor.Value;
		}
	}
}