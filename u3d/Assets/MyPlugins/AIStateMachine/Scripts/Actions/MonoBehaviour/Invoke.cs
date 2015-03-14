using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

namespace StateMachine.Action.Math{
	[Info (category = "MonoBehaviour", 
	       description = "Invokes the method methodName.",
	       url = "http://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html")]

	[System.Serializable]
	public class Invoke : StateAction {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("The game object to use.")]
		public ObjectParameter gameObject;
		[ComponentInfo]
		[Tooltip("The name of the behaviour(script).")]
		public string behaviour;
		[ReflectionInfo("behaviour", ReflectionType.Methods)]
		[Tooltip("The name of the method to call.")]
		public string methodName;
		[Tooltip("Invokes the method after delay in seconds.")]
		public FloatParameter delay;
		[Tooltip("Repeat invoking the method. If set to 0, the method will be invoked once,")]
		public FloatParameter repeatRate;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("["+stateMachine.name+"]"+" GameObject paramter in action "+GetType().ToString()+" is null. If you assigned the parameter in the same state, create a new state, transition to it and execute this action. Action disabled!");
				return;
			}
			MonoBehaviour mono = ((GameObject)gameObject.Value).GetComponent (behaviour) as MonoBehaviour;
			if (mono == null) {
				enabled=false;
				Debug.LogWarning("Missing MonoBehaviour! "+ GetType().ToString()+ " requires the "+behaviour+" script on the GameObject. Action disabled!");
				return;
			}

			if(repeatRate.Value== 0){
				mono.Invoke (methodName, delay);
			}else{
				mono.InvokeRepeating(methodName,delay.Value,repeatRate.Value);
			}

		}
		

	}
}