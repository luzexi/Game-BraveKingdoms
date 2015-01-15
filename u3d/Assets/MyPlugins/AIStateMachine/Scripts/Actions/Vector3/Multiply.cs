using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Vector/Vector3", 
	       description = "Multiplies a vector by a number.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Vector3-operator_multiply.html")]
	[System.Serializable]
	public class Multiply : StateAction {
		[Tooltip("Vector3 value.")]
		public Vector3Parameter vector;
		[Tooltip("Float value to multiply with.")]
		public FloatParameter a;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public Vector3Parameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = vector.Value*a.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = vector.Value*a.Value;
		}
	}
}