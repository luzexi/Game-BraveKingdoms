using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "A representation of positive infinity.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.Infinity.html")]
	[System.Serializable]
	public class Infinity : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.Infinity;
		}
	}
}