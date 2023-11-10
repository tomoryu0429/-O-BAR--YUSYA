using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カードの現状
public enum CardState
{
    Mountain,
    Hand,
    Gabage,
}

public class Card : MonoBehaviour
{
    public CardState state;     //カードの状況
    public int Type; //カードの種類
    private bool selected = false;

    public SpriteRenderer spriteRenderer; //このカードのスプライトレンダラー
    public Transform poolPos;             //画面外のカード待機場所の座標
    CardBoardManager cbMa;                //カードボードマネージャーのインスタンス
    public Transform playPos;


    // Start is called before the first frame update
    void Start()
    {
        CardColor();
        //ゲームが始まった時は山札
        state = CardState.Mountain;
    }

    // Update is called once per frame
    void Update()
    {
        CardPosition();
    }

    //状況が手札でない場合、待機場所に
    void CardPosition()
    {
        if(state != CardState.Hand)
        {
            this.transform.position = poolPos.position;
        }
    }

    //カーソルが合ってる間サイズをアップ
    public void CardSizeUp()
    {
        if(state == CardState.Hand)
        {
            this.transform.localScale = playPos.localScale * 1.5f;
            Debug.Log("UP");
            selected = true;
        }
    }
    //カーソルが外れるとサイズダウン
    public void CardSizeDown()
    {
        if(state == CardState.Hand)
        {
            this.transform.localScale = playPos.localScale;
            Debug.Log("Down");
            selected = false;
        }
      
    }

    public void UseSelectCard()
    {
        if(selected == true && state == CardState.Hand)
        {
            Debug.Log("使用");
            this.transform.localScale = playPos.localScale;
            this.transform.localPosition = playPos.localPosition;
            selected = false;
        }
    }
    
    //Resetされると山札に
    public void ResetState()
    {
        state = CardState.Mountain;
    }

    //α制作用
    void CardColor()
    {
        switch (Type)
        {
            case 0:
                spriteRenderer.color = Color.red;
                break;
            case 1:
                spriteRenderer.color = Color.blue;
                break;
            case 2:
                spriteRenderer.color = Color.green;
                break;
        }
    }

}
