using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : HPBar
{
    [SerializeField] int _ypUpSmall = 10;
    [SerializeField] int _ypUpMiddle = 25;
    [SerializeField] int _ypUpLarge = 40;
    [SerializeField] int _difUpSmall = 10;
    [SerializeField] int _difUpMiddle = 25;
    [SerializeField] int _difUpLarge = 40;
    public void YPUp1()
    {
        YP += _ypUpSmall;
        Debug.Log($"YP +{_ypUpSmall}");
    }

    public void YPUp2()
    {
        YP += _ypUpMiddle;
        Debug.Log($"YP + {_ypUpMiddle}");
    }
    public void YPUp3()
    {
        YP += _ypUpLarge;
        Debug.Log($"YP +{_ypUpLarge}");
    }
    public void DifUp1()
    {
        T_Player._currentDif = _difUpSmall;
        Debug.Log($"Dif = {_difUpSmall}");
    }
    public void DifUp2()
    {
        T_Player._currentDif = _difUpMiddle;
        Debug.Log($"Dif = {_difUpMiddle}");
    }
    public void DifUp3()
    {
        T_Player._currentDif = _difUpLarge;
        Debug.Log($"Dif = {_difUpLarge}");
    }
}
