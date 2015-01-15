using UnityEngine;
using System.Collections;

namespace StateMachine.Action.Math{
	[Info (category = "Math",   
	       description = "Interpolates between a and b.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Mathf.Lerp.html")]
	[System.Serializable]
	public class Lerp : StateAction {
		[Tooltip("Interpolate from.")]
		public FloatParameter from;
		[Tooltip("Interpolate to.")]
		public FloatParameter to;
		[Tooltip("Speed.")]
		public FloatParameter speed;

		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
	
		public override void OnUpdate ()
		{
			if (speed != null) {
				store.Value = Mathf.Lerp (from.Value, to.Value, Time.deltaTime*speed.Value);
			} else {
				store.Value = Mathf.Lerp (from.Value, to.Value, Time.deltaTime);
			}
		}
	}
}