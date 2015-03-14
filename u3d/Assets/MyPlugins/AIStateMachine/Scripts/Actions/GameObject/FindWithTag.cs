using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "GameObject",   
	       description = "Finds a game object by tag.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/GameObject.FindWithTag.html")]
	[System.Serializable]
	public class FindWithTag : StateAction {
		[Tooltip("The tag to find.")]
		public StringParameter tag;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public ObjectParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			if (string.IsNullOrEmpty (tag.Value)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the tag parameter is empty. Action disabled!");
				return;
			}
			store.Value = GameObject.FindWithTag (tag.Value);
			if(!everyFrame){
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = GameObject.FindWithTag (tag.Value);
		}
	}
}