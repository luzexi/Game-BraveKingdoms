using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
//using System.Net;
//using System.IO;

namespace StateMachine{
	public static class UnityTools {
		
		public static bool CatmullRom(List<Vector3> inCoordinates, out List<Vector3> outCoordinates, int samples, bool includeEndPoints)
		{
			if ((!includeEndPoints && inCoordinates.Count < 4) || (includeEndPoints && inCoordinates.Count < 2))
			{
				outCoordinates = null;
				return false;
			}
			if (includeEndPoints && inCoordinates.Count >= 2)
			{
				inCoordinates.Insert(0, inCoordinates[0]);
				inCoordinates.Insert(inCoordinates.Count - 1, inCoordinates[inCoordinates.Count - 1]);
			}
			List<Vector3> results = new List<Vector3>();
			for (int n = 1; n < inCoordinates.Count - 2; n++)
				for (int i = 0; i < samples; i++)
					results.Add(PointOnCurve(inCoordinates[n - 1], inCoordinates[n], inCoordinates[n + 1], inCoordinates[n + 2], (1f / samples) * i ));
			results.Add(inCoordinates[inCoordinates.Count - 2]);
			outCoordinates = results;
			return true;
		}
		
		public static Vector3 PointOnCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			Vector3 result = new Vector3();
			float t0 = ((-t + 2f) * t - 1f) * t * 0.5f;
			float t1 = (((3f * t - 5f) * t) * t + 2f) * 0.5f;
			float t2 = ((-3f * t + 4f) * t + 1f) * t * 0.5f;
			float t3 = ((t - 1f) * t * t) * 0.5f;
			result.x = p0.x * t0 + p1.x * t1 + p2.x * t2 + p3.x * t3;
			result.y = p0.y * t0 + p1.y * t1 + p2.y * t2 + p3.y * t3;
			result.z = p0.z * t0 + p1.z * t1 + p2.z * t2 + p3.z * t3;
			return result;
		}

		public static void InvertList(ref  List<Vector3> list)
		{
			List<Vector3> pInverted = new List<Vector3> ();
			for (int i = list.Count - 1; i >= 0; i--) {
				pInverted.Add (list [i]);
			}
			list = pInverted;
		}

		public static string UppercaseFirst(string s)
		{
			if (string.IsNullOrEmpty(s)){
				return string.Empty;
			}
			return char.ToUpper(s[0]) + s.Substring(1);
		}


		public static Type GetType( string TypeName )
		{
			if(string.IsNullOrEmpty(TypeName)){
				return null;
			}
			// Try Type.GetType() first. This will work with types defined
			// by the Mono runtime, in the same assembly as the caller, etc.
			var type = Type.GetType( TypeName );
			
			// If it worked, then we're done here
			if( type != null )
				return type;

			type=Type.GetType(TypeName+", UnityEngine");

			if( type != null )
				return type;

			/*
			// If the TypeName is a full name, then we can try loading the defining assembly directly
			if( TypeName.Contains( "." ) )
			{
				
				// Get the name of the assembly (Assumption is that we are using 
				// fully-qualified type names)
				var assemblyName = TypeName.Substring( 0, TypeName.IndexOf( '.' ) );
				
				// Attempt to load the indicated Assembly
				Assembly assembly=null;// Assembly.Load( assemblyName );
				Assembly[] assemblies= System.AppDomain.CurrentDomain.GetAssemblies(); 
				foreach(Assembly mAs in assemblies){
					if(mAs.GetName().Name== assemblyName){
						assembly=mAs;
					}
				}
				if( assembly == null )
					return null;
				
				// Ask that assembly to return the proper Type
				type = assembly.GetType( TypeName );
				if( type != null )
					return type;
				
			}
			
			// If we still haven't found the proper type, we can enumerate all of the 
			// loaded assemblies and see if any of them define the type
			//var currentAssembly = Assembly.GetExecutingAssembly();
			var referencedAssemblies =System.AppDomain.CurrentDomain.GetAssemblies();// currentAssembly.GetReferencedAssemblies();
			foreach( var assembly in referencedAssemblies )
			{
				
				// Load the referenced assembly
				//var assembly = Assembly.Load( assemblyName );
				if( assembly != null )
				{
					// See if that assembly defines the named type
					type = assembly.GetType( TypeName );
					if( type != null )
						return type;
				}
			}*/
			
			// The type just couldn't be found...
			return null;
		}

