using UnityEngine;
using System.Collections;

namespace StateMachine.Action.List{
	[Info (category = "List",  
	       description = "Adds an element at given index.",
	       url = "")]
	[System.Serializable]
	public class Insert : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("The List to work with.")]
		public ListParameter list;
		[Tooltip("Index to add at.")]
		public IntParameter index;
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
			switch (type) {
			case ElementType.Bool:
				list.Value.Insert(index.Value,addBool.Value);
				break;
			case ElementType.Color:
				list.Value.Add(addColor.Value);
				break;
			case ElementType.Float:
				list.Value.Add(addFloat.Value);
				break;
			case ElementType.Int:
				list.Value.Insert(index.Value,addInt.Value);
				break;
			case ElementType.Object:
				list.Value.Insert(index.Value,addObject.Value);
				break;
			case ElementType.String:
				list.Value.Insert(index.Value,addString.Value);
				break;
			case ElementType.Vector2:
				list.Value.Insert(index.Value,addVector2.Value);
				break;
			case ElementType.Vector3:
				list.Value.Insert(index.Value,addVector3.Value);
				break;
			case ElementType.SystemObject:
				list.Value.Insert(index.Value,addSystemObject.Value);
				break;
			}
		}
		
		
	}
}