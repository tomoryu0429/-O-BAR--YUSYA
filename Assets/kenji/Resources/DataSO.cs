using System.Collections.Generic;
using UnityEngine;
using Yusya.Enum;


//ScriptableObjectを使うようにする　https://kurokumasoft.com/2022/01/04/unity-scriptableobject/

// CreateAssetMenu属性を使用することで`Assets > Create > ScriptableObjects > DataSO`という項目が表示される
// それを押すとこの`DataScriptableObject`が`DataSO`という名前でアセット化されてassetsフォルダに入る
[CreateAssetMenu(fileName = "DataSO", menuName = "ScriptableObjects/CreateDataSO")]
public class DataSO : ScriptableObject
{
    public List<MonsterData> itemDatas = new();

    public MonsterData GetItem(MonsterData type)
    {
        return itemDatas.Find(item => item.monster== type);
    }//GetItemこの関数でtypeが一致するものをitemDataから探してきて返す

    //DataSOが保存してある場所のパス
    public const string PATH = "DataSO";

    //DataSOの実体
    private static DataSO _entity;
    public static DataSO Entity
    {
        get
        {
            //初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<DataSO>(PATH);

                //ロード出来なかった場合はエラーログを表示
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
