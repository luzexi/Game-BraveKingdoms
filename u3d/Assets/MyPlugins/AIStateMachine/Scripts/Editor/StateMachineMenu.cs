using UnityEngine;
using UnityEditor;
using System.Collections;

namespace StateMachine{
	public static class StateMachineMenu {
		[MenuItem("Assets/Create/State Machine/State Machine")]
		public static void CreateAIControllerAsset()
		{
			StateMachine stateMachine = StateMachineUtility.CreateStateMachine (false);
			stateMachine.name="New StateMachine";
		}

		[MenuItem("Window/State Machine/Create State Machine",false,2)]
		public static void CreateStateMachineFromWindowAsset()
		{
			StateMachine stateMachine = StateMachineUtility.CreateStateMachine (true);
			StateMachineWindow window= StateMachineWindow.ShowWindow ();
			window.SetStateMachine(stateMachine);

		}

		[MenuItem("Window/State Machine/Open Editor",false,2)]
		public static void OpenStateMachineEditor()
		{
			StateMachineWindow window= StateMachineWindow.ShowWindow ();
			window.SetStateMachine(null);
			
		}
	}
}