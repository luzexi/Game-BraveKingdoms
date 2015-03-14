using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UNavMeshAgent{
	[Info (category = "NavMeshAgent", 
	       description = "Gets the data from current OffMeshLinkData.",
	       url = "http://docs.unity3d.com/ScriptReference/NavMeshAgent-currentOffMeshLinkData.html")]
	[System.Serializable]
	public class GetCurrentOffMeshLinkData : NavMeshAgentAction {
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Is link active.")]
		public BoolParameter activated;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Link end world position.")]
		public Vector3Parameter endPos;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Link type specifier.")]
		public StringParameter linkType;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Link start world position")]
		public Vector3Parameter startPos;
		[RequiredField(DefaultReference.None,false,false)]
		[Tooltip("Is link valid.")]
		public BoolParameter valid;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			Get ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			Get ();
		}

		private void Get(){
			OffMeshLinkData data = agent.currentOffMeshLinkData;
			activated.Value = data.activated;
			endPos.Value=data.endPos;
			linkType.Value=data.linkType.ToString();
			startPos.Value=data.startPos;
			valid.Value = data.valid;
		}
	}
}