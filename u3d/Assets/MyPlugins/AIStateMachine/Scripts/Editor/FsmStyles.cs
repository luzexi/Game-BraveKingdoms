using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine{
	public static class FsmStyles {
		private static GUIStyle wrappedLabel;
		public static GUIStyle WrappedLabel{
			get{
				if(wrappedLabel == null){
					wrappedLabel=new GUIStyle("label");
					wrappedLabel.fixedHeight=0;
					wrappedLabel.wordWrap=true;
				}
				return wrappedLabel;
			}
		}

		private static GUIStyle shortcutLabel;
		public static GUIStyle ShortcutLabel{
			get{
				if(shortcutLabel == null){
					shortcutLabel=new GUIStyle("ObjectPickerLargeStatus");
					shortcutLabel.padding = new RectOffset (3, 3, 3, 3);
					shortcutLabel.alignment = TextAnchor.UpperLeft;
				}
				return shortcutLabel;
			}
		}
	
		private static GUIStyle descriptionLabel;
		public static GUIStyle DescriptionLabel{
			get{
				if(descriptionLabel == null){
					descriptionLabel=new GUIStyle("TL Selection H2");
					descriptionLabel.padding = new RectOffset (3, 3, 3, 3);
					descriptionLabel.contentOffset=WrappedLabel.contentOffset;
					descriptionLabel.alignment = TextAnchor.UpperLeft;
					descriptionLabel.fixedHeight=0;
					descriptionLabel.wordWrap=true;
				}
				return descriptionLabel;
			}
		}

		private static GUIStyle toolbar;
		public static GUIStyle Toolbar{
			get{
				if(toolbar == null){
					toolbar = new GUIStyle (EditorStyles.toolbar);
					toolbar.padding = new RectOffset (6, 1, 0, 0);
				}
				return toolbar;
			}
		}

		private static Dictionary<string, GUIStyle> nodeStyleCache;
		/// <summary>
		/// Gets the node style.
		/// </summary>
		/// <returns>The node style.</returns>
		/// <param name="color">Grey = 0,Blue = 1,Aqua = 2,Green = 3,Yellow = 4,Orange = 5,Red = 6</param>
		/// <param name="on">If set to <c>true</c> highlight.</param>
		public static GUIStyle GetNodeStyle(FsmStyles.Color color, bool on)
		{
			string str = string.Format("flow {0} {1}{2}", "node", (int)color, (!on ? string.Empty : " on"));
			if (nodeStyleCache == null) {
				nodeStyleCache= new Dictionary<string, GUIStyle>();			
			}
			if (!nodeStyleCache.ContainsKey(str))
			{
				GUIStyle style= new GUIStyle(str);
				style.contentOffset=Vector2.zero;
				style.padding= new RectOffset();
				style.alignment=TextAnchor.MiddleCenter;
				nodeStyleCache[str] = style;
			}
			return nodeStyleCache[str];
		}

		public static GUIStyle GetNodeStyle(FsmStyles.Color color, bool on, bool hex)
		{
			string str = string.Format("flow {0} {1}{2}{3}", "node",hex?"hex ":"", (int)color, (!on ? string.Empty : " on"));
			if (nodeStyleCache == null) {
				nodeStyleCache= new Dictionary<string, GUIStyle>();			
			}
			if (!nodeStyleCache.ContainsKey(str))
			{
				GUIStyle style= new GUIStyle(str);
				style.contentOffset=Vector2.zero;
				style.padding= new RectOffset();
				style.alignment=TextAnchor.MiddleCenter;
				nodeStyleCache[str] = style;
			}
			return nodeStyleCache[str];
		}

		public enum Color{
			Grey = 0,
			Blue = 1,
			Aqua = 2,
			Green = 3,
			Yellow = 4,
			Orange = 5,
			Red = 6
		}
	}
}