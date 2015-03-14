using UnityEngine;
using System.Collections;

namespace StateMachine.Condition{
	[Info (category = "GameObject",   
	       description = "Checks the distance between two game objects.",
	       url = "")]
	[System.Serializable]
	public class Distance : StateCondition {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("First game object to test.")]
		public ObjectParameter first;
		[Tooltip("Position to make the distance check towards.")]
		public Vector3Parameter secondPosition;
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.None,false)]
		[Tooltip("Second game object to test.")]
		public ObjectParameter second;
		[Tooltip("Is the distance greater or less?")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FloatParameter value;

		public override void OnEnter ()
		{
			if (first.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter "+first.Name +" in condition "+GetType().ToString()+" is null. Condition disabled!");
				return;
			}
		}

		public override bool Validate ()
		{
			Vector3 position = secondPosition != null ? secondPosition.Value : Vector3.zero;
			if (!second.isNone && second.Value != null) {
				position =((GameObject)second.Value).transform.position;
			}
			float distance = Vector3.Distance (((GameObject)first.Value).transform.position, position);

			switch (comparer) {
			case FloatComparer.Less:
				return distance < value.Value;
			case FloatComparer.Greater:
				return distance > value.Value;
			}
			return false;
		}
	}
}