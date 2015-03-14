using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine{
	[SerializeField]
	public class PreferencesEditor {
		private static Dictionary<Preference, bool> preferencesLookup;

		public void OnGUI(Rect position){
			bool show = GetBool (Preference.ShowPreference);
			if (show) {
				GUILayout.BeginArea (position, GUIContent.none, "OL box");
				DrawPreference (Preference.ShowWelcomeWindow, "Show welcome window on start?", true);
				DrawPreference (Preference.ShowStateDescription, "Show state description?", true);
				DrawPreference (Preference.ShowActionDescription, "Show action description?", true);
				DrawPreference (Preference.ShowParameterTooltips, "Show parameter tooltips?", false);
				DrawPreference (Preference.ShowInfo, "Show StateMachine info?", false);
				DrawPreference (Preference.ShowShortcuts, "Show Help?", true);
				DrawPreference (Preference.CustomInspector, "Show inspector panel?", false);
				GUILayout.EndArea ();	
			}

		}

		private void DrawPreference(Preference preference,string label, bool defaultValue){
			GUILayout.BeginHorizontal ();
			bool state = GetBool (preference,defaultValue);//EditorPrefs.GetBool (preference.ToString(), defaultValue);
			bool state2 = EditorGUILayout.Toggle (GUIContent.none, state,GUILayout.Width(18));
			if (state != state2) {
				SetBool (preference, state2);
			}
			GUILayout.Label (label,FsmStyles.WrappedLabel);
			GUILayout.EndHorizontal ();
		}

		public static bool GetBool(Preference preference){
			if (preferencesLookup == null) {
				preferencesLookup= new Dictionary<Preference, bool>();			
			}

			bool value;
			if (!PreferencesEditor.preferencesLookup.TryGetValue(preference, out value))
			{
				value = EditorPrefs.GetBool (preference.ToString());
				PreferencesEditor.preferencesLookup.Add(preference, value);
			}

			return value;
		}

		public static bool GetBool(Preference preference,bool defaultValue){
	
			return EditorPrefs.GetBool (preference.ToString(),defaultValue);
		}

		public static void SetBool(Preference preference, bool state){
			if (preferencesLookup == null) {
				preferencesLookup= new Dictionary<Preference, bool>();			
			}
			if (preferencesLookup.ContainsKey (preference)) {
				preferencesLookup[preference]=state;			
			}
			EditorPrefs.SetBool (preference.ToString(), state);
		}
	}

	public enum Preference{
		ShowPreference,
		ShowActionDescription,
		ShowParameterTooltips,
		ShowStateDescription,
		ShowWelcomeWindow,
		ShowShortcuts,
		ShowInfo,
		CustomInspector,
		LockSelection,
		CloseActionBrowserOnAdd,
		ActionBrowserShowPreview,
		CloseConditionBrowserOnAdd,
		ConditionBrowserShowPreview
	}
}