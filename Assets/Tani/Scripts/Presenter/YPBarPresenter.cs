using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;


public class YPBarPresenter : MonoBehaviour
{
    [SerializeField] Tani.BarView bar;


    private void Start()
    {
        PlayerData.Instance.Status.Motivation.Observable
            .Subscribe(yp =>
            {
                bar.SetBarPercent((float)yp.Value / yp.Max);
            }).AddTo(this);
    }
}
