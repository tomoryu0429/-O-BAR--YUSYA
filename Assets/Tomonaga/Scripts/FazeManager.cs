using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// カードターン内のフェイズの管理
/// </summary>

public enum CardFaze
{
    Draw,
    Selsect,
    Play,
    Cook,
}

public enum CookFaze
{
    FoodSel, //料理の選択
    MaterialSel, //素材の選択
}


public class FazeManager : MonoBehaviour
{

    public static CardFaze NowCardFaze;     //今のフェイズ
    public Text FazeText;                   //現在のフェイズを表示するテキスト

    // Start is called before the first frame update
    void Start()
    {
        NowCardFaze = CardFaze.Draw;
    }

    // Update is called once per frame
    void Update()
    {
        FazeText.text = "現在のフェイズ: " + NowCardFaze.ToString();
    }

}
