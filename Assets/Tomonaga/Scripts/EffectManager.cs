using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    CardEffect cardScript;
    // Start is called before the first frame update
    void Start()
    {
        cardScript = GetComponent<CardEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    public void EffectHub(FoodKinds CardType)
    {
      
        switch (CardType)
        { 
            case FoodKinds.Meat: case FoodKinds.Fish: case FoodKinds.Mushroom:
            case FoodKinds.Tomato:case FoodKinds.Onion: case FoodKinds.Rice:
                cardScript.YPUp1();
                break;
            case FoodKinds.Gelatin: case FoodKinds.Milk: case FoodKinds.Strawberry:
            case FoodKinds.Chocolate: case FoodKinds.Wheat: case FoodKinds.Honey:
                cardScript.DifUp1();
                break;

            default:
                throw new System.ArgumentException("Invalid argument:Œø‰Ê");

        }

    }
}
