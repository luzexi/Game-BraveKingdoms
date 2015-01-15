using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "GameObject",    
	       description = "Finds the child by name.",
	       url = "")]
	[System.Serializable]
	public class FindChild : GameObjectAction {
		[InspectorLabel("Name")]
		[Tooltip("The name of the child game object to find.")]
		public StringParameter _name;

		public bool includeInactive=true;
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
			store.Value = FindChildByName ((GameObject)gameObject.Value, _name.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = FindChildByName ((GameObject)gameObject.Value, _name.Value);
		}

		private GameObject FindChildByName(GameObject target, string name)
		{
			if (target != null) {
				if (target.name == name && includeInactive || target.name == name && !includeInactive && target.activeInHierarchy) {
					return target;
				}
				for (int i = 0; i < target.transform.childCount; ++i) {
					GameObject result = FindChildByName (target.transform.GetChild (i).gameObject, name);
					
					if (result != null) 
						return result;
				}
			}
			return null;
		}
	}
}