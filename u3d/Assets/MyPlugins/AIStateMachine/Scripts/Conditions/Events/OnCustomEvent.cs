using UnityEngine;
using StateMachine.Action;
using System;

namespace StateMachine.Condition.UEvent{
	[Info (category = "Event",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class OnCustomEvent : StateCondition {
		[InspectorLabel("Event")]
		[Tooltip("Event that is received using StateMachine.SendEvent")]
		public StringParameter _event;
		[Compound(0)]
		[Compound(1,"intParameter")]
		[Compound(2,"floatParameter")]
		[Compound(3,"stringParameter")]
		[Compound(4,"objectParameter")]
		public MessageParameterType parameterType;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Send the event with a float parameter.")]
		public FloatParameter floatParameter;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Send the event with a int parameter.")]
		public IntParameter intParameter;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Send the event with a string parameter.")]
		public StringParameter stringParameter;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Send the event with a Object parameter.")]
		public ObjectParameter objectParameter;

		private bool isTrigger;
		
		public override void OnEnter ()
		{
			stateMachine.behaviour.onReceiveEvent+=OnTrigger;
		}
		
		public override void OnExit ()
		{
			//if (isTrigger) {
				stateMachine.behaviour.onReceiveEvent -= OnTrigger;
			//}
			isTrigger = false;
		}
		
		private void OnTrigger(string eventName,object parameter){
			if (_event.Value == eventName) {
				switch (parameterType)
				{
				case MessageParameterType.Float:
					floatParameter.Value=(float)parameter;
					break;
				case MessageParameterType.Int:
					intParameter.Value=(int)parameter;
					break;
				case MessageParameterType.Object:
					objectParameter.Value=(UnityEngine.Object)parameter;
					break;
				case MessageParameterType.String:
					stringParameter.Value=(string)parameter;
					break;
				}
				isTrigger = true;
			}
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