using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Heal()
    {
        Debug.Log("回復");
    }

    static void DefBuf()
    {
        Debug.Log("防御力アップ");
    }

    static void YarukiUp()
    {
        Debug.Log("やる気アップ");
    }


    public static void EffectHub(FoodKinds CardType)
    {
      
        switch (CardType)
        { 
            case FoodKinds.Meat: case FoodKinds.Fish: case FoodKinds.Mushroom:
            case FoodKinds.Tomato:case FoodKinds.Onion: case FoodKinds.Rice:
                YarukiUp();
                break;
            case FoodKinds.Gelatin: case FoodKinds.Milk: case FoodKinds.Strawberry:
            case FoodKinds.Chocolate: case FoodKinds.Wheat: case FoodKinds.Honey:
                DefBuf();
                break;

            default:
                throw new System.ArgumentException("Invalid argument:効果");

        }

    }
}
