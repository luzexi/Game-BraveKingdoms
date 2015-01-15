using UnityEngine;
using UnityEditor;
using System.Collections;

namespace StateMachine{
	[CustomEditor(typeof(StateMachine))]
	public class StateMachineInspector : Editor {
		
		private void OnEnable(){
			EditorApplication.projectWindowItemOnGUI += OnDoubleClickItem;
		}
		
		private void OnDisable(){
			EditorApplication.projectWindowItemOnGUI -= OnDoubleClickItem;
		}

		private bool foldout;
		private bool enabled;
		public override void OnInspectorGUI (){
			//  GUITools.InspectorFoldout (ref foldout, ref enabled);
		}

		public virtual void OnDoubleClickItem(string test,Rect r){
			if (Event.current.type == EventType.MouseDown && Event.current.clickCount == 2 && r.Contains (Event.current.mousePosition)) {
				//StateMachineEditorOld.Show((StateMachine)target);
				StateMachineWindow window = EditorWindow.GetWindow<StateMachineWindow>("StateMachine");
				window.SetStateMachine((StateMachine)target);
			}
		}

		protected override void OnHeaderGUI ()
		{

			GUILayout.BeginVertical ("IN BigTitle");
			EditorGUIUtility.labelWidth = 50;
			string oldName = AssetDatabase.GetAssetPath (target);
			string newName = target.name;
			newName  = EditorGUILayout.TextField ("Name", newName);
			if(oldName != newName)
			AssetDatabase.RenameAsset (oldName, newName);
			GUILayout.EndVertical ();

		}
	}
}