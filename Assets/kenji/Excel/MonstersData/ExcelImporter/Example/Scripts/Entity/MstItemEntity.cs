using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MstItemEntity
{
	public int id;
	public string Name;
	public int HP;
	public int AT;
	public int DF;
	public int DropM;
	public MstItemCategory category;

}

public enum MstItemCategory
{
	Red,
	Green,
	Blue,
}