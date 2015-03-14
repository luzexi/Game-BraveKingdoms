using UnityEngine;
using System.Collections;

namespace StateMachine.Action.List{
	[Info (category = "List",  
	       description = "Gets the list element at index.",
	       url = "")]
	[System.Serializable]
	public class GetNextElement : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("The List to work with.")]
		public ListParameter list;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Reset Value. Should be started with true.")]
		public BoolParameter reset;
		[Tooltip("Sends this event when getting next item.")]
		[DefaultValueAttribute("Loop")]
		public StringParameter loopEvent;
		[Tooltip("Sends this event when looping the list is finished.")]
		[DefaultValueAttribute("Finished")]
		public StringParameter finishedEvent;

		[Tooltip("Start Index.")]
		public IntParameter startIndex;
		[Tooltip("End Index, if 0 loops to the end.")]
		public IntParameter endIndex;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Store current Index.")]
		public IntParameter currentIndex;

		[Compound(0,"storeInt")]
		[Compound(1,"storeFloat")]
		[Compound(2,"storeString")]
		[Compound(3,"storeObject")]
		[Compound(4,"storeVector2")]
		[Compound(5,"storeVector3")]
		[Compound(6,"storeBool")]
		[Compound(7,"storeColor")]
		[Compound(8,"storeSystemObject")]
		public ElementType type;
		
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the value.")]
		public IntParameter storeInt;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the value.")]
		public FloatParameter storeFloat;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the value.")]
		public StringParameter storeString;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the value.")]
		public ObjectParameter storeObject;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the value.")]
		public Vector2Parameter storeVector2;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the value.")]
		public Vector3Parameter storeVector3;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the value.")]
		public BoolParameter storeBool;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the value.")]
		public ColorParameter storeColor;
		[HideInInspector]
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the value.")]
		public SystemObjectParameter storeSystemObject;

		private int realEndIndex;
		private bool startedLoop;
		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!reset.isNone) {
				startedLoop=!reset.Value;		
			}
			if (!startedLoop) {
				currentIndex.Value = startIndex.Value - 1;
				realEndIndex = endIndex.Value == 0 ? list.Value.Count - 1 : endIndex.Value;
				reset.Value=false;
				startedLoop=true;
			}

		}

		public override void OnUpdate ()
		{
			GetNext ();
		}

		private void GetNext(){
			if (currentIndex.Value >= realEndIndex) {
				Finish();
				stateMachine.behaviour.SendEvent (finishedEvent.Value,null);
				return;
			}
			currentIndex.Value += 1;
			switch (type) {
			case ElementType.Bool:
				storeBool.Value=(bool) list.Value[currentIndex.Value];
				break;
			case ElementType.Color:
				storeColor.Value=(Color) list.Value[currentIndex.Value];
				break;
			case ElementType.Float:
				storeFloat.Value=(float) list.Value[currentIndex.Value];
				break;
			case ElementType.Int:
				storeInt.Value=(int) list.Value[currentIndex.Value];
				break;
			case ElementType.Object:
				storeObject.Value=(Object) list.Value[currentIndex.Value];
				break;
			case ElementType.String:
				storeString.Value=(string) list.Value[currentIndex.Value];
				break;
			case ElementType.Vector2:
				storeVector2.Value=(Vector2) list.Value[currentIndex.Value];
				break;
			case ElementType.Vector3:
				storeVector3.Value=(Vector3) list.Value[currentIndex.Value];
				break;
			case ElementType.SystemObject:
				storeSystemObject.Value=list.Value[currentIndex.Value];
				break;
			}
			stateMachine.behaviour.SendEvent (loopEvent.Value,null);
		}
	}
}