using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "GameObject",    
	       description = "Makes the object target not be destroyed automatically when loading a new scene.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Object.DontDestroyOnLoad.html")]
	[System.Serializable]
	public class DontDestroyOnLoad : GameObjectAction {
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			GameObject.DontDestroyOnLoad (((GameObject)gameObject.Value));
			Finish ();
		}
	}
}