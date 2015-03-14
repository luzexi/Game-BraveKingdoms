using UnityEngine;
using System.Collections;

namespace StateMachine.Action{
	[Info (category = "List",  
	       description = "Gets the list element at index.",
	       url = "")]
	[System.Serializable]
	public class GetListCount : StateAction {
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("The List to work with.")]
		public ListParameter list;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("The parameter to use.")]
		public IntParameter store;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = list.Value != null ? list.Value.Count : 0;	
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = list.Value != null ? list.Value.Count : 0;	
		}
	}
}