using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum pState
{
    Yaruki0,Yaruki26, Yaruki51, Yaruki70,Yaruki90,
}





public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setpState()
    {
        if (T_Player._currentYP < 90)
        {
            PlayerChenge.NowpState = pState.Yaruki70;
        }
        if (T_Player._currentYP < 70)
        {
            PlayerChenge.NowpState = pState.Yaruki51;
        }
        if (T_Player._currentYP < 51)
        {
            PlayerChenge.NowpState = pState.Yaruki26;
        }
        if (T_Player._currentYP < 26)
        {
            PlayerChenge.NowpState = pState.Yaruki0;
        }
        if (T_Player._currentYP >= 90)
        {
            PlayerChenge.NowpState = pState.Yaruki90;
        }
        
    }
}
