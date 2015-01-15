
namespace StateMachine.Action.UnityMaterial{
	[Info (category = "Material",    
	       description = "Set a named float value.",
	       url = "http://docs.unity3d.com/ScriptReference/Material.SetFloat.html")]
	[System.Serializable]
	public class SetFloat : MaterialAction {
		[Tooltip("Value to set.")]
		public FloatParameter value;
		[Tooltip("Property name defined in shader")]
		[DefaultValueAttribute("_Shininess")]
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
				renderer.material.SetFloat(propertyName.Value,value.Value);
			}
			else if (renderer.materials.Length > index.Value)
			{
				var materials = renderer.materials;
				materials[index.Value].SetFloat(propertyName.Value,value.Value);
				renderer.materials = materials;			
			}		
		}
	}
}