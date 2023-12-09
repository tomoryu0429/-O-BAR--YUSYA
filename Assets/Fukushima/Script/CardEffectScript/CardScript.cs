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
        Player._currentHP += 10;
        Debug.Log("HP +10");
    }

    public void HPAdd25()
    {
        Player._currentHP += 25;
        Debug.Log("HP +25");
    }

    public void HPRemove25()
    {
        Player._currentHP -= 25;
        Debug.Log("HP -25");
    }

}
