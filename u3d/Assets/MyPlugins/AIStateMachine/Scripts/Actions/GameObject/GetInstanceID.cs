using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "GameObject",  
	       description = "Gets the InstanceID of an Object.",
	       url = "")]
	[System.Serializable]
	public class GetInstanceID : GameObjectAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("InstanceID to store")]
		public IntParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			store.Value= ((GameObject)gameObject.Value).GetInstanceID ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value= ((GameObject)gameObject.Value).GetInstanceID ();
		}
	}
}