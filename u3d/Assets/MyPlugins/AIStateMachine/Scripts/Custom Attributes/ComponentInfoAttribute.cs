using System;
using System.Reflection;

namespace StateMachine{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class ComponentInfoAttribute : Attribute {

	}
}