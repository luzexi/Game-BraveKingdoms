using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine.Action{
	[Info (category = "GameObject",  
	       description = "Finds the closest game object to the target game object.",
	       url = "")]
	[System.Serializable]
	public class FindClosestByName : GameObjectAction {
		[Tooltip("The name of the game object.")]
		public StringParameter _name;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public ObjectParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			if (string.IsNullOrEmpty (_name.Value)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the name parameter is empty. Action disabled!");
				return;
			}
			store.Value = FindByName ((GameObject)gameObject.Value, _name.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = FindByName ((GameObject)gameObject.Value, _name.Value);
		}
		
		private GameObject FindByName(GameObject target, string name){
			Transform[] transforms=GameObject.FindObjectsOfType<Transform>();
			List<GameObject> gos=transforms.Select(x=>x.gameObject).Where(y=>y.name== name).ToList();

			GameObject closest=null; 
			float distance = Mathf.Infinity; 
			Vector3 position = target.transform.position; 
			foreach (GameObject go in gos)  { 
				Vector3 diff = (go.transform.position - position);
				float curDistance = diff.sqrMagnitude; 
				if (curDistance < distance && go.transform != target.transform) { 
					closest = go; 
					distance = curDistance; 
				} 
			} 
			return closest;
		}
	}
}