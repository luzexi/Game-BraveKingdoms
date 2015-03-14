using UnityEngine;
using System.Collections;

namespace StateMachine.Condition.UnityAnimator{
	[Info (category = "Animator",  
	       description = "Gets the layer's current weight.",
	       url = "http://docs.unity3d.com/ScriptReference/Animator.GetLayerWeight.html")]
	[System.Serializable]
	public class GetLayerWeight: StateCondition {
		[ObjectType(typeof(GameObject))]
		[RequiredField(DefaultReference.Owner,false)]
		[Tooltip("GameObject to test.")]
		public ObjectParameter gameObject;
		[Tooltip("The animator layer to test.")]
		public IntParameter layer;
		[Tooltip("Is the parameter greater or less?")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FloatParameter value;
		
		private Animator animator;
		public override void OnEnter ()
		{
			if (gameObject.Value == null) {
				enabled=false;
				Debug.LogWarning("GameObject paramter "+gameObject.Name +" in condition "+GetType().ToString()+" is null. Condition disabled!");
				return;
			}
			
			animator = ((GameObject)gameObject.Value).GetComponent<Animator> ();
			if (animator == null) {
				enabled=false;
				Debug.LogWarning("Missing Component! "+ GetType().ToString()+ " requires the Animator component on the GameObject. Condition disabled!");
			}
		}
		
		public override bool Validate ()
		{
			float floatValue = animator.GetLayerWeight (layer.Value);
			switch (comparer) {
			case FloatComparer.Less:
				return floatValue < value.Value;
			case FloatComparer.Greater:
				return floatValue > value.Value;
			}
			return false;
		}
	}
}