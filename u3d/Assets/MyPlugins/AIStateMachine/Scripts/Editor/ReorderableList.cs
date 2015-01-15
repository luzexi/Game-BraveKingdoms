using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;

[System.Serializable]
public class ReorderableList {
	public delegate void AddCallbackDelegate();
	public ReorderableList.AddCallbackDelegate onAddCallback;
	public delegate void RemoveCallbackDelegate(int index);
	public ReorderableList.RemoveCallbackDelegate onRemoveCallback;
	public delegate void ElementCallbackDelegate(int index);
	public ReorderableList.ElementCallbackDelegate drawElementCallback;
	public delegate void SelectCallbackDelegate(int index);
	public ReorderableList.SelectCallbackDelegate onSelectCallback;
	public delegate void OnHeaderClick();
	public ReorderableList.OnHeaderClick onHeaderClick;
	public delegate void OnBeforeListItems();
	public ReorderableList.OnBeforeListItems onBeforeListItems;
	public delegate void OnHeaderContent(Rect rect);
	public ReorderableList.OnHeaderContent onDrawHeaderContent;
	private string title;
	public IList items;
	private bool draggable;
	private int selectedIndex = -2;
	private bool isDragging;
	private bool displayAdd;
	
	public ReorderableList(string title):this(null,title,false,false){
		
	}
	
	public ReorderableList(IList items, string title,bool draggable):this(items,title,draggable,true){
		
	}
	
	public ReorderableList(IList items, string title,bool draggable, bool displayAdd){
		this.title = title;
		this.items = items;
		this.draggable = draggable;
		this.displayAdd = displayAdd;
	}
	
	public void DoList(){
		if (DoListHeader ()) {
			if(onBeforeListItems != null){
				GUILayout.BeginVertical ((GUIStyle)"PopupCurveSwatchBackground", GUILayout.ExpandWidth (true));
				onBeforeListItems();
				GUILayout.EndVertical();
			}
			DoListItems();
		}
	}
	
	public bool DoListHeader(){
		bool foldOut = EditorPrefs.GetBool (title, false);
		Rect rect = GUILayoutUtility.GetRect (new GUIContent (title), "flow overlay header lower left", GUILayout.ExpandWidth (true));
		rect.x -= 1;
		rect.width += 2;
		Rect rect2 = new Rect (rect.width-10,rect.y+2,25,25);

		if (GUI.Button (rect2,"","label") && onAddCallback != null && displayAdd) {
			onAddCallback();
			if(onSelectCallback!= null){
				onSelectCallback(items.Count);
			}
		}


		
		if (GUI.Button (rect, title, "flow overlay header lower left")) {
			if(Event.current.button==0){
				EditorPrefs.SetBool (title, !foldOut);	
			}
			if(Event.current.button == 1 && onHeaderClick != null){
				onHeaderClick();
			}
		}
		
		if (displayAdd) {
			GUI.Label (rect2, EditorGUIUtility.FindTexture("Toolbar Plus"));
		}

		if (onDrawHeaderContent != null) {
			onDrawHeaderContent(rect);		
		}

		return foldOut;
	}
	private Rect draggingLineRect;
	int swapIndex=-1;
	[SerializeField]
	private GUIStyle elementBackground;
	public GUIStyle ElementBackground{
		get{
			if (elementBackground == null) {
				elementBackground = new GUIStyle ("PopupCurveSwatchBackground");
				elementBackground.padding = new RectOffset ();
			}
			return elementBackground;
		}
	}
	private List<Rect> elementRects = new List<Rect> ();
	private void DoListItems(){
		elementRects.Clear ();

		GUILayout.BeginVertical (ElementBackground);

		if (items != null && items.Count > 0) {
			for (int i=0; i< items.Count; i++) {
				DrawListElement(i);
				Rect lastRect=GUILayoutUtility.GetLastRect();
				elementRects.Add(lastRect);
				if(isDragging){
					EditorGUIUtility.AddCursorRect (lastRect, MouseCursor.Pan);	
				}
			}
		} else {
			GUILayout.Label("List is Empty");
		}
		GUILayout.Space (2);
		GUILayout.EndVertical ();

		DoListEvents (elementRects);
	}
	
