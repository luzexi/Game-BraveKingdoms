using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine{
	[System.Serializable]
	public class GUIControl  {
		private static Dictionary<Control,int> guiHash;
		static GUIControl(){
			guiHash = new Dictionary<Control, int> ();
			var values = Enum.GetValues (typeof(Control));
			foreach (var value in values) {
				guiHash.Add ((Control)value, value.GetHashCode ());			
			}
		}

		public static int GetID(Control control){
			return guiHash[control];
		}
	}

	public enum Control{
		SelectStates,
		DragStates,
		//MakeTransition,
		DragGraph,
		InspectorWidthChange
	}
}
