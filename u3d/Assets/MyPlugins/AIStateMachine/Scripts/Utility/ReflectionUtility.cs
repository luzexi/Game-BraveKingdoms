using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine{
	public static class ReflectionUtility  {

		public static FieldInfo[] GetFields(this Type type){
			#if NETFX_CORE
			return type.GetRuntimeFields ().ToArray();
			#else
			return type.GetFields ();
			#endif
		}
		
		public static FieldInfo GetField(this Type type,string name){
			#if NETFX_CORE
			return type.GetRuntimeField (name);
			#else
			return type.GetField (name);
			#endif
		}
		
		public static PropertyInfo GetProperty(this Type type,string name){
			#if NETFX_CORE
			return type.GetRuntimeProperty (name);
			#else
			return type.GetProperty (name);
			#endif
		}
		
		public static bool IsSubclassOf(this Type type,Type c){
			#if NETFX_CORE
			return type.GetTypeInfo().IsSubclassOf(c);
			#else
			return type.IsSubclassOf(c);
			#endif
		}

		public static string[] GetAllComponentNames(){
			IEnumerable<Type> types= AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(typeof(Component)));
			return types.Select (x => x.FullName).ToArray();
		}

		public static string[] GetFieldNames(this Type type,bool includePrimitive, params Type[] typeMatch ){
			FieldInfo[] fields = type
				.GetFields (BindingFlags.Public | BindingFlags.Instance)
					.ToArray();
			List<string> selected = new List<string> ();
			foreach (FieldInfo info in fields) {
			//	if(typeMatch.Contains(info.FieldType)|| info.FieldType == typeof(UnityEngine.Object) || info.FieldType.IsSubclassOf(typeof(UnityEngine.Object)) || (includePrimitive && info.FieldType.IsPrimitive) || info.FieldType.IsGenericType && info.FieldType.GetGenericTypeDefinition() == typeof(List<>) ){
					selected.Add(info.Name);

			//	}		
			}
			return selected.ToArray ();
		}
		
		public static string[] GetPropertyNames(this Type type,bool includePrimitive,bool requiresWrite, params Type[] typeMatch ){
			PropertyInfo[] properties = type
				.GetProperties (BindingFlags.Public | BindingFlags.Instance)
					.ToArray();
			List<string> selected = new List<string> ();
			foreach (PropertyInfo info in properties) {
			//	if(typeMatch.Contains(info.PropertyType) || info.PropertyType == typeof(UnityEngine.Object) || info.PropertyType.IsSubclassOf(typeof(UnityEngine.Object)) || (includePrimitive && info.PropertyType.IsPrimitive || info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(List<>))){
					if(requiresWrite){
						if(info.CanWrite){
							selected.Add(info.Name);
						}
					}else{
						selected.Add(info.Name);
					}
			//	}		
			}
			return selected.ToArray ();
		}
		
		public static string[] GetPropertyAndFieldNames(this Type type,bool includePrimitive, bool requiresWrite, params Type[] typeMatch ){
			List<string> names =new List<string>( type.GetPropertyNames (includePrimitive,requiresWrite, typeMatch));
			names.AddRange (type.GetFieldNames(includePrimitive,typeMatch));
			return names.ToArray ();
		}
		
		public static string[] GetMethodNames(this Type type ){
			MethodInfo[] methods = type
				.GetMethods (BindingFlags.Public | BindingFlags.Instance)
					.ToArray();
			return methods.Where(y=>y.GetParameters().Length==0 && y.ReturnType==typeof(void)).Select (x => x.Name).ToArray ();
		}
	}
}