using UnityEngine;
using UnityEditor;
using System.Collections;

namespace StateMachine{
	[System.Serializable]
	public class GraphEditor: ScriptableObject {
		public const float MaxCanvasSize=50000;
		private Color gridMinorColorDark = new Color(0f, 0f, 0f, 0.18f);
		private Color gridMajorColorDark = new Color(0f, 0f, 0f, 0.28f);
		public Vector2 scrollPosition= new Vector2(25000,25000);
		public Vector2 offset;
		public Rect graphRect;
		private  Material material;
		public Rect viewRect= new Rect(0,0,50000,50000);

		public void BeginGraphGUI(){
			if (Event.current.type == EventType.Repaint){
				UnityEditor.Graphs.Styles.graphBackground.Draw(graphRect, false, false, false, false);
			}
			DrawGrid ();
			Vector2 scroll = GUI.BeginScrollView (graphRect, scrollPosition, viewRect,GUIStyle.none, GUIStyle.none);
			offset = offset - (scroll - scrollPosition);
			scrollPosition = scroll;

		}

		public void EndGraphGUI(){
			DragGraph ();
			GUI.EndScrollView ();
		}


		private void DragGraph(){
			int controlID = GUIUtility.GetControlID(GUIControl.GetID (Control.DragGraph),FocusType.Passive);
			Event ev = Event.current;
			if (ev.button != 2){
				return;
			}
			switch (ev.rawType) {
			case EventType.mouseDown:
				GUIUtility.hotControl = controlID;
				ev.Use();
				break;
			case EventType.mouseUp:
				if (GUIUtility.hotControl == controlID)
				{
					GUIUtility.hotControl = 0;
					ev.Use();
				}
				break;
			case EventType.mouseDrag:
				if (GUIUtility.hotControl == controlID)
				{
					offset+=ev.delta;
					scrollPosition -= ev.delta;
					ev.Use();
				}
				break;
			}
		}
		
		private void DrawGrid()
		{
			if (Event.current.type != EventType.repaint) {
				return;
			}
			
			GL.PushMatrix();
			GL.Begin(1);
			this.DrawGridLines(12.0f, gridMinorColorDark);
			this.DrawGridLines(120.0f, gridMajorColorDark);
			GL.End();
			GL.PopMatrix();
		}
		
		private void DrawGridLines(float gridSize, Color gridColor)
		{
			GL.Color(gridColor);
			for (float i = this.graphRect.x+(offset.x<0f?gridSize:0f) + this.offset.x % gridSize ; i < this.graphRect.x + this.graphRect.width; i = i + gridSize)
			{
				this.DrawLine(new Vector2(i, this.graphRect.y), new Vector2(i, this.graphRect.y + this.graphRect.height));
			}
			for (float j = this.graphRect.y+(offset.y<0f?gridSize:0f) + this.offset.y % gridSize; j < this.graphRect.y + this.graphRect.height; j = j + gridSize)
			{
				this.DrawLine(new Vector2(this.graphRect.x, j), new Vector2(this.graphRect.x + this.graphRect.width, j));
			}
		}
		
		private void DrawLine(Vector2 p1, Vector2 p2)
		{
			GL.Vertex(p1);
			GL.Vertex(p2);
		}
		
		public void DrawConnection (Vector3 start, Vector3 end,Color color, int arrows,bool offset)
		{
			if (Event.current.type != EventType.repaint) {
				return;
			}
			
			Vector3 cross = Vector3.Cross ((start - end).normalized, Vector3.forward);
			if (offset) {
				start = start + cross * 6;
				end = end + cross * 6;
			}
			
			Texture2D tex = (Texture2D)UnityEditor.Graphs.Styles.connectionTexture.image;
			Handles.color = color;
			Handles.DrawAAPolyLine (tex, 5.0f, new Vector3[] { start, end });
			
			Vector3 vector3 = end - start;
			Vector3 vector31 = vector3.normalized;
			Vector3 vector32 = (vector3 * 0.5f) + start;
			vector32 = vector32 - (cross * 0.5f);
			Vector3 vector33 = vector32 + vector31;
			
			for (int i=0; i<arrows; i++) {
				Vector3 center= vector33+vector31*10.0f*i+vector31*5.0f-vector31*arrows*5.0f;
				DrawArrow (color, cross, vector31, center,6.0f);
			}
		}
		
		private  void DrawArrow (Color color, Vector3 cross, Vector3 direction, Vector3 center, float size)
		{
			Rect rect = graphRect;
			rect.y +=  scrollPosition.y-15;
			rect.x += scrollPosition.x;
			if (!rect.Contains (center)) {
				return;	
			}
			Vector3[] vector3Array = new Vector3[] {
				center + (direction * size),
				(center - (direction * size)) + (cross * size),
				(center - (direction * size)) - (cross * size),
				center + (direction * size)
			};
			
			Color color1 = color;
			color1.r *= 0.8f;
			color1.g *= 0.8f;
			color1.b *= 0.8f;
			
			CreateMaterial ();
			material.SetPass (0);
			
			GL.Begin (GL.TRIANGLES);
			GL.Color (color1);
			GL.Vertex (vector3Array [0]);
			GL.Vertex (vector3Array [1]);
			GL.Vertex (vector3Array [2]);
			GL.End ();
		}

		private  void CreateMaterial ()
		{
			if (material != null)
				return;
			
			material = new Material ("Shader \"Lines/Colored Blended\" {" +
			                         "SubShader { Pass { " +
			                         "    Blend SrcAlpha OneMinusSrcAlpha " +
			                         "    ZWrite Off Cull Off Fog { Mode Off } " +
			                         "    BindChannels {" +
			                         "      Bind \"vertex\", vertex Bind \"color\", color }" +
			                         "} } }");
			material.hideFlags = HideFlags.HideAndDontSave;
			material.shader.hideFlags = HideFlags.HideAndDontSave;
		}
	}
}