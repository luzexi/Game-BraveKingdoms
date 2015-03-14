
namespace StateMachine.Action{
	[Info (category = "GameObject",    
	       description = "Removes a gameobject, component or asset.",
	       url = "http://docs.unity3d.com/Documentation/ScriptReference/Object.Destroy.html")]
	[System.Serializable]
	public class Destroy : GameObjectAction {
		[Tooltip("Delay")]
		public FloatParameter delay;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			Destroy (gameObject.Value,delay.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			Destroy (gameObject.Value,delay.Value);
		}
	}
}