using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    GameObject _image;
    private void Start()
    {
        _image = GameObject.Find("HPBar");
    }
    public void HPDown(float _current, int _max)
    {
        _image.GetComponent<Image>().fillAmount = _current / _max;
    }
}
