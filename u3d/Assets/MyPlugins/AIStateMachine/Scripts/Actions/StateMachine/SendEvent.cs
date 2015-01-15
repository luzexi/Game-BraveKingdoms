using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "StateMachine",    
	       description = "Sends an event to the state machine. Can be checked in condition OnCustomEvent.",
	       url = "")]
	[System.Serializable]
	public class SendEvent : StateAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("The game object to use.")]
		public ObjectParameter gameObject;
		[InspectorLabel("Event")]
		[Tooltip("Event name to send.")]
		public StringParameter _event;
		[Compound(0)]
		[Compound(1,"intParameter")]
		[Compound(2,"floatParameter")]
		[Compound(3,"stringParameter")]
		[Compound(4,"objectParameter")]
		[Tooltip("Use this option to send one of the following parameters inside the SendEvent. Please note that only one parameter can be send. Use None to not use a parameter at all.")]
		public MessageParameterType parameterType;
		[HideInInspector]
		[Tooltip("Send the event with a float parameter.")]
		public FloatParameter floatParameter;
		[HideInInspector]
		[Tooltip("Send the event with a int parameter.")]
		public IntParameter intParameter;
		[HideInInspector]
		[Tooltip("Send the event with a string parameter.")]
		public StringParameter stringParameter;
		[HideInInspector]
		[Tooltip("Send the event with a Object parameter.")]
		public ObjectParameter objectParameter;

		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}

			GameObject behaviorGameObject = (GameObject)gameObject.Value;
			// Find the correct behavior tree based on the grouping
			var behaviorComponents = behaviorGameObject.GetComponents<StateMachineBehaviour>();
			if (behaviorComponents != null && behaviorComponents.Length > 0) {
				for (int i = 0; i < behaviorComponents.Length; ++i) {
					switch (parameterType)
					{
					case MessageParameterType.Float:
						behaviorComponents[i].SendEvent(_event.Value,floatParameter.Value);
						break;
					case MessageParameterType.Int:
						behaviorComponents[i].SendEvent(_event.Value,intParameter.Value);
						break;
					case MessageParameterType.Object:
						behaviorComponents[i].SendEvent(_event.Value,objectParameter.Value);
						break;
					case MessageParameterType.String:
						behaviorComponents[i].SendEvent(_event.Value,stringParameter.Value);
						break;
					default:
						behaviorComponents[i].SendEvent(_event.Value, null);
						break;
					}
				}

			}
		}
	}
}