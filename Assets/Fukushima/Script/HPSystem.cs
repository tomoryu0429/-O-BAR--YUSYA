using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    public GameObject _image;
    public void HPDown(float _current, int _max)
    {
        _image.GetComponent<Image>().fillAmount = _current / _max;
    }
}
