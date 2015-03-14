using UnityEngine;
using System.Collections;

namespace StateMachine.Action.UnityCamera{
	[Info (category = "Camera",   
	       description = "Fade to a color.",
	       url = "")]
	[System.Serializable]
	public  class FadeOut : StateAction {
		[Tooltip("Color to fade from.")]
		public ColorParameter color;
		[Tooltip("Fade in time in seconds.")]
		public FloatParameter time;
		[Tooltip("Delay start.")]
		public FloatParameter delay;
		[Tooltip("Sends finish event.")]
		public StringParameter finishEvent;

		private float currentTime;
		private Color colorLerp;
		private Texture2D texture;
		
		public override void OnEnter (){
			base.OnEnter ();
			if(!enabled) {
				return;			
			}
			currentTime = 0f-delay.Value;
			colorLerp = color.Value;
			texture = new Texture2D (1, 1);
			texture.SetPixel (0, 0, Color.white);
			texture.Apply ();
		}
		
		public override void OnUpdate ()
		{
			currentTime += Time.deltaTime;
			colorLerp = Color.Lerp(Color.clear, color.Value, currentTime/time.Value);
			
			if (currentTime > time.Value)
			{	
				stateMachine.behaviour.SendEvent(finishEvent.Value,null);
			}
		}
		
		public override void OnGUI()
		{
			var guiColor = GUI.color;
			GUI.color = colorLerp;
			GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),texture);
			GUI.color = guiColor;
		}
	}
}