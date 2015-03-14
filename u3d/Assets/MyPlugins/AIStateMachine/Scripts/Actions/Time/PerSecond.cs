using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Time",    
	       description = "Multiplies a float by Time.deltaTime to use in frame-rate independent operations.",
	       url = "")]
	[System.Serializable]
	public class PerSecond : StateAction {
		[Tooltip("Value to set.")]
		public FloatParameter value;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			store.Value = Time.deltaTime * value.Value;	
		}	

		public override void OnUpdate ()
		{
			store.Value = Time.deltaTime * value.Value;	
		}
	}
}