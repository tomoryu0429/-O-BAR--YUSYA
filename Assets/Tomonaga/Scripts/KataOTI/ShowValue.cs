using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{
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
        ////ŽRŽD
        //if(type == 0)
        //{
        //    value = CardBoardManager._MountainCardNum;
        //    GetComponent<Text>().text = "ŽRŽD  :" + value.ToString() + "–‡";
        //}
        ////ŽèŽD
        //if (type == 1)
        //{
        //    value = CardBoardManager._HandCardNum;
        //    GetComponent<Text>().text = "ŽèŽD  :" + value.ToString() + "–‡";
        //}
        ////ŽÌ‚ÄŽD
        //if (type == 2)
        //{
        //    value = CardBoardManager._GabageCardNum;
        //    GetComponent<Text>().text = "ŽÌ‚ÄŽD:" + value.ToString() + "–‡";
        //}
    }
}
