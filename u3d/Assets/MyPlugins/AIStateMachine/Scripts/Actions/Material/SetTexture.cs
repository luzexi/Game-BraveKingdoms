using UnityEngine;

namespace StateMachine.Action.UnityMaterial{
	[Info (category = "Material",    
	       description = "Set a new texture to the material.",
	       url = "")]
	[System.Serializable]
	public class SetTexture : MaterialAction {
		[ObjectType(typeof(Texture))]
		[Tooltip("Texture to set.")]
		public ObjectParameter texture;
		[Tooltip("Property name defined in shader")]
		[DefaultValueAttribute("_MainTex")]
		public StringParameter propertyName;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			DoSet ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSet ();
		}
		
		private void DoSet(){
			if (index.Value == 0)
			{
				renderer.material.SetTexture(propertyName.Value,(Texture)texture.Value);
			}
			else if (renderer.materials.Length > index.Value)
			{
				var materials = renderer.materials;
				materials[index.Value].SetTexture(propertyName.Value,(Texture)texture.Value);
				renderer.materials = materials;			
			}		
		}
	}
}