using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "Input",    
	       description = "",
	       url = "")]
	[System.Serializable]
	public class GetMousePosition : StateAction {
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the screen position.")]
		public Vector2Parameter screenPosition;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the screen position x component.")]
		public FloatParameter screenX;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the screen position y component.")]
		public FloatParameter screenY;

		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the world position.")]
		public Vector3Parameter worldPosition;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the world position x component.")]
		public FloatParameter worldX;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the world position y component.")]
		public FloatParameter worldY;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the world position z component")]
		public FloatParameter worldZ;

		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store the hit game object.")]
		public ObjectParameter hitObject;
		public LayerMask mask;

		public override void OnUpdate ()
		{
			Vector2 mousePosition = Input.mousePosition;
			screenPosition.Value = mousePosition;
			screenX.Value = mousePosition.x;
			screenY.Value = mousePosition.y;

			Ray ray = Camera.main.ScreenPointToRay (mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit,Mathf.Infinity,mask)) {
				worldPosition.Value = hit.point;
				worldX.Value=hit.point.x;
				worldY.Value=hit.point.y;
				worldZ.Value=hit.point.z;

				hitObject.Value=hit.transform.gameObject;
			}
		}
	}
}