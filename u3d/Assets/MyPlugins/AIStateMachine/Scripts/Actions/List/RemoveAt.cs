using UnityEngine;
using System.Collections;

namespace StateMachine.Action.List{
	[Info (category = "List",  
	       description = "Removes an element at given index.",
	       url = "")]
	[System.Serializable]
	public class RemoveAt : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("The List to work with.")]
		public ListParameter list;
		[Tooltip("Index to remove at.")]
		public IntParameter index;
		public override void OnEnter ()
		{
			base.OnEnter ();
			list.Value.RemoveAt (index.Value);
		}
		
		
	}
}