
namespace StateMachine.Action.UnityMaterial{
	[Info (category = "Material",    
	       description = "Set a named color value.",
	       url = "http://docs.unity3d.com/ScriptReference/Material.SetColor.html")]
	[System.Serializable]
	public class SetColor : MaterialAction {
		[Tooltip("Color to set.")]
		public ColorParameter color;
		[Tooltip("Property name defined in shader")]
		[DefaultValueAttribute("_Color")]
		public StringParameter propertyName;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			DoSetColor ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSetColor ();
		}

		private void DoSetColor(){
			if (index.Value == 0)
			{
				renderer.material.SetColor(propertyName.Value,color.Value);
			}
			else if (renderer.materials.Length > index.Value)
			{
				var materials = renderer.materials;
				materials[index.Value].SetColor(propertyName.Value,color.Value);
				renderer.materials = materials;			
			}		
		}
	}
}