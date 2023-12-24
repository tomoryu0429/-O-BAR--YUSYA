using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static Unity.Burst.Intrinsics.Arm;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

/// <summary>
/// カード1枚１枚の挙動
/// </summary>


//カードの現状
public enum CardState
{
    Mountain,
    Hand,
    Gabage,
    Death,
    Pool,
}



public class Card : MonoBehaviour
{
    public CardState state;     //カードの状況

    public FoodKinds type;

    private bool selected = false;

    public SpriteRenderer spriteRenderer; //このカードのスプライトレンダラー
    public Sprite[] cardSprite = new Sprite[12];
    public Transform poolPos;             //画面外のカード待機場所の座標
    CardBoardManager cbMa;                //カードボードマネージャーのインスタンス
    public Transform playPos;
    public bool isCookCard  = false;                  //料理カードか素材カードか

    EventTrigger GetTrigger;

    // Start is called before the first frame update
    void Start()
    {

      
        ////ゲームが始まった時は山札
        //if(!isCookCard)
        //    state = CardState.Mountain;
        //else
        //    state = CardState.Pool;
    }

    // Update is called once per frame
    void Update()
    {
        CardPosition();
        setCardDesing();
    }

    //状況が手札でない場合、待機場所に
    void CardPosition()
    {
        if(state != CardState.Hand)
        {
            this.transform.position = poolPos.position;
        }
    }
    
    //Resetされると山札に
    public void ResetState()
    {
        state = CardState.Mountain;
        FazeManager.NowCardFaze = CardFaze.Draw;
    }

    private void setCardDesing()
    {
        spriteRenderer.sprite = cardSprite[(int)type];
    }

    void OnMouseEnter()
    {
        if (state == CardState.Hand && FazeManager.NowCardFaze == CardFaze.Selsect)
        {
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Debug.Log("UP");
            selected = true;
        }
    }

    void OnMouseExit()
    {
        if (state == CardState.Hand && FazeManager.NowCardFaze == CardFaze.Selsect)
        {
            this.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            Debug.Log("Down");
            selected = false;
        }
    }

    void OnMouseDown()
    {
        if (selected == true && state == CardState.Hand)
        {
            Debug.Log("使用");
            this.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            this.transform.localPosition = playPos.localPosition;
            selected = false;
            EffectManager.EffectHub(type);
            FazeManager.NowCardFaze = CardFaze.Throw;
        }
    }
}
