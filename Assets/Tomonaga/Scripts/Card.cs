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
    Food thisFood;

    private bool selected = false;

   
    public PlayCheckCard checkScripts;

    public SpriteRenderer spriteRenderer;        //このカードのスプライトレンダラー
    public Sprite[] cardSprite = new Sprite[12];
    public Transform poolPos;             //画面外のカード待機場所の座標
    CardBoardManager cbMa;                //カードボードマネージャーのインスタンス
    public Transform playPos;
    public bool isCookCard  = false;                  //料理カードか素材カードか
    public EffectManager effectManager;
    public CardManager cardManager;
    EventTrigger GetTrigger;
    public GameObject playcheck;

    // Start is called before the first frame update
    void Start()
    {
        setCardDesing();
        spriteRenderer = GetComponent<SpriteRenderer>();
        thisFood = this.GetComponent<Food>();
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

    //カード選択時の処理
    void OnMouseDown()
    {
        if (selected == true && state == CardState.Hand && FazeManager.NowCardFaze == CardFaze.Selsect)
        {
            Debug.Log("使用");
            playcheck.SetActive(true);
            checkScripts.setCard(this.gameObject);
            FazeManager.NowCardFaze = CardFaze.Play;
        }
    }

    //カード使用
    public void UsethisCard()
    {   
        selected = false;
        for(int i = 0;i< thisFood.getEffectNum(); i++){
            if(thisFood.getInfo(i).effect == FoodEffect.CardEfcUp){
                effectManager.BufEffect(thisFood.getInfo(i-1),thisFood.getInfo(i).size);
            }
            else if(thisFood.getInfo(i).effect == FoodEffect.UsableCardAdd){
                cardManager.setisUsableCardNumIncreasing(true);
            }
            else{
                effectManager.EffectHub(thisFood.getInfo(i));
            }
        } 
        playcheck.SetActive(false);
        state = CardState.Gabage;

        if (!cardManager.getisUsableCardNumIncreasing()){
            cardManager.ThrowCard();
        }
        else{
            cardManager.setisUsableCardNumIncreasing(false);
        }
    }

    //カード使用キャンセル
    public void CanceleUseing()
    {
        selected = false;
        playcheck.SetActive(false);
        FazeManager.NowCardFaze = CardFaze.Selsect;

    }
}