	private Rect titleRect;
	private void DoListEvents(List<Rect> rects){
		if (items == null) {
			return;		
		}
		for (int i=0; i< items.Count; i++) {
			Rect elementRect=rects[i];

			switch (Event.current.type) {
			case EventType.MouseDown:
				if (elementRect.Contains (Event.current.mousePosition) && Event.current.button == 0) {
					titleRect=elementRect;
					titleRect.height=17;

					if (onSelectCallback != null) {
						onSelectCallback (i);
					}
					GUI.FocusControl (title + i);
					if (draggable && items.Count > 1) {
						selectedIndex = i;
						isDragging = true;
						draggingLineRect=new Rect(600000,60000,0,0);

					}
					Event.current.Use();
				}
				if (elementRect.Contains (Event.current.mousePosition) && Event.current.button == 1) {
					GenericMenu genericMenu = new GenericMenu ();
					genericMenu.AddItem (new GUIContent ("Remove"), false, RemoveItem, i);
					genericMenu.AddItem (new GUIContent ("Move Up"), false, MoveUp, i);
					genericMenu.AddItem (new GUIContent ("Move Down"), false, MoveDown, i);
					genericMenu.ShowAsContext ();
				}
				break;
			case EventType.MouseUp:
			
				if(isDragging){
					isDragging = false;
					Event.current.Use();
				}
				break;
			case EventType.MouseDrag:
				if (elementRect.Contains (Event.current.mousePosition) && Event.current.button == 0 && items.Count > 1 && draggable) {
					if (Event.current.mousePosition.y < elementRect.y + elementRect.height * 0.5f) {//Top items[i]
						draggingLineRect = new Rect (elementRect.x, elementRect.y, elementRect.width, 1);
						swapIndex = (selectedIndex > i ? i : i - 1);
					}
					if (Event.current.mousePosition.y > elementRect.y + elementRect.height * 0.5f) {//Buttom items[i]
						draggingLineRect = new Rect (elementRect.x, elementRect.y + elementRect.height + 2.0f, elementRect.width, 1);
						swapIndex = (selectedIndex > i ? i + 1 : i);
					}
					//GUI.FocusControl (title + i);
					Event.current.Use();
				}
				break;
			}
		}
	
		EventType eventType=Event.current.type;
		if (eventType != EventType.MouseDown) {
			if (eventType == EventType.Repaint && Event.current.button==0 && isDragging)
			{
				GUIStyle inspectorTitlebar = "IN Title";
				inspectorTitlebar.Draw (titleRect, GUIContent.none,true,true,true,true);
				
			}
		}

		if (swapIndex != -1 && !isDragging && draggable && selectedIndex != -1) {
			items.MoveTo(selectedIndex, swapIndex);
			swapIndex=-1;
		}

		if (!isDragging) {
			selectedIndex=-1;	
		}
	}

	private void DrawListElement(int index){
		//GUILayout.BeginHorizontal ();
		GUILayout.BeginVertical ();
		//GUILayout.Box(GUIContent.none,"PopupCurveSwatchBackground",GUILayout.ExpandWidth(true),GUILayout.Height(1));
		if(isDragging){
			GUI.backgroundColor=new Color(0,0,0.8f,1f);
			GUI.Box(draggingLineRect,GUIContent.none);
			GUI.backgroundColor=Color.white;
		}
		if(drawElementCallback != null){
			drawElementCallback(index);
		}
		//GUILayout.Space (3);
		GUILayout.EndVertical ();
		//GUILayout.EndHorizontal ();
	}
	
	private void MoveUp(object index){
		items.Move ((int)index, 1);
	}
	
	
	private void MoveDown(object index){
		items.Move ((int)index, 0);
	}
	
	private void RemoveItem(object index){
		if (onRemoveCallback != null) {
			onRemoveCallback ((int)index);	
		} else {
			items.RemoveAt ((int)index);
		}
	}
}
