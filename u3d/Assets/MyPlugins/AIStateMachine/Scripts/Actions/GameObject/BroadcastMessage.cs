using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "GameObject",  
	       description = "Calls the method named methodName on every MonoBehaviour in this game object or any of its children.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/GameObject.BroadcastMessage.html")]
	[System.Serializable]
	public class BroadcastMessage : GameObjectAction {
		[Tooltip("The name of the method to call.")]
		public StringParameter methodName;
		[Compound(0)]
		[Compound(1,"intParameter")]
		[Compound(2,"floatParameter")]
		[Compound(3,"stringParameter")]
		[Compound(4,"objectParameter")]
		[Tooltip("Use this option to send one of the following parameters inside the BroadcastMessage. Please note that only one parameter can be send. Use None to not use a parameter at all.")]
		public MessageParameterType parameterType;
		[HideInInspector]
		[Tooltip("Send the message with a float parameter.")]
		public FloatParameter floatParameter;
		[HideInInspector]
		[Tooltip("Send the message with a int parameter.")]
		public IntParameter intParameter;
		[HideInInspector]
		[Tooltip("Send the message with a string parameter.")]
		public StringParameter stringParameter;
		[HideInInspector]
		[Tooltip("Send the message with a Object parameter.")]
		public ObjectParameter objectParameter;

		[Tooltip("Should an error be raised if the method doesn't exist on the target object?")]
		public SendMessageOptions options;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			if (string.IsNullOrEmpty (methodName.Value)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the methodName parameter is empty. Action disabled!");
				return;
			}
			DoSendMessage ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoSendMessage ();
		}

		private void DoSendMessage(){
			switch (parameterType)
			{
			case MessageParameterType.Float:
				((GameObject)gameObject.Value).BroadcastMessage (methodName.Value,floatParameter.Value, options);
				break;
			case MessageParameterType.Int:
				((GameObject)gameObject.Value).BroadcastMessage (methodName.Value,intParameter.Value, options);
				break;
			case MessageParameterType.Object:
				((GameObject)gameObject.Value).BroadcastMessage (methodName.Value,objectParameter.Value, options);
				break;
			case MessageParameterType.String:
				((GameObject)gameObject.Value).BroadcastMessage (methodName.Value,stringParameter.Value, options);
				break;
			default:
				((GameObject)gameObject.Value).BroadcastMessage (methodName.Value, options);
				break;
			}
		}
	}
}