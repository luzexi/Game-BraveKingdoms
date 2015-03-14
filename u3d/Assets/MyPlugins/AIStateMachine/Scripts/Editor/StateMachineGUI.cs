using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using StateMachine.Action;
using StateMachine.Condition;

namespace StateMachine{
	public static class StateMachineGUI {
		private static Texture2D settingsIcon;
		private static Texture2D helpIcon;
		private static GUIStyle inspectorTitlebar;
		private static GUIStyle inspectorTitlebarText;
		private static Texture2D errorIcon;
		private static Dictionary<UnityEngine.Object,SerializedObject> objectLookup;
		private static Dictionary<SerializedObject,SerializedProperty> propertyLookup;

		static StateMachineGUI(){
			settingsIcon = EditorGUIUtility.FindTexture ("_popup");
			helpIcon = EditorGUIUtility.FindTexture ("_help");
			errorIcon = EditorGUIUtility.FindTexture ("d_console.erroricon.sml");
			inspectorTitlebar = new GUIStyle("IN Title");
			inspectorTitlebarText = new GUIStyle("IN TitleText");
			objectLookup = new Dictionary<UnityEngine.Object, SerializedObject> ();
			propertyLookup = new Dictionary<SerializedObject, SerializedProperty> ();
		}

		private static SerializedObject GetSerializedObject(UnityEngine.Object obj)
		{
			SerializedObject serializedObject;
			if (!StateMachineGUI.objectLookup.TryGetValue(obj, out serializedObject))
			{
				serializedObject = new SerializedObject(obj);
				StateMachineGUI.objectLookup.Add(obj, serializedObject);
			}
			return serializedObject;
		}

		private static SerializedProperty GetSerializedProperty(SerializedObject serializedObject,string propertyName)
		{
			SerializedProperty serializedProperty;
			if (!StateMachineGUI.propertyLookup.TryGetValue(serializedObject, out serializedProperty))
			{
				serializedProperty=serializedObject.FindProperty(propertyName);
				StateMachineGUI.propertyLookup.Add(serializedObject, serializedProperty);
			}
			return serializedProperty;
		}

		/// <summary>
		/// Draws the transition gui.
		/// </summary>
		/// <param name="transition">Transition.</param>
		/// <param name="on">If set to <c>true</c> on.</param>
		public static void DrawTransition(StateTransition transition, bool on){
			Color color = GUI.contentColor;
			GUI.contentColor = on ? EditorStyles.foldout.focused.textColor : color;
			GUILayout.BeginHorizontal();
			GUILayout.Label (transition.fromState.name + " -> " + transition.toState.name, on?EditorStyles.whiteLabel:"Label");
			GUILayout.FlexibleSpace();
			transition.mute=GUILayout.Toggle(transition.mute,GUIContent.none,GUILayout.Width(10));
			GUILayout.Space (15f);
			GUILayout.EndHorizontal();
			GUI.contentColor = color;		
		}

		public static void DrawElement(ScriptableObject node){
			DrawElement (node, true, true);
		}

