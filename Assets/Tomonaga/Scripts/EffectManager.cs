using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    CardEffect cardScript;
    public PlayerControll playerControll;

    // Start is called before the first frame update
    void Start()
    {
        cardScript = GetComponent<CardEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    public void EffectHub(FoodEffectInfo foodinfo)
    {

        switch (foodinfo.effect)
        {
            case FoodEffect.YarukiUp:
                switch (foodinfo.size)
                {
                    case FoodEfcSize.S:
                        playerControll.PlayerYarukiValueChange(10);
                        break;
                    case FoodEfcSize.M:
                        playerControll.PlayerYarukiValueChange(25);
                        break;
                    case FoodEfcSize.L:
                        playerControll.PlayerYarukiValueChange(40);
                        break;
                    case FoodEfcSize.LL:
                        break;
                }
                break;
            case FoodEffect.DefenceUp:
                switch (foodinfo.size)
                {
                    case FoodEfcSize.S:
                        playerControll.PlayerDefenceValueChange(10);
                        break;
                    case FoodEfcSize.M:
                        playerControll.PlayerDefenceValueChange(25);
                        break;
                    case FoodEfcSize.L:
                        playerControll.PlayerDefenceValueChange(40);
                        break;
                    case FoodEfcSize.LL:
                        break;
                }
                break;
            case FoodEffect.CardEfcUp:
                break;
            case FoodEffect.UsableCardAdd: 
                break;
        }

    }
}
