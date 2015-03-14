using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Application",   
	       description = "Is Unity activated with the Pro license?",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Application.HasProLicense.html")]
	[System.Serializable]
	public class HasProLicense : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Result to store.")]
		public BoolParameter store;
		
		public override void OnEnter ()
		{
			store.Value = Application.HasProLicense ();
			Finish ();
		}
		
	}
}