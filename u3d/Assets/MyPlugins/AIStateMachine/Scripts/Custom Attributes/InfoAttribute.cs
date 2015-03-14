using System;

[AttributeUsage(AttributeTargets.Class)]
public sealed class InfoAttribute : Attribute
{
	public string category;
	public string description;
	public string url;
}
