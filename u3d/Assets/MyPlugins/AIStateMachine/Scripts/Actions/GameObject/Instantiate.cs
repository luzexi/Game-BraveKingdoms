using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "GameObject",    
	       description = "Clones the object original.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Object.Instantiate.html")]
	[System.Serializable]
	public class Instantiate : StateAction {
		[Tooltip("An existing object that you want to make a copy of.")]
		public ObjectParameter original;
		[Tooltip("Position for the new object.")]
		public Vector3Parameter position;
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.None,false)]
		[Tooltip("Optional instantiates at targets position.")]
		public ObjectParameter target;
		[Tooltip("Orientation of the new object.")]
		public Vector3Parameter rotation;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip( "Instantiated clone of the original.")]
		public ObjectParameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			if (original.Value== null) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the Object to instantiate is null. Action disabled!");
				return;
			}
			if (target != null && !target.isNone && target.Value != null) {
				store.Value = Instantiate (original.Value, ((GameObject)target.Value).transform.position, Quaternion.Euler (rotation.Value));
			} else {
				store.Value = Instantiate (original.Value, position.Value, Quaternion.Euler (rotation.Value));
			}
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			if (target != null && !target.isNone && target.Value != null) {
				store.Value = Instantiate (original.Value, ((GameObject)target.Value).transform.position, Quaternion.Euler (rotation.Value));
			} else {
				store.Value = Instantiate (original.Value, position.Value, Quaternion.Euler (rotation.Value));
			}
		}
	}
}