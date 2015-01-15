using UnityEngine;

namespace StateMachine.Action.UnityMaterial{
	[Info (category = "Material",    
	       description = "Set a new material",
	       url = "")]
	[System.Serializable]
	public class SetMaterial : MaterialAction {
		[ObjectType(typeof(Material))]
		[Tooltip("Material to set.")]
		public ObjectParameter material;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
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
				renderer.material=(Material)material.Value;
			}
			else if (renderer.materials.Length > index.Value)
			{
				var materials = renderer.materials;
				materials[index.Value]=(Material)material.Value;
				renderer.materials = materials;			
			}		
		}
	}
}