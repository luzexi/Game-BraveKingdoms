using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Parameter", 
	       description = "Animates a float value using an AnimationCurve",
	       url = "")]
	[System.Serializable]
	public class AnimateFloat : StateAction {
		[Tooltip("The animation curve to use.")]
		public AnimationCurve curve;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Result to store.")]
		public FloatParameter store;
		[Tooltip("Ignore TimeScale if true.")]
		public BoolParameter realTime;
		private float startTime;
		private float currentTime;
		private float endTime;

		public override void OnEnter ()
		{
			base.OnEnter ();
			startTime = Time.realtimeSinceStartup;
			currentTime = 0f;
			
			if (curve.keys.Length > 0){
				endTime = curve.keys[curve.length-1].time;
			}else{
				Finish();
				return;
			}
			
			store.Value = curve.Evaluate(0);

		}
		
		public override void OnUpdate ()
		{
			if (realTime.Value)
			{
				currentTime = Time.realtimeSinceStartup - startTime;
			}else{
				currentTime += Time.deltaTime;
			}

			store.Value = curve.Evaluate(currentTime);
			if (currentTime >= endTime) {
				Finish();
			}
		}
	}
}