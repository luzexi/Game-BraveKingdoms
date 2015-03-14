using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StateMachine.Action{
	[Info (category = "String",   
	       description = "Separates strings.",
	       url = "")]
	[System.Serializable]
	public class Split : StateAction {
		[Tooltip("The string to use.")]
		public StringParameter value;
		public List<string> seperators;
		public StringSplitOptions options;
		[RequiredField(DefaultReference.Required,false,false)]
		[Tooltip("Store the result.")]
		public ListParameter store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoSplit ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSplit ();
		}

		private void DoSplit(){
			store.Value = value.Value.Split (seperators.ToArray (), options).ToList().ConvertAll(x=>(object)x);
		}
	}
}