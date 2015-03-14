using UnityEngine;
using System.Collections;

namespace StateMachine{
	public class AddToParameterCollection : MonoBehaviour {
		public string paramterName;
		void Awake () {
			ObjectParameter parameter = GlobalParameterCollection.GetParameter (paramterName) as ObjectParameter;
			parameter.Value = gameObject;
		}
	}
}
