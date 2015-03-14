using UnityEngine;
using System.Collections;

namespace StateMachine.Condition.UEvent{
	[Info (category = "Event",    
	       description = "Unity messages that are sended.",
	       url = "http://docs.unity3d.com/ScriptReference/MonoBehaviour.html")]
	[System.Serializable]
	public class OnUnityEvent : StateCondition {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("GameObject to use.")]
		public ObjectParameter gameObject;
		public UnityEventTrigger.EventType type;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the other GameObject or self on mouse events.")]
		public ObjectParameter store;

		private UnityEventTrigger handler;
		private bool isTrigger;
		
		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter "+gameObject.Name +" in condition "+GetType().ToString()+" is null. Condition disabled!");
				return;
			}

			handler = ((GameObject)gameObject.Value).AddComponent<UnityEventTrigger>();	
			handler.type = type;
			handler.onTrigger+=OnTrigger;
		}
		
		public override void OnExit ()
		{
			if (isTrigger) {
				handler.onTrigger -= OnTrigger;
			}
			isTrigger = false;
		}
		
		private void OnTrigger(GameObject other){
			isTrigger = true;
			store.Value = other;
		}
		
		public override bool Validate ()
		{
			if (isTrigger) {
				isTrigger=false;	
				return true;
			}
			return isTrigger;
		}
	}
}