using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "The infamous 3.14159265358979... value.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.PI.html")]
	[System.Serializable]
	public class PI : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.PI;
		}
	}
}