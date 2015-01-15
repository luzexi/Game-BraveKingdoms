using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace StateMachine{
	// makes sure that the static constructor is always called in the editor.
	[InitializeOnLoad]
	public class AddStateMachine : Editor
	{
		static AddStateMachine ()
		{
			// Adds a callback for when the hierarchy window processes GUI events
			// for every GameObject in the heirarchy.
			EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemCallback;
			//EditorApplication.projectWindowItemOnGUI += ProjectWindowItemCallback;
			//EditorApplication.projectWindowChanged += ProjectWindowChanged;
		}

		/*static void ProjectWindowChanged(){
			if (DragAndDrop.objectReferences.Length > 0 && DragAndDrop.objectReferences [0].GetType () == typeof(GameObject)) {
				GameObject go=(GameObject)DragAndDrop.objectReferences[0];
				StateMachineBehaviour behaviour=go.GetComponent<StateMachineBehaviour>();
				if(behaviour != null && behaviour.stateMachine != null && !EditorUtility.IsPersistent(behaviour.stateMachine)){
					GameObject prefab=(GameObject)PrefabUtility.GetPrefabParent(go);
					if(prefab != null && EditorUtility.IsPersistent(prefab)){
						AssetDatabase.AddObjectToAsset(behaviour.stateMachine,prefab);
						AssetDatabase.SaveAssets();
						prefab.GetComponent<StateMachineBehaviour>().stateMachine=behaviour.stateMachine;
					}
				}
			}
		}

		static void ProjectWindowItemCallback(string pID, Rect pRect)
		{

		}*/

		private static Texture2D hierarchyIcon;
		private static Texture2D HierarchyIcon {
			get {
				if (AddStateMachine.hierarchyIcon==null){
					AddStateMachine.hierarchyIcon = (Texture2D)Resources.Load( "logo");
				}
				return AddStateMachine.hierarchyIcon;
			}
		}

		static void HierarchyWindowItemCallback(int pID, Rect pRect)
		{
			GameObject go = EditorUtility.InstanceIDToObject(pID) as GameObject;
			if (go != null && go.GetComponent<StateMachineBehaviour>() != null)
			{
				Rect rect = new Rect(pRect.x + pRect.width - 25, pRect.y-3, 25, 25);
				GUI.DrawTexture( rect,AddStateMachine.HierarchyIcon);
			}

			// happens when an acceptable item is released over the GUI window
			if (Event.current.type == EventType.DragPerform)
			{
				// get all the drag and drop information ready for processing.
				DragAndDrop.AcceptDrag();
				
				// used to emulate selection of new objects.
				var selectedObjects = new List<GameObject>();
				
				// run through each object that was dragged in.
				foreach (var objectRef in DragAndDrop.objectReferences)
				{
					// if the object is the particular asset type...
					if (objectRef is StateMachine)
					{
						if(pRect.Contains(Event.current.mousePosition)){
							// we create a new GameObject using the asset's name.
							var gameObject = (GameObject)EditorUtility.InstanceIDToObject(pID);
							
							// we attach component X, associated with asset X.
							var componentX = gameObject.AddComponent<StateMachineBehaviour>();
							
							// we place asset X within component X.
							componentX.stateMachine = objectRef as StateMachine;
							
							// add to the list of selected objects.
							selectedObjects.Add(gameObject);
						}
					}
				}
				
				// we didn't drag any assets of type AssetX, so do nothing.
				if (selectedObjects.Count == 0) return;
				
				// emulate selection of newly created objects.
				Selection.objects = selectedObjects.ToArray();
				
				// make sure this call is the only one that processes the event.
				Event.current.Use();
				
			}
		}
	}
}