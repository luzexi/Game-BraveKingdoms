using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Convert",   
	       description = "Converts a Bool value to a Vector2.",
	       url = "")]
	[System.Serializable]
	public class BoolToVector2 : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Bool value to check.")]
		public BoolParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Vector2 parameter to store.")]
		public Vector2Parameter store;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Vector2 if value is true.")]
		public Vector2Parameter trueVector;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Vector2 if value is false.")]
		public Vector2Parameter falseVector;
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
			store.Value = value.Value ? trueVector.Value : falseVector.Value;
		}
	}
}