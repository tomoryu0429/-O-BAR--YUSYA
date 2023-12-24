using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 食材カードの設定
/// </summary>
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
}

public enum FoodEffect
{
    NULL,
    YarukiUp,
    DefenceUp,
    UsableCardAdd,
    CardEfcUp,
}

public enum FoodEfcSize
{
    NULL,
    S,
    M,
    L,
}


public class Food : MonoBehaviour
{
    public FoodKinds fkinds;
    FoodEffect[] fEffectArray = new FoodEffect[3];
    FoodEfcSize[] efSizeArray = new FoodEfcSize[3];

    private void Start()
    {
        if (fkinds == FoodKinds.Meat || fkinds == FoodKinds.Fish || fkinds == FoodKinds.Mushroom ||
            fkinds == FoodKinds.Tomato || fkinds == FoodKinds.Onion || fkinds == FoodKinds.Rice) 
            setFoodInfo(FoodEffect.YarukiUp,FoodEffect.NULL,FoodEffect.NULL,FoodEfcSize.S );
        else if (fkinds == FoodKinds.Gelatin || fkinds == FoodKinds.Wheat || fkinds == FoodKinds.Strawberry ||
                fkinds == FoodKinds.Honey || fkinds == FoodKinds.Milk || fkinds == FoodKinds.Chocolate)
                setFoodInfo(FoodEffect.DefenceUp, FoodEffect.NULL, FoodEffect.NULL, FoodEfcSize.S);
        else if (fkinds == FoodKinds.GrilledFish)       setFoodInfo(FoodEffect.YarukiUp,  FoodEffect.NULL,          FoodEffect.NULL,
                                                                    FoodEfcSize.L);
        else if (fkinds == FoodKinds.SashimiRice)       setFoodInfo(FoodEffect.YarukiUp,  FoodEffect.UsableCardAdd, FoodEffect.NULL, 
                                                                    FoodEfcSize.M);
        else if (fkinds == FoodKinds.FriedPork)         setFoodInfo(FoodEffect.YarukiUp,  FoodEffect.UsableCardAdd, FoodEffect.NULL, 
                                                                    FoodEfcSize.L);
        else if (fkinds == FoodKinds.Curry)             setFoodInfo(FoodEffect.YarukiUp,  FoodEffect.DefenceUp,     FoodEffect.UsableCardAdd, 
                                                                    FoodEfcSize.L,FoodEfcSize.M);
        else if (fkinds == FoodKinds.FriedVegetables)   setFoodInfo(FoodEffect.YarukiUp,  FoodEffect.UsableCardAdd, FoodEffect.NULL, 
                                                                    FoodEfcSize.M);
        else if (fkinds == FoodKinds.Pancake)           setFoodInfo(FoodEffect.DefenceUp, FoodEffect.CardEfcUp,     FoodEffect.NULL, 
                                                                    FoodEfcSize.M,FoodEfcSize.S);
        else if (fkinds == FoodKinds.StrawberryParfait) setFoodInfo(FoodEffect.DefenceUp, FoodEffect.CardEfcUp,     FoodEffect.NULL, 
                                                                    FoodEfcSize.M, FoodEfcSize.S);
        else if (fkinds == FoodKinds.ChocolateCrepe)    setFoodInfo(FoodEffect.YarukiUp,  FoodEffect.CardEfcUp,     FoodEffect.NULL, 
                                                                    FoodEfcSize.S, FoodEfcSize.M);
        else if (fkinds == FoodKinds.FruitJelly)        setFoodInfo(FoodEffect.DefenceUp, FoodEffect.CardEfcUp,     FoodEffect.NULL, 
                                                                    FoodEfcSize.S, FoodEfcSize.M);
        else if (fkinds == FoodKinds.ShortCake)         setFoodInfo(FoodEffect.DefenceUp, FoodEffect.CardEfcUp,     FoodEffect.NULL, 
                                                                    FoodEfcSize.M, FoodEfcSize.L);
        else if (fkinds == FoodKinds.ChocolateCake)     setFoodInfo(FoodEffect.DefenceUp, FoodEffect.NULL,          FoodEffect.NULL, 
                                                                    FoodEfcSize.L);

    }

    void setFoodInfo(FoodEffect fef01,FoodEffect fef02,FoodEffect fef03,
                     FoodEfcSize fefs01, FoodEfcSize fefs02 = FoodEfcSize.NULL, FoodEfcSize fefs03 = FoodEfcSize.NULL)
    {
        fEffectArray[0] = fef01;
        fEffectArray[1] = fef02;
        fEffectArray[2] = fef03;
        efSizeArray[0] = fefs01;
        efSizeArray[1] = fefs02;
        efSizeArray[2] = fefs03;
    }

}

