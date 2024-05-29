using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    CardEffect cardScript;                  //カード（スクリプト）
    public PlayerControll playerControll;   //プレイヤーコントロール（スクリプト）

    // Start is called before the first frame update
    void Start()
    {
        cardScript = GetComponent<CardEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //カード効果の分岐
    public void EffectHub(FoodEffectInfo foodinfo,float bufvalue = 1)
    {

        switch (foodinfo.effect)
        {
            //やる気アップ
            case FoodEffect.YarukiUp:
                switch (foodinfo.size)
                {
                    case FoodEfcSize.S:
                        playerControll.PlayerYarukiValueChange((int)(10f * bufvalue));
                        break;
                    case FoodEfcSize.M:
                        playerControll.PlayerYarukiValueChange((int)(25f * bufvalue));
                        break;
                    case FoodEfcSize.L:
                        playerControll.PlayerYarukiValueChange((int)(40f * bufvalue));
                        break;
                }
                break;

            //防御力のアップ
            case FoodEffect.DefenceUp:
                switch (foodinfo.size)
                {
                    case FoodEfcSize.S:
                        playerControll.PlayerDefenceValueChange((int)(10f * bufvalue));
                        break;
                    case FoodEfcSize.M:
                        playerControll.PlayerDefenceValueChange((int)(25f * bufvalue));
                        break;
                    case FoodEfcSize.L:
                        playerControll.PlayerDefenceValueChange((int)(40f * bufvalue));
                        break;
                }
                break;
            case FoodEffect.CardEfcUp:
                break;
            case FoodEffect.UsableCardAdd: 
                break;
        }

    }


    //カード効果のバフ
    public void BufEffect(FoodEffectInfo foodinfo,FoodEfcSize foodsize)
    {
        //与えられた効果を再度発動する。その倍率は与えられた効果のサイズに依存する
        switch (foodsize)
        {
            case FoodEfcSize.S:
                EffectHub(foodinfo, 0.25f);
                break;
            case FoodEfcSize.M:
                EffectHub(foodinfo, 0.50f);
                break;
            case FoodEfcSize.L:
                EffectHub(foodinfo, 0.75f);
                break;
        }
    }
}
