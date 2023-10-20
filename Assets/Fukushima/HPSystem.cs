using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    GameObject _Image;
    private void Start()
    {
        //
        _Image = GameObject.Find("HealthBar");
    }
    public void HPDown(float _current, int _max)
    {
        _Image.GetComponent<Image>().fillAmount = _current / _max;
    }
}
