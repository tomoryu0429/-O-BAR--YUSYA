using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class MonsterDTSO : ScriptableObject
{
    //public List<EntityType> �e�[�u��1; // Replace 'EntityType' to an actual type that is serializable.
    //public List<EntityType> Sheet1; // Replace 'EntityType' to an actual type that is serializable.
    public List<MonsterEntity> Entities;
}
