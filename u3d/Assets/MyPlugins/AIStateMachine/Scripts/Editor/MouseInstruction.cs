using UnityEngine;
using System.Collections;

namespace StateMachine{
	public class MouseInstruction {
		private static string mouseInstruction;
		public static bool DoMouseInstruction(){
			if (!string.IsNullOrEmpty (mouseInstruction)) {
				GUIContent content = new GUIContent (mouseInstruction);
				float height = FsmStyles.WrappedLabel.CalcHeight (content,200);
				GUI.Label (new Rect (Event.current.mousePosition.x+10, Event.current.mousePosition.y-height*0.5f+10, 200, height), content,FsmStyles.WrappedLabel);
				return true;
			}
			return false;
		}
		
		public static void Clear(){
			mouseInstruction = string.Empty;		
		}
		
		public static void Set(string text){
			mouseInstruction = text;		
		}
	}
}