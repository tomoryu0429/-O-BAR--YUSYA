using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CardFaze
{
    Draw,
    Selsect,
    Play,
    Throw,
    ELSE,
}


public class FazeManager : MonoBehaviour
{

    public static CardFaze NowCardFaze;


    // Start is called before the first frame update
    void Start()
    {
        NowCardFaze = CardFaze.Draw;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
