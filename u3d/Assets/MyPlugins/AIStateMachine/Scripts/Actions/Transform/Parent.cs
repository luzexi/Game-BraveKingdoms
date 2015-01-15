using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Transform",    
	       description = "Parents the GameObject to target.",
	       url = "")]
	[System.Serializable]
	public class Parent : GameObjectAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		//[FieldInfo(requiredField=false, canBeConstant=false,nullLabel="Null", tooltip="")]
		public ObjectParameter target;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			Transform gameObjectTransform = ((GameObject)gameObject.Value).transform;

			Transform targetTransform =target.Value != null? ((GameObject)target.Value).transform:null;

			gameObjectTransform.parent= targetTransform;
			
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			Transform gameObjectTransform = ((GameObject)gameObject.Value).transform;
			Transform targetTransform = ((GameObject)target.Value).transform;
			gameObjectTransform.parent= targetTransform;
		}
	}
}