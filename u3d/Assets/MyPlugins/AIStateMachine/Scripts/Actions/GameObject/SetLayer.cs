using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "GameObject", 
	       description = "Set the layer of the game object.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/GameObject-layer.html")]
	[System.Serializable]
	public class SetLayer : GameObjectAction {
		[Tooltip("The new layer to set.")]
		public IntParameter layer;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			((GameObject)gameObject.Value).layer = layer.Value;
			if (!everyFrame){
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			((GameObject)gameObject.Value).layer = layer.Value;

		}
	}
}