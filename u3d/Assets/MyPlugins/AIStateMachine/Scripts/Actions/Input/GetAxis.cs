using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Input",   
	       description = "Returns the value of the virtual axis identified by axisName.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Input.GetAxis.html")]
	[System.Serializable]
	public class GetAxis : StateAction {
		[Tooltip("Virtual axis name.")]
		public StringParameter axisName;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public FloatParameter store;

		public override void OnEnter ()
		{
			if (string.IsNullOrEmpty (axisName.Value)) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the axisName parameter is empty. Action disabled!");
			}
			store.Value = Input.GetAxis (axisName.Value);
		}

		public override void OnUpdate ()
		{
			store.Value = Input.GetAxis (axisName.Value);	
		}
	}
}