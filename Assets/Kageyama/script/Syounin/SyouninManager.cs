using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyouninManager : MonoBehaviour
{
    [SerializeField] GameObject BuyCanvas;
    [SerializeField] GameObject SellCanvas;
    [SerializeField] GameObject SelectCanvas;
    // Start is called before the first frame update
    void Start()
    {
        SelectCanvas.SetActive(true);
        BuyCanvas.SetActive(false);
        SellCanvas.SetActive(false);
        SelectCanvas = GameObject.Find("SelectCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectCanvas.GetComponent<SelectSyounin>().buy)
        {
            SelectCanvas.SetActive(false);
            BuyCanvas.SetActive(true);
            SellCanvas.SetActive(false);
            SelectCanvas.GetComponent<SelectSyounin>().buy = false;
        }
    }
}
