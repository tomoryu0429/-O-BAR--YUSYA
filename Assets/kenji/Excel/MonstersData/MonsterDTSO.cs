using System.Collections.Generic;
using UnityEngine;
//https://takap-tech.com/entry/2023/07/22/171355
//この方法でもしかしたらExcelのデータを保存して反映が確実にするかも
[ExcelAsset]
public class MonsterDTSO : ScriptableObject
{
    //public List<EntityType> テーブル1; // Replace 'EntityType' to an actual type that is serializable.
    //public List<EntityType> Sheet1; // Replace 'EntityType' to an actual type that is serializable.
    public List<MonsterEntity> Entities;
}
