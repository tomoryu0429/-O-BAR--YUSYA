using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectSyounin : MonoBehaviour
{
    public bool buy;
    public bool sell;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickBuy()
    {
        buy = true;
        sell = false;
    }

    public void OnClickSell()
    {
        sell = true;
        buy = false;
    }
}
