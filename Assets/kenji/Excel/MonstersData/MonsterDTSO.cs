using System.Collections.Generic;
using UnityEngine;
//https://takap-tech.com/entry/2023/07/22/171355
//���̕��@�ł�����������Excel�̃f�[�^��ۑ����Ĕ��f���m���ɂ��邩��
[ExcelAsset]
public class MonsterDTSO : ScriptableObject
{
    //public List<EntityType> �e�[�u��1; // Replace 'EntityType' to an actual type that is serializable.
    //public List<EntityType> Sheet1; // Replace 'EntityType' to an actual type that is serializable.
    public List<MonsterEntity> Entities;
}
