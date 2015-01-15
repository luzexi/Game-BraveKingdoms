using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using StateMachine.Condition;
using StateMachine.Action;
using System.Reflection;

namespace StateMachine{
	[CustomEditor(typeof(State),true)]
	public class StateInspector : Editor {
		private ReorderableList actionList;
		private ReorderableList transitionList;
		private int transitionIndex=0;
		private ReorderableList conditionList;

		private static State copiedState;
		private static List<StateCondition> copiedConditions;

		private void OnEnable() {
			State state = target as State;
			if (state == null) {
				return;			
			}

			transitionIndex = 0;
			actionList = new ReorderableList (state.actions, "Actions", true, true);
			actionList.onAddCallback = delegate() {
				StateMachineUtility.AddAction (state);
				StateMachineWindow.RepaintAll();
			};
			actionList.onRemoveCallback = delegate(int index) {
				StateMachineUtility.RemoveAction(state,state.actions[index]);
				StateMachineWindow.RepaintAll();
			};
			actionList.drawElementCallback = delegate(int index) {
				StateMachineGUI.DrawElement (state.actions[index]);
			};
			actionList.onHeaderClick = delegate() {
				GenericMenu genericMenu = new GenericMenu ();
				genericMenu.AddItem(new GUIContent("Copy"),false,delegate() {
					copiedState=state;
				});
				if(copiedState != null && copiedState != state){
					genericMenu.AddItem(new GUIContent("Paste"),false,delegate() {
						foreach (StateAction action in copiedState.actions) {
							StateAction copy=(StateAction)ScriptableObject.Instantiate(action);
							copy.name=copy.name.Replace("(Clone)","");
							if (EditorUtility.IsPersistent (state)) {
								AssetDatabase.AddObjectToAsset(copy,state);
							}
							AssetDatabase.SaveAssets ();
							
							FieldInfo[] fields = action.GetType().GetFields ();
							for (int i=0; i< fields.Length; i++) {
								if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
									NamedParameter paramter=(NamedParameter)ScriptableObject.Instantiate((UnityEngine.Object)fields[i].GetValue(action));
									if (EditorUtility.IsPersistent (copy)) {
										AssetDatabase.AddObjectToAsset(paramter,copy);
									}
									AssetDatabase.SaveAssets();
									fields[i].SetValue(copy,paramter);
								}		
							}
							state.actions.Add(copy);
						}
						EditorUtility.SetDirty (state);
					});
				}

				if(copiedState != null && copiedState != state){
					genericMenu.AddItem(new GUIContent("Replace"),false,delegate() {
						foreach (StateAction action in state.actions) {
							FieldInfo[] fields = action.GetType ().GetFields ();
							for (int i=0; i< fields.Length; i++) {
								if (fields [i].FieldType.IsSubclassOf (typeof(NamedParameter))) {
									DestroyImmediate ((UnityEngine.Object)fields [i].GetValue (action), true);
								}		
							}
							DestroyImmediate(action,true);
						}
						state.actions.Clear();

						foreach (StateAction action in copiedState.actions) {
							StateAction copy=(StateAction)ScriptableObject.Instantiate(action);
							copy.name=copy.name.Replace("(Clone)","");
							if (EditorUtility.IsPersistent (state)) {
								AssetDatabase.AddObjectToAsset(copy,state);
							}
							AssetDatabase.SaveAssets ();
							
							FieldInfo[] fields = action.GetType().GetFields ();
							for (int i=0; i< fields.Length; i++) {
								if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
									NamedParameter paramter=(NamedParameter)ScriptableObject.Instantiate((UnityEngine.Object)fields[i].GetValue(action));
									if (EditorUtility.IsPersistent (copy)) {
										AssetDatabase.AddObjectToAsset(paramter,copy);
									}
									AssetDatabase.SaveAssets();
									fields[i].SetValue(copy,paramter);
								}		
							}
							state.actions.Add(copy);
						}
						EditorUtility.SetDirty (state);
					});
				}
				genericMenu.ShowAsContext ();
				Event.current.Use ();
			};

			transitionList = new ReorderableList (state.transitions, "Transition", false, false);
			transitionList.onRemoveCallback = delegate(int index) {
				if(index== transitionIndex){
					StateMachineWindow.StateMachineEditor.transitionIndex=0;
				}
				StateMachineUtility.RemoveTransition(state,state.transitions[index]);
				transitionIndex=0;
				RebuildConditionList(state);
				StateMachineWindow.RepaintAll();
			};
			transitionList.drawElementCallback = delegate(int index) {
				StateMachineGUI.DrawTransition(state.transitions[index],transitionIndex==index);
			};
			transitionList.onSelectCallback = delegate(int index) {
				transitionIndex=index;
				StateMachineWindow.StateMachineEditor.transitionIndex=index;
				RebuildConditionList(state);
				StateMachineWindow.RepaintAll();
			};

			transitionList.onDrawHeaderContent = delegate(Rect rect) {
				GUI.Label (new Rect (rect.width-25, rect.y+3, 50, 20), "Mute");	
			};

