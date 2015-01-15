using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "GameObject",  
	       description = "Activates/Deactivates the GameObject.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/GameObject.SetActive.html")]
	[System.Serializable]
	public class SetActive : GameObjectAction {
		[Tooltip("The value to use.")]
		public BoolParameter value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			((GameObject)gameObject.Value).SetActive(value.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			((GameObject)gameObject.Value).SetActive(value.Value);
		}
	}
}