using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class SubclassSelectorAttribute : PropertyAttribute
{
	bool m_includeMono;

	public SubclassSelectorAttribute(bool includeMono = false)
	{
		m_includeMono = includeMono;
	}

	public bool IsIncludeMono()
	{
		return m_includeMono;
	}
}

public class NameAttribute : Attribute
{
    public string Name { get; }
    public NameAttribute(string name) => Name = name;
}