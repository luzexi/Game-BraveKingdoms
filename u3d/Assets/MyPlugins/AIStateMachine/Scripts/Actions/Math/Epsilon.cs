using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "A tiny floating point value.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.Epsilon.html")]
	[System.Serializable]
	public class Epsilon : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.Epsilon;
		}
	}
}