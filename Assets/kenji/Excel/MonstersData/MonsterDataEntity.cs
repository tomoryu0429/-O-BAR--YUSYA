using System;
using Yusya.Enum;

[Serializable]
public class MonsterEntity
{
    public int ID;
    public string Name;
    public int HP;
    public int AT;
    public string DropM;
    public string DropC;
    public MonsterKey key;
}