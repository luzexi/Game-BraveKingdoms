using UnityEngine;
using UnityEditor;
using System.Collections;

namespace StateMachine{
	[CustomEditor(typeof(StateMachineBehaviour))]
	public class StateMachineBehaviourInspector : Editor {
		
		public override void OnInspectorGUI ()
		{
			StateMachineBehaviour behaviour=target as StateMachineBehaviour;

			base.OnInspectorGUI ();
		 
			if (behaviour.stateMachine != null) {
				GUILayout.Label("Description:");
				behaviour.stateMachine.description=EditorGUILayout.TextArea(behaviour.stateMachine.description,GUILayout.MinHeight(60));			
			}

			if(behaviour.stateMachine != null)
			GUI.enabled= EditorUtility.IsPersistent(behaviour.stateMachine);



			if (behaviour.stateMachine != null) {
				EditorGUILayout.HelpBox ("Bind the state machine to a GameObject to interact with the scene. Use GameObjects from your scene in the state machine directly.", MessageType.Info, true);
			} else {
				EditorGUILayout.HelpBox ("Please assign a state machine to the State Machine field.", MessageType.Warning, true);
			}
			GUI.enabled = behaviour.stateMachine != null && EditorUtility.IsPersistent(behaviour.stateMachine);
			if (GUILayout.Button ("Bind to GameObject")) {
				StateMachine stateMachine=ScriptableObject.CreateInstance<StateMachine>();
				stateMachine.name=behaviour.stateMachine.name+"(Bind)";
				StateMachine.Copy(behaviour.stateMachine,stateMachine,false);
				behaviour.stateMachine=stateMachine;
				AssetDatabase.SaveAssets();
				if(StateMachineWindow.instance != null){
					StateMachineWindow.StateMachineEditor.ActiveStateMachine=stateMachine;
					StateMachineWindow.StateMachineEditor.ActiveGameObject=behaviour.gameObject;
					StateMachineWindow.RepaintAll();
					Selection.activeObject=behaviour;
				}

			}
			GUI.enabled = true;

			if (StateMachineWindow.instance == null) {
				if (GUILayout.Button ("Graph - Window")) {
					StateMachineWindow window = StateMachineWindow.ShowWindow();
					window.SetStateMachine(behaviour.stateMachine);
					StateMachineWindow.StateMachineEditor.ActiveGameObject=behaviour.gameObject;
				}
			}

			if (GUI.changed) {
				EditorUtility.SetDirty(behaviour);			
			}

		}
	}
}