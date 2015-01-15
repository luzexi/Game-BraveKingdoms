using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Convert",   
	       description = "Converts a string value to a float.",
	       url = "")]
	[System.Serializable]
	public class StringToFloat : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("String value to check.")]
		public StringParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Float parameter to store.")]
		public FloatParameter store;
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
			store.Value = float.Parse (value.Value);
		}
	}
}