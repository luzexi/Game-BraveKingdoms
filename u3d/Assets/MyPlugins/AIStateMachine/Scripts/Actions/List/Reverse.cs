using UnityEngine;
using System.Collections;

namespace StateMachine.Action.List{
	[Info (category = "List",  
	       description = "Reverse the list.",
	       url = "")]
	[System.Serializable]
	public class Reverse : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("The List to work with.")]
		public ListParameter list;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			list.Value.Reverse ();
		}
		
		
	}
}