using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{    
    public void HPAdd10()
    {
        PlayerHPController._currentHP += 5;
        Debug.Log("HP +5");
    }

    public void HPAdd25()
    {
        PlayerHPController._currentHP += 25;
        Debug.Log("HP +25");
    }

    public void HPRemove25()
    {
        PlayerHPController._currentHP -= 25;
        Debug.Log("HP -25");
    }

}
