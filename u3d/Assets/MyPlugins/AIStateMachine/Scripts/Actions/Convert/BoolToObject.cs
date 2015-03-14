using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Convert",   
	       description = "Converts a Bool value to an Object.",
	       url = "")]
	[System.Serializable]
	public class BoolToObject : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Bool value to check.")]
		public BoolParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Object parameter to store.")]
		public ObjectParameter store;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Object if value is true.")]
		public ObjectParameter trueObject;
		[RequiredField(DefaultReference.Required)]
		[Tooltip("Object if value is false.")]
		public ObjectParameter falseObject;
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
			store.Value = value.Value ? trueObject.Value : falseObject.Value;
		}
	}
}