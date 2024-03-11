using System.Collections.Generic;
using UnityEngine;

[ExcelAsset(AssetPath = "Resources/Excel")]
public class MonsterDTSO : ScriptableObject
{
    public List<MonsterEntity> Entities;
}
