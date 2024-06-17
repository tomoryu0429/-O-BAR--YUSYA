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
        if (Input.GetKeyDown(KeyCode.A))
        {
            buy = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sell = true;
        }
    }
}
