using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 食材カードの設定
/// </summary>

//食材の種類
public enum FoodKinds
{
    Meat,
    Fish,
    Mushroom,
    Tomato,
    Onion,
    Rice,
    Gelatin,
    Wheat,
    Strawberry,
    Honey,
    Milk,
    Chocolate,

    GrilledFish,
    SashimiRice,
    FriedPork,
    Curry,
    FriedVegetables,
    Pancake,
    StrawberryParfait,
    ChocolateCrepe,
    FruitJelly,
    ShortCake,
    ChocolateCake,

    NULL,
}

//料理の効果
public enum FoodEffect
{
    YarukiUp,
    DefenceUp,
    UsableCardAdd,
    CardEfcUp,
}

//効果のサイズ
public enum FoodEfcSize
{
    S,
    M,
    L,
    LL,
}

//料理の効果がもつ情報
public struct FoodEffectInfo
{
    public FoodEffect effect;
    public FoodEfcSize size;

}


public class Food : MonoBehaviour
{
    public FoodKinds fkinds;
    List<FoodEffectInfo> EffectInfoArray = new List<FoodEffectInfo>();
    int effectNum = 0;
    Card thisCardScripts;

    //食材の情報を渡す
    public FoodEffectInfo getInfo(int arrayNum)
    {
        return EffectInfoArray[arrayNum];
    }

    //効果の番号を取得
    public int getEffectNum() { return effectNum; }


    private void Start()
    {

        thisCardScripts = this.GetComponent<Card>();

        fkinds = thisCardScripts.type;

        //各食材への効果と効果サイズの割り振り
        if (fkinds == FoodKinds.Meat || fkinds == FoodKinds.Fish || fkinds == FoodKinds.Mushroom || fkinds == FoodKinds.Tomato || fkinds == FoodKinds.Onion || fkinds == FoodKinds.Rice) {
            AddEffect(FoodEffect.YarukiUp, FoodEfcSize.S);
        }
        else if (fkinds == FoodKinds.Gelatin || fkinds == FoodKinds.Wheat || fkinds == FoodKinds.Strawberry || fkinds == FoodKinds.Honey || fkinds == FoodKinds.Milk || fkinds == FoodKinds.Chocolate) {
            AddEffect(FoodEffect.DefenceUp, FoodEfcSize.S);
        }
        else if (fkinds == FoodKinds.GrilledFish) {
            AddEffect(FoodEffect.YarukiUp, FoodEfcSize.L);
        }
        else if (fkinds == FoodKinds.SashimiRice) {
            AddEffect(FoodEffect.YarukiUp, FoodEfcSize.M);
            AddEffect(FoodEffect.UsableCardAdd, FoodEfcSize.L);
        }
        else if (fkinds == FoodKinds.FriedPork) {
            AddEffect(FoodEffect.YarukiUp, FoodEfcSize.L);
            AddEffect(FoodEffect.UsableCardAdd, FoodEfcSize.L);
        }
        else if (fkinds == FoodKinds.Curry) {
            AddEffect(FoodEffect.YarukiUp, FoodEfcSize.L);
            AddEffect(FoodEffect.DefenceUp, FoodEfcSize.M);
            AddEffect(FoodEffect.UsableCardAdd, FoodEfcSize.L);
        }
        else if (fkinds == FoodKinds.FriedVegetables) {
            AddEffect(FoodEffect.YarukiUp, FoodEfcSize.M);
            AddEffect(FoodEffect.UsableCardAdd, FoodEfcSize.L);
        }
        else if (fkinds == FoodKinds.Pancake) {
            AddEffect(FoodEffect.DefenceUp, FoodEfcSize.M);
            AddEffect(FoodEffect.CardEfcUp, FoodEfcSize.S);
        }
        else if (fkinds == FoodKinds.StrawberryParfait) {
            AddEffect(FoodEffect.DefenceUp, FoodEfcSize.M);
            AddEffect(FoodEffect.CardEfcUp, FoodEfcSize.S);
        }
        else if (fkinds == FoodKinds.ChocolateCrepe) {
            AddEffect(FoodEffect.YarukiUp, FoodEfcSize.S);
            AddEffect(FoodEffect.CardEfcUp, FoodEfcSize.M);
        }
        else if (fkinds == FoodKinds.FruitJelly){
            AddEffect(FoodEffect.DefenceUp, FoodEfcSize.S);
            AddEffect(FoodEffect.CardEfcUp, FoodEfcSize.M);
        }
        else if (fkinds == FoodKinds.ShortCake){
            AddEffect(FoodEffect.DefenceUp, FoodEfcSize.M);
            AddEffect(FoodEffect.CardEfcUp, FoodEfcSize.L);
        }
        else if (fkinds == FoodKinds.ChocolateCake) {
            AddEffect(FoodEffect.DefenceUp, FoodEfcSize.L);
        }
    }

    //効果の追加
    void AddEffect(FoodEffect fef,FoodEfcSize fes)
    {
        FoodEffectInfo addfoodEffectInfo = new FoodEffectInfo {effect = fef,size = fes };
        EffectInfoArray.Add(addfoodEffectInfo);
        effectNum++;
    }

}

