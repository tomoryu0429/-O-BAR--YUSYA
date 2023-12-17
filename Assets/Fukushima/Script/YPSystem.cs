using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YPSystem : MonoBehaviour
{
    public GameObject _image;
    public void YPDown(float _current, int _max)
    {
        _image.GetComponent<Image>().fillAmount = _current / _max;
    }
}
