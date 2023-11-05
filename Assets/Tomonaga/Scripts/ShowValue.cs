using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{
    //“_”‚ğŠi”[‚·‚é•Ï”
    public int value = 0;
    public int type = 0;

    public Text text; 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //RD
        if(type == 0)
        {
            value = CardBoardManager._MountainCardNum;
            GetComponent<Text>().text = "RD  :" + value.ToString() + "–‡";
        }
        //èD
        if (type == 1)
        {
            value = CardBoardManager._HandCardNum;
            GetComponent<Text>().text = "èD  :" + value.ToString() + "–‡";
        }
        //Ì‚ÄD
        if (type == 2)
        {
            value = CardBoardManager._GabageCardNum;
            GetComponent<Text>().text = "Ì‚ÄD:" + value.ToString() + "–‡";
        }
    }
}
