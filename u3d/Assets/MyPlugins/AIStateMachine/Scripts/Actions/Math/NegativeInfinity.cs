using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "A representation of negative infinity",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.NegativeInfinity.html")]
	[System.Serializable]
	public class NegativeInfinity : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.NegativeInfinity;
		}
	}
}