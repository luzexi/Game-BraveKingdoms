using UnityEngine;

namespace StateMachine.Action.UnityMaterial{
	[Info (category = "Material",    
	       description = "Sets the placement scale of texture propertyName.",
	       url = "http://docs.unity3d.com/ScriptReference/Material.SetTextureOffset.html")]
	[System.Serializable]
	public class SetTextureScale : MaterialAction {
		[Tooltip("Property name defined in shader")]
		[DefaultValueAttribute("_MainTex")]
		public StringParameter propertyName;
		[Tooltip("Scale to set.")]
		public Vector2Parameter scale;
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
			DoSet();
		}
		
		private void DoSet(){
			if (index.Value == 0)
			{
				renderer.material.SetTextureScale(propertyName.Value,scale.Value);
			}
			else if (renderer.materials.Length > index.Value)
			{
				var materials = renderer.materials;
				materials[index.Value].SetTextureScale(propertyName.Value,scale.Value);
				renderer.materials = materials;			
			}		
		}
	}
}