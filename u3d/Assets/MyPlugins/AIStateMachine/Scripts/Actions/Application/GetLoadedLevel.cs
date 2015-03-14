using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Application",   
	       description = "The name of the level that was last loaded.",
	       url = "http://docs.unity3d.com/ScriptReference/Application-loadedLevelName.html")]
	[System.Serializable]
	public class GetLoadedLevel : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the level name.")]
		public StringParameter _name;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			_name.Value = Application.loadedLevelName;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			_name.Value = Application.loadedLevelName;
		}
	}
}