		public static void DrawElement(ScriptableObject node, bool showTitleBar, bool showDescription){
			bool foldout = showTitleBar? StateMachineGUI.Titlebar (node as Node):true;
	
			if (foldout) {
				if(showDescription){
					DrawDescription (node as Node);
				}
				FieldInfo[] fields = node.GetType ().GetFields (BindingFlags.Instance | BindingFlags.Public).OrderBy(field => field.MetadataToken).ToArray();

				List<string> compoundFieldNames=GetCompoundFieldNames(node as Node,fields);


				bool hasAlready=false;
				for (int i=0; i< fields.Length; i++) {
					bool hideInInspector = fields[i].HideFieldInInspector();
					
					if (compoundFieldNames.Contains (fields [i].Name)) {
						hideInInspector = false;
					}
					
					if (!hideInInspector) {
						GUIContent content=fields[i].GetInspectorGUIContent();
						GUI.changed=false;

						if (fields [i].FieldType.IsSubclassOf (typeof(NamedParameter))) {
							if(fields[i].IsReflectionInfo()){
								Type reflectionReferenceType=fields[i].GetReflectionReferenceFieldType(node);
								if(reflectionReferenceType != null && GetReflectionTypeNames(fields[i],true,reflectionReferenceType).Length>0 ){
									DrawParameter(node as Node,fields[i],content);
								}else{
									NamedParameter parameter = (NamedParameter)fields[i].GetValue (node);
									((StringParameter)parameter).Value=string.Empty;
								}
							}else if(fields[i].IsReflectionReturnInfo()){
								Type type =fields[i].GetReferenceReturnFieldType(node);
								if(!hasAlready && type != null && (fields[i].GetReflectionReturnType().IsAssignableFrom(type)|| IsAssignableToGenericType(type,fields[i].GetReflectionReturnType()) )){
									DrawParameter(node as Node,fields[i],content);
									hasAlready=true;
								}
							}else{
								DrawParameter(node as Node,fields[i],content);
							}
						} else {
							if(fields[i].IsReflectionInfo()){
								Type reflectionReferenceType=fields[i].GetReflectionReferenceFieldType(node);
								if(reflectionReferenceType != null && GetReflectionTypeNames(fields[i],true,reflectionReferenceType).Length>0 ){
									DrawField (node, fields [i]);
								}else{
									fields[i].SetValue(node,string.Empty);
								}
							}else if(fields[i].IsReflectionReturnInfo()){
								Type type =fields[i].GetReferenceReturnFieldType(node);

								if(type != null && fields[i].GetReflectionReturnType()==type){
									DrawField (node, fields [i]);
								}
							}else{
								DrawField (node, fields [i]);
							}
			
						}
						
						if(GUI.changed){
							EditorUtility.SetDirty(node);
						}
					}
				}
			}
		}

		public static bool IsAssignableToGenericType(Type givenType, Type genericType)
		{
			var interfaceTypes = givenType.GetInterfaces();
			
			foreach (var it in interfaceTypes)
			{
				if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
					return true;
			}
			
			if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
				return true;
			
			Type baseType = givenType.BaseType;
			if (baseType == null) return false;
			
			return IsAssignableToGenericType(baseType, genericType);
		}

