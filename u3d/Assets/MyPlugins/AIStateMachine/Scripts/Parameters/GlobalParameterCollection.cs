using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace StateMachine{
	[System.Serializable]
	public class GlobalParameterCollection : ScriptableObject {
		public List<NamedParameter> parameters;

		private static GlobalParameterCollection collection;
		public static GlobalParameterCollection GetCollection(){
			if (collection == null) {
				collection=Resources.Load<GlobalParameterCollection>("GlobalParameterCollection");
				/*if(Application.isPlaying){
					GlobalParameterCollection mCollection=ScriptableObject.CreateInstance<GlobalParameterCollection>();
					mCollection.parameters=new List<NamedParameter>();
					if(collection != null){
						for (int i=0; i<collection.parameters.Count; i++) {
							NamedParameter parameter = (NamedParameter)ScriptableObject.Instantiate (collection.parameters [i]);
							if (mCollection.parameters == null) {
								mCollection.parameters = new List<NamedParameter> ();
							}
							mCollection.parameters.Add (parameter);
						}
					}
					collection=mCollection;
				}*/
			}
			return collection;
		}

		public static NamedParameter GetParameter(string name){
			GlobalParameterCollection mCollection = GetCollection ();
			if (mCollection == null) {
				return null;			
			}
			foreach (NamedParameter parameter in mCollection.parameters) {
				if(parameter.Name==name){
					return parameter;
				}
			}
			return null;
		}

		public static List<NamedParameter> GetParamters(){
			GlobalParameterCollection mCollection = GetCollection ();
			if (mCollection == null) {
				return new List<NamedParameter>();			
			}
			return mCollection.parameters;
		}

		public static List<string> GetParamterNames(params Type[] types){
			GlobalParameterCollection mCollection = GetCollection ();
			List<string> names = new List<string> ();
			if (mCollection == null) {
				return names;			
			}
			foreach (NamedParameter parameter in mCollection.parameters) {
				if(types.Length==0){
					names.Add(parameter.Name);
				}else{
					foreach(Type type in types){
						if(parameter.GetType()==type){
							names.Add(parameter.Name);
						}
					}	
				}
			}
			return names;
		}

	}
}