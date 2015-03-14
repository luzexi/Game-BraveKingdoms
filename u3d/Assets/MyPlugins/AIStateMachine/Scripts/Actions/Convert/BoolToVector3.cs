using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Convert",   
	       description = "Converts a Bool value to a Vector3.",
	       url = "")]
	[System.Serializable]
	public class BoolToVector3 : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Bool value to check.")]
		public BoolParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Vector3 parameter to store.")]
		public Vector3Parameter store;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Vector3 if value is true.")]
		public Vector3Parameter trueVector;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Vector3 if value is false.")]
		public Vector3Parameter falseVector;
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