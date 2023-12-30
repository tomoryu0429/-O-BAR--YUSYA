using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    public GameObject _image;
    public void HPBar(int _max)
    {
        _image.GetComponent<Image>().fillAmount = Player._currentHP / _max;
    }
}
