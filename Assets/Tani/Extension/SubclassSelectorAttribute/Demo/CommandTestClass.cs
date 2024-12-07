using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy;
using Alchemy.Inspector;
using System;

public  class CommandTestClass : MonoBehaviour
{
	[SerializeReference]
	public ICommand command;

	[SerializeReference]
	public ISample sample;
	
	[SerializeReference]
	public ICommand[] commandArray = new ICommand[0];

	[SerializeReference]
	List<ICommand> commandList = new List<ICommand>();

	void Start()
	{
		command?.Execute();
		foreach(ICommand c in commandList)
			c?.Execute();
	}
}

public interface ISample { }
[Serializable]
public sealed class SampleA : ISample
{
	public float alpha;
}

[Serializable]
public sealed class SampleB : ISample
{
	public Vector3 beta;
}

[Serializable]
public sealed class SampleC : ISample
{
	public GameObject gamma;
}


public interface ICommand
{
	void Execute();
}

[System.Serializable]
public class Command_Empty : ICommand
{
	public void Execute() { }
}

[System.Serializable]
public class Command_Log : ICommand
{
	[SerializeField]
	string text;
	public Command_Log() { text               = "default text"; }
	public Command_Log(string logText) { text = logText; }

	public void Execute()
	{
		Debug.Log(text);
	}
}

[System.Serializable]
public class Command_InstantiatePrefab : ICommand
{
	[SerializeField]
	GameObject prefab;
	[SerializeField]
	Vector3 position;

	public void Execute()
	{
		GameObject.Instantiate(prefab, position, Quaternion.identity);
	}
}