		private static void DrawParameter(Node node,FieldInfo info, GUIContent content){
			NamedParameter parameter = (NamedParameter)info.GetValue (node);

			GUILayout.BeginHorizontal();

			if(!parameter.IsConstant){
				StateMachine stateMachine=StateMachineWindow.StateMachineEditor.ActiveStateMachine;
				List<string> referenceNames=GetParameterReferenceNames(info,stateMachine);

				string postfix=string.Empty;
				Color color=GUI.backgroundColor;
				if(info.IsFieldRequired() && parameter.Reference == info.GetDefaultReference().ToString()){
					GUI.backgroundColor=Color.red;
					postfix=" ("+info.FieldType.GetProperty("Value").PropertyType.ToString().Split('.').Last()+")";//" ("+info.FieldType.ToString().Split('.').Last()+")";
				}

				parameter.Reference=UnityEditorTools.StringPopup(content,parameter.Reference,postfix,referenceNames.ToArray());
				
				GUI.backgroundColor=color;
			}else{

				SerializedObject parameterObject= GetSerializedObject(parameter);//new SerializedObject(parameter);

				parameterObject.Update();
				SerializedProperty valueProp=StateMachineGUI.GetSerializedProperty(parameterObject,"value"); //parameterObject.FindProperty("value");
				if(valueProp != null){
					if(parameter is ObjectParameter){
						Type type = info.GetObjectType();
						if(type != null){
							valueProp.objectReferenceValue=EditorGUILayout.ObjectField(content,valueProp.objectReferenceValue,type,!EditorUtility.IsPersistent(parameter));
						}else{
							EditorGUILayout.PropertyField (valueProp, content);
							parameter.Reference=string.Empty;
							
						}
					}else{
						EditorGUILayout.PropertyField (valueProp, content);
						parameter.Reference=string.Empty;
					}
				}
				parameterObject.ApplyModifiedProperties();

				if(info.IsComponentInfo()){
					if(GUILayout.Button(GUIContent.none,"MiniPullDown",GUILayout.Width(15))){
						GenericMenu toolsMenu = new GenericMenu();
						string[] names=ReflectionUtility.GetAllComponentNames();
						
						foreach(string s in names){
							string displayName=s.Split('.').Last();
							toolsMenu.AddItem(new GUIContent(displayName),false,ApplyString,new object[]{parameter,s});
						}
						toolsMenu.DropDown(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,0,0));
						EditorGUIUtility.ExitGUI();
					}
				}
				
				Type reflectionReferenceType=info.GetReflectionReferenceFieldType(node);
				
				if(reflectionReferenceType!= null && GUILayout.Button(GUIContent.none,"MiniPullDown",GUILayout.Width(15))){
					GenericMenu toolsMenu = new GenericMenu();
					string[] names=GetReflectionTypeNames(info,true,reflectionReferenceType);
					
					
					foreach(string s in names){
						toolsMenu.AddItem(new GUIContent(s),false,ApplyString,new object[]{parameter,s});
					}
					
					if(names.Length == 0){
						toolsMenu.AddItem(new GUIContent("[None Found]"),false,delegate() {});
					}
					
					toolsMenu.DropDown(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,0,0));
					EditorGUIUtility.ExitGUI();
				}
			}
			if(info.IsConstantValueAllowed() || (!EditorUtility.IsPersistent(node) && info.IsBindedConstantValueAllowed())){
				parameter.IsConstant=EditorGUILayout.Toggle(parameter.IsConstant,EditorStyles.radioButton,GUILayout.Width(20));
			}else{
				parameter.IsConstant=false;
				GUILayout.Space(24);
			}
			GUILayout.EndHorizontal();
		}

		private static string[] GetReflectionTypeNames(FieldInfo info,bool requiresWrite, Type reflectionReferenceType){
			ReflectionType popupType=info.GetReflectionType();
			string[] names = new string[0];
			switch(popupType){
			case ReflectionType.Methods:
				names=reflectionReferenceType.GetMethodNames();
				break;
			case ReflectionType.Fields:
				names=reflectionReferenceType.GetFieldNames(true, typeof(string), typeof(Color),typeof(Vector3),typeof(UnityEngine.Object),typeof(KeyCode),typeof(List<>),typeof(System.Object));
				break;
			case ReflectionType.Properties:
				names=reflectionReferenceType.GetPropertyNames(true,requiresWrite, typeof(string), typeof(Color),typeof(Vector3),typeof(UnityEngine.Object),typeof(KeyCode),typeof(List<>),typeof(System.Object));
				break;
			case ReflectionType.FieldsAndProperties:
				names=reflectionReferenceType.GetPropertyAndFieldNames(true,requiresWrite, typeof(string), typeof(Color),typeof(Vector3),typeof(UnityEngine.Object),typeof(KeyCode),typeof(List<>),typeof(System.Object));
				break;
			}
			return names;
		}


		private static List<string> GetParameterReferenceNames(FieldInfo info, StateMachine stateMachine){

			List<string> names = new List<string> ();

			names.Add (info.GetDefaultReference().ToString());
			if (stateMachine == null) {
				return names;			
			}
			Type type = info.FieldType;
			if(type == typeof(StringParameter)){
				names.AddRange(stateMachine.parameters.Select(p=>p.Name).ToList());
				names.AddRange(GlobalParameterCollection.GetParamterNames());
			}else{
				names.AddRange(stateMachine.parameters.Where(n=>n.GetType()==type ).Select(p=>p.Name).ToList());
				names.AddRange(GlobalParameterCollection.GetParamterNames(type));
				
				if(type == typeof(FloatParameter)){
					names.AddRange(stateMachine.parameters.Where(n=>n.GetType()==typeof(IntParameter)).Select(p=>p.Name).ToList());
					names.AddRange(GlobalParameterCollection.GetParamterNames(typeof(IntParameter)));
				}else if(type== typeof(IntParameter)){
					names.AddRange(stateMachine.parameters.Where(n=>n.GetType()==typeof(FloatParameter)).Select(p=>p.Name).ToList());
					names.AddRange(GlobalParameterCollection.GetParamterNames(typeof(FloatParameter)));
				}else if(type == typeof(Vector3Parameter)){
					names.AddRange(stateMachine.parameters.Where(n=>n.GetType()==typeof(Vector2Parameter)).Select(p=>p.Name).ToList());
					names.AddRange(GlobalParameterCollection.GetParamterNames(typeof(Vector2Parameter)));
				}else if(type == typeof(Vector2Parameter)){
					names.AddRange(stateMachine.parameters.Where(n=>n.GetType()==typeof(Vector3Parameter)).Select(p=>p.Name).ToList());
					names.AddRange(GlobalParameterCollection.GetParamterNames(typeof(Vector3Parameter)));
				}
			}
			return names;
		}
		
		private static void ApplyString(object data){
			NamedParameter parameter = (NamedParameter)((object[])data) [0];
			string value = (string)((object[])data) [1];
			((StringParameter)parameter).Value=value;
		}
		
		private static void DrawField(ScriptableObject node,FieldInfo info){
			if(PreferencesEditor.GetBool(Preference.ShowParameterTooltips) && !string.IsNullOrEmpty(info.GetTooltip())){
				GUILayout.BeginVertical("box");
				GUILayout.Label(info.GetTooltip(),FsmStyles.WrappedLabel);
				GUILayout.EndVertical();
			}
			SerializedObject obj = new SerializedObject(node);
			obj.Update();
			GUILayout.BeginHorizontal();
			SerializedProperty prop=obj.FindProperty(info.Name);
			if(prop != null){
				EditorGUILayout.PropertyField(StateMachineGUI.GetSerializedProperty(obj,info.Name),info.GetInspectorGUIContent(),true);
			}

			if(info.IsComponentInfo()){
				if(GUILayout.Button(GUIContent.none,"MiniPullDown",GUILayout.Width(15))){
					GenericMenu toolsMenu = new GenericMenu();
					string[] names=ReflectionUtility.GetAllComponentNames();
					
					foreach(string s in names){
						string name=s;
						string displayName=s.Split('.').Last();
						toolsMenu.AddItem(new GUIContent(displayName),false,delegate() {
						
							obj.Update();
							prop.stringValue=name;
							obj.ApplyModifiedProperties();
						});
					}
					toolsMenu.DropDown(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,0,0));
					EditorGUIUtility.ExitGUI();
				}
			}
			
			Type reflectionReferenceType=info.GetReflectionReferenceFieldType(node);
			if(reflectionReferenceType!= null && GUILayout.Button(GUIContent.none,"MiniPullDown",GUILayout.Width(15))){
				GenericMenu toolsMenu = new GenericMenu();
			
				string[] names=GetReflectionTypeNames(info,info.RequiresWrite(),reflectionReferenceType);//Mark

				foreach(string s in names){
					string name=s;
					toolsMenu.AddItem(new GUIContent(s),false,delegate() {
						
						obj.Update();
						prop.stringValue=name;
						obj.ApplyModifiedProperties();
					});
				}
				
				if(names.Length == 0){
					toolsMenu.AddItem(new GUIContent("[None Found]"),false,delegate() {});
				}
				
				toolsMenu.DropDown(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,0,0));
				EditorGUIUtility.ExitGUI();
			}
			
			GUILayout.Space(24);
			GUILayout.EndHorizontal();
			obj.ApplyModifiedProperties();
		}

		private static List<string> GetCompoundFieldNames(Node node,FieldInfo[] fields){
			List<string> fieldNames = new List<string> ();
			for (int i=0; i< fields.Length; i++) {
				object[] attributes=CustomAttributeUtility.GetCustomAttributes(fields[i]);
				foreach (object attr in attributes) {
					if (attr.GetType () == typeof(CompoundAttribute)) {
						CompoundAttribute comp = attr as CompoundAttribute;
						int selectedEnumIndex = (int)fields [i].GetValue (node);
						if (comp.enumIndex == selectedEnumIndex) {
							fieldNames.AddRange (comp.fieldNames);
						}
					}
				}
			}
			return fieldNames;
		}

		private static void DrawDescription(Node node){
			string description = node.GetDescription ();
			if(PreferencesEditor.GetBool(Preference.ShowActionDescription) && !string.IsNullOrEmpty(description)){
				GUILayout.BeginVertical("box");
				GUILayout.Label(description,FsmStyles.WrappedLabel);
				GUILayout.EndVertical();
			}
		}

		private static bool ValidateNode(ScriptableObject node){
			if (node.GetType () == typeof(GetProperty) || node.GetType () == typeof(SetProperty)) {
				return true;			
			}
			FieldInfo[] fields = node.GetType ().GetFields (BindingFlags.Instance | BindingFlags.Public);
			for (int i=0; i< fields.Length; i++) {
				if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
					NamedParameter parameter = (NamedParameter)fields[i].GetValue (node);
					if(parameter == null){
						parameter=(NamedParameter)ScriptableObject.CreateInstance(fields[i].FieldType);
						fields[i].SetValue(node,parameter);
						if (EditorUtility.IsPersistent (node)) {
							AssetDatabase.AddObjectToAsset(parameter,node);
						}
						AssetDatabase.SaveAssets ();
					}
					if(!parameter.IsConstant && fields[i].IsFieldRequired () && parameter.Reference == fields [i].GetDefaultReference().ToString()){
						
						/*bool hideInInspector=false;
						foreach(object attr in fields[i].GetCustomAttributes(true)){
							if(attr.GetType() == typeof(HideInInspector)){
								hideInInspector=true;
							}
							
						}*/
						return fields[i].HideFieldInInspector();
					}
				}
			}
			return true;
		}

		private static Node copiedNode;

		public static bool Titlebar(Node node){
			int controlID = EditorGUIUtility.GetControlID ("Titlebar".GetHashCode(), FocusType.Passive);
			GUIContent content = new GUIContent (node.name.Replace("/","."), node.GetType ().GetDescription ());
			bool foldout = node.foldout;

			Rect position= GUILayoutUtility.GetRect(GUIContent.none, inspectorTitlebar);
			Rect rect = new Rect(position.x + (float)inspectorTitlebar.padding.left, position.y + (float)inspectorTitlebar.padding.top, 16f, 16f);
			Rect rect1 = new Rect(position.xMax - (float)inspectorTitlebar.padding.right - 2f - 16f, rect.y, 16f, 16f);
			Rect rect4 = rect1;
			rect4.x = rect4.x - 18f;
	
	
			
			Rect rect2 = new Rect(position.x + 2f + 2f + 16f*2, rect.y, 100f, rect.height)
			{
				xMax = rect4.xMin - 2f
			};
			Rect rect3 = new Rect(position.x + 16f, rect.y, 16f, 16f);

			node.enabled=GUI.Toggle (rect3, node.enabled,GUIContent.none);
			string url=node.GetType().GetInfoUrl();

			if (!ValidateNode (node)) {
				Rect rect5 = rect4;
				rect5.y += 1.0f;
				if(!string.IsNullOrEmpty(url)){
					rect5.x = rect5.x - 18f;
					rect2.xMax=rect5.x;
				}

				GUI.Label (rect5, errorIcon, inspectorTitlebarText);
			}
			if (GUI.Button(rect1, settingsIcon,inspectorTitlebarText))
			{
				GenericMenu toolsMenu = new GenericMenu();
				if(!node.enabled){
					toolsMenu.AddItem(new GUIContent("Enable"),false,delegate() {
						node.enabled=true;
						
					});
				}else{
					toolsMenu.AddItem(new GUIContent("Disable"),false,delegate() {
						node.enabled=false;
						
					});
				}
				toolsMenu.AddSeparator("");
				toolsMenu.AddItem(new GUIContent("Find Script"),false,delegate() {
					MonoScript[] monoScriptArray = (MonoScript[])Resources.FindObjectsOfTypeAll(typeof(MonoScript));
					Selection.activeObject=monoScriptArray.ToList().Find(x=>x.GetClass() == node.GetType());

				});
				toolsMenu.AddItem(new GUIContent("Edit Script"),false,delegate() {
					MonoScript[] monoScriptArray = (MonoScript[])Resources.FindObjectsOfTypeAll(typeof(MonoScript));
					Selection.activeObject=monoScriptArray.ToList().Find(x=>x.GetClass() == node.GetType());
					AssetDatabase.OpenAsset(Selection.activeObject);
					
				});
				toolsMenu.AddSeparator("");
				toolsMenu.AddItem(new GUIContent("Copy"),false,delegate() {
					copiedNode=node;
				});

				if(copiedNode != null && (copiedNode is StateAction && node is StateAction || copiedNode is StateCondition && node is StateCondition) ){
					toolsMenu.AddItem(new GUIContent("Paste After"),false,delegate() {
						State state=StateMachineWindow.StateMachineEditor.selectedStates[0];
						Node copy=(Node)ScriptableObject.Instantiate(copiedNode);
						copy.name=copy.name.Replace("(Clone)","");
						if (EditorUtility.IsPersistent (state)) {
							AssetDatabase.AddObjectToAsset(copy,state);
						}
						AssetDatabase.SaveAssets ();
						
						FieldInfo[] fields = copiedNode.GetType().GetFields ();
						for (int i=0; i< fields.Length; i++) {
							if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
								NamedParameter paramter=(NamedParameter)ScriptableObject.Instantiate((UnityEngine.Object)fields[i].GetValue(copiedNode));
								if (EditorUtility.IsPersistent (copy)) {
									AssetDatabase.AddObjectToAsset(paramter,copy);
								}
								AssetDatabase.SaveAssets();
								fields[i].SetValue(copy,paramter);
							}		
						}
						if(copy is StateAction){
							int curIndex=state.actions.FindIndex(x=>x==node);
							state.actions.Insert(curIndex+1,copy as StateAction);
						}else if(node is StateCondition){
							int curIndex=state.transitions[StateMachineWindow.StateMachineEditor.transitionIndex].conditions.FindIndex(x=>x==node);
							state.transitions[StateMachineWindow.StateMachineEditor.transitionIndex].conditions.Insert(curIndex+1,copy as StateCondition);
						}
						
						EditorUtility.SetDirty(state);
					});

					toolsMenu.AddItem(new GUIContent("Paste Before"),false,delegate() {
						State state=StateMachineWindow.StateMachineEditor.selectedStates[0];
						Node copy=(Node)ScriptableObject.Instantiate(copiedNode);
						copy.name=copy.name.Replace("(Clone)","");
						if (EditorUtility.IsPersistent (state)) {
							AssetDatabase.AddObjectToAsset(copy,state);
						}
						AssetDatabase.SaveAssets ();
						
						FieldInfo[] fields = copiedNode.GetType().GetFields ();
						for (int i=0; i< fields.Length; i++) {
							if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
								NamedParameter paramter=(NamedParameter)ScriptableObject.Instantiate((UnityEngine.Object)fields[i].GetValue(copiedNode));
								if (EditorUtility.IsPersistent (copy)) {
									AssetDatabase.AddObjectToAsset(paramter,copy);
								}
								AssetDatabase.SaveAssets();
								fields[i].SetValue(copy,paramter);
							}		
						}
						if(copy is StateAction){
							int curIndex=state.actions.FindIndex(x=>x==node);
							state.actions.Insert(curIndex,copy as StateAction);
						}else if(node is StateCondition){
							int curIndex=state.transitions[StateMachineWindow.StateMachineEditor.transitionIndex].conditions.FindIndex(x=>x==node);
							state.transitions[StateMachineWindow.StateMachineEditor.transitionIndex].conditions.Insert(curIndex,copy as StateCondition);
						}
						
						EditorUtility.SetDirty(state);
					});

					toolsMenu.AddItem(new GUIContent("Replace"),false,delegate() {
						State state=StateMachineWindow.StateMachineEditor.selectedStates[0];
						Node copy=(Node)ScriptableObject.Instantiate(copiedNode);
						copy.name=copy.name.Replace("(Clone)","");
						if (EditorUtility.IsPersistent (state)) {
							AssetDatabase.AddObjectToAsset(copy,state);
						}
						AssetDatabase.SaveAssets ();
						
						FieldInfo[] fields = copiedNode.GetType().GetFields ();
						for (int i=0; i< fields.Length; i++) {
							if(fields[i].FieldType.IsSubclassOf(typeof(NamedParameter))){
								NamedParameter paramter=(NamedParameter)ScriptableObject.Instantiate((UnityEngine.Object)fields[i].GetValue(copiedNode));
								if (EditorUtility.IsPersistent (copy)) {
									AssetDatabase.AddObjectToAsset(paramter,copy);
								}
								AssetDatabase.SaveAssets();
								fields[i].SetValue(copy,paramter);
							}		
						}
						if(copy is StateAction){
							int curIndex=state.actions.FindIndex(x=>x==node);
							state.actions.Insert(curIndex,copy as StateAction);
						}else if(node is StateCondition){
							int curIndex=state.transitions[StateMachineWindow.StateMachineEditor.transitionIndex].conditions.FindIndex(x=>x==node);
							state.transitions[StateMachineWindow.StateMachineEditor.transitionIndex].conditions.Insert(curIndex,copy as StateCondition);
						}
						
						EditorUtility.SetDirty(state);
						StateMachineUtility.RemoveNode(StateMachineWindow.StateMachineEditor.selectedStates[0],node);
						copiedNode=copy;
					});

				}else{
					toolsMenu.AddDisabledItem(new GUIContent("Paste After"));
					toolsMenu.AddDisabledItem(new GUIContent("Paste Before"));
					toolsMenu.AddDisabledItem(new GUIContent("Replace"));
				}

				toolsMenu.AddSeparator("");
				toolsMenu.AddItem(new GUIContent("Remove"),false,delegate() {
					StateMachineUtility.RemoveNode(StateMachineWindow.StateMachineEditor.selectedStates[0],node);
					
				});

				toolsMenu.DropDown(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,0,0));
				EditorGUIUtility.ExitGUI();
			}
			if (!string.IsNullOrEmpty(url) && GUI.Button(rect4, helpIcon,inspectorTitlebarText))
			{
				Application.OpenURL(url);
			}
			
			EventType eventType = Event.current.type;
			if (eventType != EventType.MouseDown) {
				if (eventType == EventType.Repaint)
				{
					inspectorTitlebar.Draw (position, GUIContent.none, controlID, foldout);
					inspectorTitlebarText.Draw (rect2, content, controlID, foldout);	
				}
			}
			position.width = 15;
			bool flag = DoToggleForward(position,controlID, foldout,GUIContent.none,GUIStyle.none);
			if (flag != foldout) {
				node.foldout=flag;	
			}
			return flag;
		}
		
		private static bool DoToggleForward(Rect position, int id, bool value, GUIContent content, GUIStyle style)
		{
			Event ev = Event.current;
			if (ev.MainActionKeyForControl(id))
			{
				value = !value;
				ev.Use();
				GUI.changed = true;
			}
			if (EditorGUI.showMixedValue)
			{
				style = "ToggleMixed";
			}
			EventType eventType = ev.type;
			bool flag = (ev.type != EventType.MouseDown ? false : ev.button != 0);
			if (flag)
			{
				ev.type = EventType.Ignore;
			}
			bool flag1 = GUI.Toggle(position, id, (!EditorGUI.showMixedValue ? value : false), content, style);
			if (flag)
			{
				ev.type = eventType;
			}
			else if (ev.type != eventType)
			{
				GUIUtility.keyboardControl = id;
			}
			return flag1;
		}

		private static bool MainActionKeyForControl(this Event evt, int controlId)
		{
			if (GUIUtility.keyboardControl != controlId)
			{
				return false;
			}
			bool flag = (evt.alt || evt.shift || evt.command ? true : evt.control);
			if (evt.type == EventType.KeyDown && evt.character == ' ' && !flag)
			{
				evt.Use();
				return false;
			}
			return (evt.type != EventType.KeyDown || evt.keyCode != KeyCode.Space && evt.keyCode != KeyCode.Return && evt.keyCode != KeyCode.KeypadEnter ? false : !flag);
		}
	
		#region ContextMenu
		private static State copiedState;
		public static void StateContextMenu(State state, StateMachineEditor editor){
			if (!state.position.Contains (Event.current.mousePosition) || Event.current.type != EventType.MouseDown || Event.current.button != 1 || Event.current.clickCount != 1){
				return;
			}	
			GenericMenu genericMenu = new GenericMenu ();
			genericMenu.AddItem (new GUIContent ("Make Transition"), false, delegate() {
				editor.StartTransition(state);
			});
			
			bool anyState=state.GetType()== typeof(AnyState);
			
			if (!state.isDefaultState && !anyState) {
				genericMenu.AddItem (new GUIContent ("Set As Default"), false,delegate() {
					StateMachineUtility.SetAsDefaultState(state,editor.ActiveStateMachine);
				});
			} else {
				genericMenu.AddDisabledItem (new GUIContent ("Set As Default"));
			}
			
			
			if (!(state is AnyState)) {
				genericMenu.AddItem (new GUIContent ("Copy"), false, delegate() {
					copiedState = state;
				});
			}
			
			if(!anyState){
				genericMenu.AddItem (new GUIContent ("Delete"), false,delegate() {
					StateMachineUtility.DeleteState(state,editor.ActiveStateMachine);
					editor.UpdateSelection();
				});
			}else{
				genericMenu.AddDisabledItem (new GUIContent ("Delete"));
			}
			genericMenu.ShowAsContext ();
			Event.current.Use ();
		}

		private static StateMachine copyStateMachine;
		public static void CanvasContextMenu(StateMachineEditor editor){
			if (Event.current.type != EventType.MouseDown || Event.current.button != 1 || Event.current.clickCount != 1){
				return;
			}	
			Vector3 mousePosition=Event.current.mousePosition;
			GenericMenu genericMenu = new GenericMenu ();
			if (editor.ActiveStateMachine != null) {
				genericMenu.AddItem (new GUIContent ("Create State"), false, delegate() {
					StateMachineUtility.CreateState (mousePosition, editor.ActiveStateMachine);
				});
			} else {
				genericMenu.AddDisabledItem(new GUIContent("Create State"));			
			}
			if (copiedState != null) {
				genericMenu.AddItem (new GUIContent ("Paste State"), false, delegate() {
					State state=StateMachineUtility.CreateState(mousePosition,editor.ActiveStateMachine);
					state.name=copiedState.name;
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

			genericMenu.AddSeparator("");
			genericMenu.AddItem (new GUIContent ("Create StateMachine"), false, delegate() {
				StateMachine stateMachine=StateMachineUtility.CreateStateMachine(true);
				editor.ActiveStateMachine=stateMachine;
			});

			if (editor.ActiveStateMachine != null) {
				genericMenu.AddItem (new GUIContent ("Copy StateMachine"), false, delegate() {
					copyStateMachine = editor.ActiveStateMachine;
				});
			} else {
				genericMenu.AddDisabledItem(new GUIContent("Copy StateMachine"));			
			}

			if (copyStateMachine != null && editor.ActiveStateMachine != copyStateMachine) {
				genericMenu.AddItem (new GUIContent ("Paste StateMachine"), false, delegate() {
					StateMachine.Copy (copyStateMachine, editor.ActiveStateMachine, true);
				});			
			} else {
				genericMenu.AddDisabledItem(new GUIContent("Paste StateMachine"));
			}
			if(Selection.activeGameObject != null){
				genericMenu.AddItem (new GUIContent ( "Add StateMachine"), false, delegate() {
					StateMachineUtility.AddStateMachine(Selection.activeGameObject,editor.ActiveStateMachine);
				});
			}else{
				genericMenu.AddDisabledItem(new GUIContent("Add StateMachine"));
			}
			genericMenu.ShowAsContext ();
			Event.current.Use ();
		}

		#endregion
	}
}