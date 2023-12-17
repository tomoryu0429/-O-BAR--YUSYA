using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YPSystem : MonoBehaviour
{
    GameObject _image;
    private void Start()
    {
        _image = GameObject.Find("YarukiBar");
    }
    public void YPDown(float _current, int _max)
    {
        _image.GetComponent<Image>().fillAmount = _current / _max;
    }
}
