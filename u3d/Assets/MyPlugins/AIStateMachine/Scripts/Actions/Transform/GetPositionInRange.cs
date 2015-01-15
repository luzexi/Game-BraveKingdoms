using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Transform",  
	       description = "Get a Vector3 position in range of the gameObject.",
	       url = "")]
	[System.Serializable]
	public class GetPositionInRange : GameObjectAction {
		[Tooltip("Range of the Vector3.")]
		public FloatParameter range;
		[Tooltip("Randomize y component?")]
		public BoolParameter setY;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public Vector3Parameter store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			Vector3 position = ((GameObject)gameObject.Value).transform.position;
			Vector3 inRange = new Vector3 (position.x + Random.Range (-range.Value, range.Value),
			                               position.y+(setY.Value?Random.Range(-range.Value, range.Value):0),
			                               position.z + Random.Range (-range.Value, range.Value)
			                               );
			store.Value = inRange;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			Vector3 position = ((GameObject)gameObject.Value).transform.position;
			Vector3 inRange = new Vector3 (position.x + Random.Range (-range.Value, range.Value),
			                               position.y+(setY.Value?Random.Range(-range.Value, range.Value):0),
			                               position.z + Random.Range (-range.Value, range.Value)
			                               );
			store.Value = inRange;
		}
	}
}