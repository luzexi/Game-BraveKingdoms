using UnityEngine;
using System.Collections.Generic;

namespace StateMachine.Action.UnityMaterial{
	[Info (category = "Material",    
	       description = "Set a random material",
	       url = "")]
	[System.Serializable]
	public class SetRandomMaterial : MaterialAction {
		[Tooltip("Materials to use.")]
		public List<Material> materials;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			if (materials.Count == 0) {
				enabled=false;
				Debug.Log("SetRandomMaterial requires at least one meterial in the list. Action disabled!");
				return;			
			}
			DoSetMaterial ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSetMaterial ();
		}
		
		private void DoSetMaterial(){
			if (index.Value == 0)
			{
				renderer.material=materials[Random.Range(0,materials.Count)];
			}
			else if (renderer.materials.Length > index.Value)
			{
				var _materials = renderer.materials;
				_materials[index.Value]= materials[Random.Range(0,materials.Count)];
				renderer.materials = _materials;			
			}		
		}
	}
}