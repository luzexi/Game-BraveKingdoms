using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Convert",   
	       description = "Converts a string value to an int.",
	       url = "")]
	[System.Serializable]
	public class StringToInt : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("String value to check.")]
		public StringParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Int parameter to store.")]
		public IntParameter store;
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
			store.Value = int.Parse (value.Value);
		}
	}
}