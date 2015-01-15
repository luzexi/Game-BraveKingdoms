using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math", 
	       description = "Degrees-to-radians conversion constant.",
	       url = "http://docs.unity3d.com/ScriptReference/Mathf.Deg2Rad.html")]
	[System.Serializable]
	public class Deg2Rad : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;

		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Mathf.Deg2Rad;
		}
	}
}