		public static void SendMonoMessage(string method, params object[] parameters)
		{
			List<GameObject> objectsToCall = new List<GameObject>();
			Component[] targetComponents = (Component[])GameObject.FindObjectsOfType(typeof(MonoBehaviour));
			for (int index = 0; index < targetComponents.Length; index++)
			{
				objectsToCall.Add(targetComponents[index].gameObject);
			}
			
			foreach (GameObject gameObject in objectsToCall)
			{
				if (parameters != null && parameters.Length == 1)
				{
					gameObject.SendMessage(method, parameters[0], SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					gameObject.SendMessage(method, parameters, SendMessageOptions.DontRequireReceiver);
				}
			}
		}

		/*public static void SendMessage(this GameObject gameObject, string name, params object[] parameters) {

			Type[] types = new Type[parameters.Length];
			for (int i = 0; i < parameters.Length; i++) {
				types[i] = parameters[i].GetType();
			}

			MonoBehaviour[] behaviours = gameObject.GetComponents<MonoBehaviour> ();

			for (int i=0; i< behaviours.Length; i++) {
				MethodInfo mInfo = behaviours[i].GetType ().GetMethod (name, types);
				
				if (mInfo != null) {
					mInfo.Invoke (behaviours[i], parameters);
				}
			}
		}*/

		/*public static string GetHtmlFromUri(string resource)
		{
			string html = string.Empty;
			System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(resource);
			try
			{
				using (System.Net.HttpWebResponse resp = (System.Net.HttpWebResponse)req.GetResponse())
				{
					bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
					if (isSuccess)
					{
						using (System.IO.StreamReader reader = new System.IO.StreamReader(resp.GetResponseStream()))
						{
							//We are limiting the array to 80 so we don't have
							//to parse the entire html document feel free to 
							//adjust (probably stay under 300)
							char[] cs = new char[80];
							reader.Read(cs, 0, cs.Length);
							foreach(char ch in cs)
							{
								html +=ch;
							}
						}
					}
				}
			}
			catch
			{
				return "";
			}
			return html;
		}*/

		public static T[] FindAll<T>(bool includeInactive)where T:Component{
			if (includeInactive) {
				UnityEngine.Object[] tempList = Resources.FindObjectsOfTypeAll (typeof(T));
				List<T> realList = new List<T> ();
				
				foreach (UnityEngine.Object obj in tempList) {
					if (obj is T) {
						if (obj.hideFlags == HideFlags.None)
							realList.Add ((T)obj);
					}
				}
				return realList.ToArray ();
			} else {
				return (T[])MonoBehaviour.FindObjectsOfType(typeof(T));			
			}
		}


		/*public static MethodInfo GetMethod(this Type type,string name,Type[] types){
			#if NETFX_CORE
			return type.GetTypeInfo().GetMethod (name,types);
			#else
			return type.GetMethod (name,types);
			#endif
		}*/

		public static Type GetParameterType(this Type type){
			if (type == typeof(float)) {
				return typeof(FloatParameter);			
			} else if (type == typeof(int)) {
				return typeof(IntParameter);
			} else if (type == typeof(string)) {
				return typeof(StringParameter);
			} else if (type == typeof(Vector2)) {
				return typeof(Vector2Parameter);
			} else if (type == typeof(Vector3)) {
				return typeof(Vector3Parameter);
			} else if (type == typeof(UnityEngine.Object) || type.IsSubclassOf (typeof(UnityEngine.Object))) {
				return typeof(ObjectParameter);
			} else if (type == typeof(List<>)) {
				return typeof(ListParameter);
			} else if (type == typeof(Color)) {
				return typeof(ColorParameter);
			} 
			else {
				return typeof(SystemObjectParameter);
			}
		}
	}
}