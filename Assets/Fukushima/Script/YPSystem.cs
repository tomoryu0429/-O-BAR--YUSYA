using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YPSystem : MonoBehaviour
{
    public GameObject _image;
    public void YPBar(int _max)
    {
        _image.GetComponent<Image>().fillAmount = Player._currentYP / _max;
    }
}
