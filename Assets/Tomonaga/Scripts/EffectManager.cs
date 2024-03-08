using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    


    public void EffectHub(FoodEffectInfo foodinfo)
    {

        switch (foodinfo.effect)
        {
            case FoodEffect.YarukiUp:
                break;
            case FoodEffect.DefenceUp:
                break;
            case FoodEffect.CardEfcUp:
                break;
            case FoodEffect.UsableCardAdd: 
                break;
        }

    }
}
