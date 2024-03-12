using System.Collections.Generic;
using UnityEngine;
using Yusya.Enum;


//ScriptableObject���g���悤�ɂ���@https://kurokumasoft.com/2022/01/04/unity-scriptableobject/

// CreateAssetMenu�������g�p���邱�Ƃ�`Assets > Create > ScriptableObjects > DataSO`�Ƃ������ڂ��\�������
// ����������Ƃ���`DataScriptableObject`��`DataSO`�Ƃ������O�ŃA�Z�b�g�������assets�t�H���_�ɓ���
[CreateAssetMenu(fileName = "DataSO", menuName = "ScriptableObjects/CreateDataSO")]
public class DataSO : ScriptableObject
{
    public List<MonsterData> itemDatas = new();

    public MonsterData GetItem(MonsterData type)
    {
        return itemDatas.Find(item => item.monster== type);
    }//GetItem���̊֐���type����v������̂�itemData����T���Ă��ĕԂ�

    //DataSO���ۑ����Ă���ꏊ�̃p�X
    public const string PATH = "DataSO";

    //DataSO�̎���
    private static DataSO _entity;
    public static DataSO Entity
    {
        get
        {
            //���A�N�Z�X���Ƀ��[�h����
            if (_entity == null)
            {
                _entity = Resources.Load<DataSO>(PATH);

                //���[�h�o���Ȃ������ꍇ�̓G���[���O��\��
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}

[System.Serializable]
public class StoryData
{
    public string name;
    public int count;
    public Sprite sprite;
    [TextArea] public string text;
}

[System.Serializable]
public class MonsterData
{
    public MonsterData monster;
    public string name;
    public int count;
    public Sprite sprite;
    [TextArea] public string text;
}

[System.Serializable]
public class ItemData
{
    //public Achievement achievement;
    public string name;
    public int count;
    public Sprite sprite;
    [TextArea] public string text;
}

[System.Serializable]
public class StatusData
{
    public string name;
    public int Number;
    public Sprite sprite;
    [TextArea] public string text;
}
