using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManager : MonoBehaviour
{
    /// <summary> 戦闘シーン名格納リスト</summary>
    [SerializeField] [Header("戦闘シーン名")] private List<string> _stageNames = new();
    /// <summary> ステージをランダムに選択の数字を格納するリスト</summary>
    private List<int> _stageNums = new();
    public static StageManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StageRandom().ForEach(x => print($"{_stageNames[x]} : {x}"));
    }
    /// <summary> 格納したステージをランダムに並べ替える</summary>
    /// <returns>ランダムに選べ変えたリストを返す</returns>
    private List<int> StageRandom()
    {
        for (var i = 0; i < _stageNames.Count; i++)
        {
            _stageNums.Add(i);
        }
        return _stageNums.OrderBy(x => Guid.NewGuid()).ToList();
    }
}
