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

    public FoodKinds type;      //カードの食材タイプ
    Food thisFood;              //このカードのFoodコンポーネント（スクリプト）

    private bool selected = false;  //選択されている状態か

   
    public PlayCheckCard checkScripts;  //PlayerCheckCardスクリプト

    public SpriteRenderer spriteRenderer;           //このカードのスプライトレンダラー
    public Sprite[] cardSprite = new Sprite[12];    //各食材に対応したスプライト
    public Transform poolPos;                       //画面外のカード待機場所の座標
    CardBoardManager cbMa;                          //カードボードマネージャーのインスタンス
    public Transform playPos;                       //カードを出す場の位置
    public bool isCookCard  = false;                //料理カードか素材カードか
    public EffectManager effectManager;             //effectManager（スクリプト）
    public CardManager cardManager;                 //cardManager(スクリプト)
    EventTrigger GetTrigger;
    public GameObject playcheck;                    //Playcheckオブジェクト

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

    //自身の食材タイプに合わせて、カードのデザインを変える
    private void setCardDesing()
    {
        spriteRenderer.sprite = cardSprite[(int)type];
    }

    //手札からカードを選ぶフェイズの時にカーソルを合わせると大きくなる
    void OnMouseEnter()
    {
        if (state == CardState.Hand && FazeManager.NowCardFaze == CardFaze.Selsect)
        {
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Debug.Log("UP");
            selected = true;
        }
    }


    //カーソルが離れると元に戻る
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
            //使用するかどうかの確認ウィンドウ表示
            playcheck.SetActive(true);
            //確認されるカードを渡す
            checkScripts.setCard(this.gameObject);
            FazeManager.NowCardFaze = CardFaze.Play;
        }
    }

    //カード使用
    public void UsethisCard()
    {   
        selected = false;
        //カードの効果発動
        for(int i = 0;i< thisFood.getEffectNum(); i++){
            //カード効果上昇の場合
            if(thisFood.getInfo(i).effect == FoodEffect.CardEfcUp){
                effectManager.BufEffect(thisFood.getInfo(i-1),thisFood.getInfo(i).size);
            }
            //カード使用枚数の増加の場合
            else if(thisFood.getInfo(i).effect == FoodEffect.UsableCardAdd){
                cardManager.setisUsableCardNumIncreasing(true);
            }
            //それ以外の効果の場合
            else{
                effectManager.EffectHub(thisFood.getInfo(i));
            }
        }
        
        //PlayerCheckオブジェクトの非表示
        playcheck.SetActive(false);

        //捨て札に
        state = CardState.Gabage;

        //カードの使用可能枚数が増加中なら、増加中を解除。増加中でないなら次の処理へ
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
