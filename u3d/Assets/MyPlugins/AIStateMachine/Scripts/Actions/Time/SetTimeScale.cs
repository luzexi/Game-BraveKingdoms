using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Time",    
	       description = "The scale at which the time is passing. This can be used for slow motion effects.",
	       url = "http://docs.unity3d.com/ScriptReference/Time-timeScale.html")]
	[System.Serializable]
	public class SetTimeScale : StateAction {
		[Tooltip("Value to set.")]
		public FloatParameter timeScale;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			Time.timeScale = timeScale.Value;
			
		}	
	}
}