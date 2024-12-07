using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;


public class YPBarPresenter : UIGroup
{
    [SerializeField] Tani.BarView bar;

    public override void Initialize()
    {
        PlayerData.Instance.Status.Motivation.Observable
            .Subscribe(yp =>
            {
                bar.SetBarPercent((float)yp.Value / yp.Max);
            }).AddTo(this);
    }
}
