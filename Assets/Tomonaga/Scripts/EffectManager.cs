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


    public static void EffectHub(int CardType)
    {
        switch (CardType)
        {
            case 0:
                Heal();
                break;
            case 1:
                DefBuf();
                break;
            case 2:
                YarukiUp();
                break;
            default:
                throw new System.ArgumentException("Invalid argument:効果");

        }

    }
}
