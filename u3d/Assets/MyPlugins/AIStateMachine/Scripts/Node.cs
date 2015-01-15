using UnityEngine;
using System.Collections;

namespace StateMachine{
	[System.Serializable]
	public class Node : ScriptableObject {
		[HideInInspector]
		public bool enabled=true;
		[HideInInspector]
		[System.NonSerialized]
		public bool foldout=true;

		private void OnEnable(){
			hideFlags = HideFlags.HideInHierarchy;
		}
	}
}