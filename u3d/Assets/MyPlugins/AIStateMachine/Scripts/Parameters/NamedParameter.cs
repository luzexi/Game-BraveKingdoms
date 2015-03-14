using UnityEngine;
using System.Collections;

namespace StateMachine{
	[System.Serializable]
	public class NamedParameter : ScriptableObject {

		/*[SerializeField]
		private object temp;
		public object Temp{
			get{return temp;}
			set{temp=value;}
		}*/

		[SerializeField]
		private bool isConstant=true;
		public bool IsConstant{
			get{
				return isConstant;
			}
			set{
				isConstant=value;
			}
		}
		
		[SerializeField]
		private string reference;
		public string Reference{
			get {
				return reference;
			}
			set{
				reference=value;
			}
		}

		[SerializeField]
		private string group;
		public string Group{
			get{
				return group;
			}
			set{
				group=value;
			}
		}

		[SerializeField]
		private string parameterName;
		public string Name{
			get{
				return parameterName;
			}
			set{
				parameterName=value;
			}
		}
		[System.NonSerialized]
		public StateMachine stateMachine;
		[System.NonSerialized]
		public bool isNone;

		protected virtual void OnEnable(){
			hideFlags = HideFlags.HideInHierarchy;
		}
	}
}
