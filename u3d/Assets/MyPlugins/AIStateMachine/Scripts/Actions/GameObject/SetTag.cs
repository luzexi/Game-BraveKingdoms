using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "GameObject",  
	       description = "Set the tag of the game object.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/GameObject-tag.html")]
	[System.Serializable]
	public class SetTag : GameObjectAction {
		[Tooltip("The new tag to set.")]
		public StringParameter tag;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			if (string.IsNullOrEmpty (tag.Value)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the tag parameter is empty. Action disabled!");
				return;
			}
			((GameObject)gameObject.Value).tag = tag.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			((GameObject)gameObject.Value).tag = tag.Value;
		}
	}
}