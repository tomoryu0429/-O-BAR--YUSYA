using UnityEngine;
using UnityEngine.UI; // Text（UI）を扱うのでこれが必要

public class TextTest : MonoBehaviour
{
    [SerializeField] private MonsterDTSO excelData; // データを格納
    [SerializeField] private Text nameText; // 表示するモンスターの名前のテキスト

    private void Start()
    {
        // 表示のテキストをモンスターの名前（リストの1番はじめの）に変える
        nameText.text = excelData.Entities[0].Name;
    }
}

