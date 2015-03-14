using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Application",  
	       description = "Opens the url in a browser.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Application.OpenURL.html")]
	[System.Serializable]
	public class OpenURL : StateAction {
		[Tooltip("Url to open.")]
		public StringParameter url;
		
		public override void OnEnter ()
		{
			if (string.IsNullOrEmpty (url.Value)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the url is empty. Action disabled!");
				return;
			}
			Application.OpenURL (url.Value);
			Finish ();
		}
	}
}