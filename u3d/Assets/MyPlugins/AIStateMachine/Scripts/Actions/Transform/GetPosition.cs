using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Transform",   
	       description = "The position of the transform in world space.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Transform-position.html")]
	[System.Serializable]
	public class GetPosition : GameObjectAction {
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the result.")]
		public Vector3Parameter store;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the x componet.")]
		public FloatParameter x;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the y componet.")]
		public FloatParameter y;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the z componet.")]
		public FloatParameter z;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			store.Value = ((GameObject)gameObject.Value).transform.position;
			if(x != null)
				x.Value = store.Value.x;
			if(y != null)
				y.Value = store.Value.y;
			if(z != null)
				z.Value = store.Value.z;

			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = ((GameObject)gameObject.Value).transform.position;
			if(x != null)
				x.Value = store.Value.x;
			if(y != null)
				y.Value = store.Value.y;
			if(z != null)
				z.Value = store.Value.z;
		}
	}
}