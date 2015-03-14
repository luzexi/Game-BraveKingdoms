using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Input",   
	       description = "Returns object representing status of a specific touch. ",
	       url = "http://docs.unity3d.com/ScriptReference/Input.GetTouch.html")]
	[System.Serializable]
	public class GetTouch: StateAction {
		[Tooltip("Touch index.")]
		public IntParameter fingerId;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the position.")]
		public Vector2Parameter position;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the deltaPosition.")]
		public Vector2Parameter deltaPosition;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the tap count.")]
		public IntParameter tapCount;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the delta time.")]
		public FloatParameter deltaTime;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			DoGetTouchInfo ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoGetTouchInfo ();
		}

		private void DoGetTouchInfo(){
			if (Input.touchCount > 0)
			{
				foreach (var touch in Input.touches)
				{
					if (touch.fingerId == fingerId.Value)
					{
						position.Value =touch.position;
						deltaPosition.Value = touch.deltaPosition;
						deltaTime.Value = touch.deltaTime;
						tapCount.Value = touch.tapCount;
					}
				}
			}
		}
	}
}