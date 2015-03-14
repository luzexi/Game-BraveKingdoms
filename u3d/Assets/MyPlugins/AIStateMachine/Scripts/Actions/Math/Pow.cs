using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "Returns f raised to power p.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.Pow.html")]
	[System.Serializable]
	public class Pow : StateAction {
		public FloatParameter f;
		public FloatParameter p;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.Pow (f.Value,p.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Pow (f.Value,p.Value);
		}
	}
}