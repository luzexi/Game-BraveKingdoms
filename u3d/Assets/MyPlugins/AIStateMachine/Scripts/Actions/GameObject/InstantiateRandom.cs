using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine.Action{
	[Info (category = "GameObject",    
	       description = "Clones a random object from the originals list.",
	       url = "https://docs.unity3d.com/Documentation/ScriptReference/Object.Instantiate.html")]
	[System.Serializable]
	public class InstantiateRandom : StateAction {
		[Tooltip("An existing object that you want to make a copy of.")]
		public List<GameObject> originals;
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
			if (originals.Count == 0) {
				enabled=false;
				Debug.Log("Could not execute "+ GetType().ToString()+", because the originlas list is empty. Action disabled!");
				return;
			}
			if (target != null && !target.isNone && target.Value != null) {
				store.Value = Instantiate (originals[Random.Range(0,originals.Count)], ((GameObject)target.Value).transform.position, Quaternion.Euler (rotation.Value));
			} else {
				store.Value = Instantiate (originals[Random.Range(0,originals.Count)], position.Value, Quaternion.Euler (rotation.Value));
			}
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			if (target != null && !target.isNone && target.Value != null) {
				store.Value = Instantiate (originals[Random.Range(0,originals.Count)], ((GameObject)target.Value).transform.position, Quaternion.Euler (rotation.Value));
			} else {
				store.Value = Instantiate (originals[Random.Range(0,originals.Count)], position.Value, Quaternion.Euler (rotation.Value));
			}
		}
	}
}