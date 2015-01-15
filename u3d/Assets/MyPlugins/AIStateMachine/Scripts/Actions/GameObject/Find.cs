using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine.Action{
	[Info (category = "GameObject",    
	       description = "Finds a game object by name.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/GameObject.Find.html")]
	[System.Serializable]
	public class Find : StateAction {
		[InspectorLabel("Name")]
		[Tooltip("The name of the game object to find.")]
		public StringParameter _name;
		[Tooltip("Should inactive GameObjects be included into the search?")]
		public BoolParameter includeInactive;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public ObjectParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = DoFind ();//GameObject.Find (_name.Value);
			if (!everyFrame) {
				Finish ();		
			}
		}

		public override void OnUpdate ()
		{
			store.Value = DoFind ();//GameObject.Find (_name.Value);

		}

		private GameObject DoFind(){
			GameObject go = GameObject.Find (_name.Value);
			if (includeInactive != null && includeInactive.Value && go == null) {
				Transform[] gos= UnityTools.FindAll<Transform>(true);
				foreach(Transform tr in gos){
					if(tr.name== _name.Value){
						return tr.gameObject;
					}
				}
			}
			return go;
		}


	}
}