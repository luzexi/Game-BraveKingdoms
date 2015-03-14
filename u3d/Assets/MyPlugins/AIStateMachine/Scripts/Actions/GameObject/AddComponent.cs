using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "GameObject",   
	       description = "Adds a component class named className to the game object.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/GameObject.AddComponent.html")]
	[System.Serializable]
	public class AddComponent : GameObjectAction {
		[Tooltip("The name of the class to add.")]
		public StringParameter className;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip ("Store the component.")]
		public ObjectParameter store;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			if (string.IsNullOrEmpty(className.Value)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the className parameter is empty. Action disabled!");
				return;
			}
			Component component = ((GameObject)gameObject.Value).GetComponent (className.Value);
			if (component == null) {
				store.Value = ((GameObject)gameObject.Value).AddComponent (className.Value);
			} else {
				store.Value=component;		
			}
			Finish ();
		}
	}
}