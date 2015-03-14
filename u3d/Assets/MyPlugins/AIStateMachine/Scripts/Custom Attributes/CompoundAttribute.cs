using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field,AllowMultiple=true)]
public sealed class CompoundAttribute : Attribute
{
	public int enumIndex;
	public string[] fieldNames;

	public CompoundAttribute(int enumIndex ,params string[] fieldNames){
		this.enumIndex = enumIndex;
		this.fieldNames = fieldNames;
	}
}