			RebuildConditionList (state);
		}

		private void RebuildConditionList(State state){
			if (state.transitions.Count > 0) {
				conditionList = new ReorderableList (state.transitions [transitionIndex].conditions, "Condition", true, true);
				conditionList.onAddCallback = delegate() {
					StateMachineUtility.AddCondition (state.transitions [transitionIndex]);
					StateMachineWindow.RepaintAll();
				};
				conditionList.onRemoveCallback = delegate(int index) {
					StateMachineUtility.RemoveCondition (state.transitions [transitionIndex], state.transitions [transitionIndex].conditions [index]);
					StateMachineWindow.RepaintAll();
				};
				conditionList.drawElementCallback = delegate(int index) {
					if(state.transitions.Count>transitionIndex)
					StateMachineGUI.DrawElement (state.transitions [transitionIndex].conditions [index]);
				};

				conditionList.onHeaderClick = delegate() {
					GenericMenu genericMenu = new GenericMenu ();
					genericMenu.AddItem(new GUIContent("Copy"),false,delegate() {
						copiedConditions=state.transitions[transitionIndex].conditions;
					});

					if(copiedConditions != null ){
						genericMenu.AddItem(new GUIContent("Paste"),false,delegate() {
							foreach (StateCondition condition in copiedConditions) {
								StateCondition copy=(StateCondition)ScriptableObject.Instantiate(condition);
								copy.name=copy.name.Replace("(Clone)","");
								if (EditorUtility.IsPersistent (state)) {
									AssetDatabase.AddObjectToAsset(copy,state.transitions[transitionIndex]);
								}
								AssetDatabase.SaveAssets ();
								
								FieldInfo[] fields = condition.GetType().GetFields ();
								for (int i=0; i< fields.Length; i++) {
									if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
										NamedParameter paramter=(NamedParameter)ScriptableObject.Instantiate((UnityEngine.Object)fields[i].GetValue(condition));
										if (EditorUtility.IsPersistent (copy)) {
											AssetDatabase.AddObjectToAsset(paramter,copy);
										}
										AssetDatabase.SaveAssets();
										fields[i].SetValue(copy,paramter);
									}		
								}
								state.transitions[transitionIndex].conditions.Add(copy);
							}
							EditorUtility.SetDirty (state);
						});
					}

					if(copiedConditions != null){
						genericMenu.AddItem(new GUIContent("Replace"),false,delegate() {
							foreach (StateCondition condition in state.transitions[transitionIndex].conditions) {
								FieldInfo[] fields = condition.GetType ().GetFields ();
								for (int i=0; i< fields.Length; i++) {
									if (fields [i].FieldType.IsSubclassOf (typeof(NamedParameter))) {
										DestroyImmediate ((UnityEngine.Object)fields [i].GetValue (condition), true);
									}		
								}
								DestroyImmediate(condition,true);
							}
							state.transitions[transitionIndex].conditions.Clear();
							
							foreach (StateCondition condition in copiedConditions) {
								StateCondition copy=(StateCondition)ScriptableObject.Instantiate(condition);
								copy.name=copy.name.Replace("(Clone)","");
								if (EditorUtility.IsPersistent (state.transitions[transitionIndex])) {
									AssetDatabase.AddObjectToAsset(copy,state.transitions[transitionIndex]);
								}
								AssetDatabase.SaveAssets ();
								
								FieldInfo[] fields = condition.GetType().GetFields ();
								for (int i=0; i< fields.Length; i++) {
									if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
										NamedParameter paramter=(NamedParameter)ScriptableObject.Instantiate((UnityEngine.Object)fields[i].GetValue(condition));
										if (EditorUtility.IsPersistent (copy)) {
											AssetDatabase.AddObjectToAsset(paramter,copy);
										}
										AssetDatabase.SaveAssets();
										fields[i].SetValue(copy,paramter);
									}		
								}
								state.transitions[transitionIndex].conditions.Add(copy);
							}
							EditorUtility.SetDirty (state.transitions[transitionIndex]);
						});
					}
					genericMenu.ShowAsContext ();
					Event.current.Use ();
				};
			}
		}

		public override void OnInspectorGUI (){
			State state = target as State;
			if (state == null) {
				return;			
			}

				actionList.DoList ();
				if (state.transitions.Count > 0) {	
					GUILayout.Space (10f);
					transitionList.DoList ();
					GUILayout.Space(10f);
					if(conditionList == null){
						RebuildConditionList(state);
					}
					conditionList.DoList();
				}

			if (GUI.changed) {
				EditorUtility.SetDirty(state);			
			}
		}

		protected override void OnHeaderGUI (){
			State state = target as State;
			if (state == null) {
				return;			
			}
			GUI.changed = false;
			GUILayout.BeginVertical ("IN BigTitle");
			EditorGUIUtility.labelWidth = 50;
			GUI.changed=false;
			GUILayout.BeginHorizontal ();
	
			state.name = EditorGUILayout.TextField ("Name", state.name);
			if (!state.isDefaultState && !(state is AnyState)) {
				GUIStyle style = FsmStyles.GetNodeStyle ((FsmStyles.Color)state.color, false);
				Rect rect = GUILayoutUtility.GetRect (25, 17, style);
				rect.y += 1;
				if (GUI.Button (rect, GUIContent.none, style)) {
					GenericMenu menu = new GenericMenu ();
					foreach (FsmStyles.Color color in System.Enum.GetValues(typeof(FsmStyles.Color))) {
						if(color != FsmStyles.Color.Aqua && color != FsmStyles.Color.Orange){
							int mColor = (int)color;
							menu.AddItem (new GUIContent (color.ToString ()), state.color == mColor, delegate() {
								state.color = mColor;
							});
						}
					}
					menu.ShowAsContext ();
				}
			}
			GUILayout.EndHorizontal ();
			GUILayout.Label("Description:");
			state.description = EditorGUILayout.TextArea (state.description, GUILayout.MinHeight (45));
			GUILayout.EndVertical ();
	
			if (GUI.changed) {
				EditorUtility.SetDirty(state);
				StateMachineWindow.RepaintAll();			
			}
		}
	}
}