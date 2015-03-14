using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine.Action.List{
	[Info (category = "List",  
	       description = "Add a new item to the list.",
	       url = "")]
	[System.Serializable]
	public class Add : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("The List to work with.")]
		public ListParameter list;
		[Compound(0,"addInt")]
		[Compound(1,"addFloat")]
		[Compound(2,"addString")]
		[Compound(3,"addObject")]
		[Compound(4,"addVector2")]
		[Compound(5,"addVector3")]
		[Compound(6,"addBool")]
		[Compound(7,"addColor")]
		[Compound(8,"addSystemObject")]
		public ElementType type;

		[HideInInspector]
		[Tooltip("Value to add.")]
		public IntParameter addInt;
		[HideInInspector]
		[Tooltip("Value to add.")]
		public FloatParameter addFloat;
		[HideInInspector]
		[Tooltip("Value to add.")]
		public StringParameter addString;
		[HideInInspector]
		[Tooltip("Value to add.")]
		public ObjectParameter addObject;
		[HideInInspector]
		[Tooltip("Value to add.")]
		public Vector2Parameter addVector2;
		[HideInInspector]
		[Tooltip("Value to add.")]
		public Vector3Parameter addVector3;
		[HideInInspector]
		[Tooltip("Value to add.")]
		public BoolParameter addBool;
		[HideInInspector]
		[Tooltip("Value to add.")]
		public ColorParameter addColor;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Value to add.")]
		public SystemObjectParameter addSystemObject;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (list.Value == null) {
				list.Value=new List<object>();			
			}
			switch (type) {
			case ElementType.Bool:
				list.Value.Add(addBool.Value);
				break;
			case ElementType.Color:
				list.Value.Add(addColor.Value);
				break;
			case ElementType.Float:
				list.Value.Add(addFloat.Value);
				break;
			case ElementType.Int:
				list.Value.Add(addInt.Value);
				break;
			case ElementType.Object:
				list.Value.Add(addObject.Value);
				break;
			case ElementType.String:
				list.Value.Add(addString.Value);
				break;
			case ElementType.Vector2:
				list.Value.Add(addVector2.Value);
				break;
			case ElementType.Vector3:
				list.Value.Add(addVector3.Value);
				break;
			case ElementType.SystemObject:
				list.Value.Add(addSystemObject.Value);
				break;
			}
		}
		

	}
}