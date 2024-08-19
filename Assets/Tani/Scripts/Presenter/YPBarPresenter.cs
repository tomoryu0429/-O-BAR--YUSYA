using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;


public class YPBarPresenter : MonoBehaviour
{
    [SerializeField] Tani.BarView bar;
    [SerializeField] PlayerData _playerData;

    private void Start()
    {
        _playerData.YPObservable
            .Subscribe(yp =>
            {
                bar.SetBarPercent((float)yp / 100.0f);
            }).AddTo(this);
    }
}
