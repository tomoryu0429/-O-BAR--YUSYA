using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

public class PlayerData : SingletonMonoBehavior<PlayerData>
{
    //public
    public static readonly int MAX_HP = 100;
    public static readonly int MAX_YP = 100;

    /// <summary>
    /// 勇者のHPの取得と設定、値は 0 - MAX_HPにクランプされる
    /// </summary>
    public int HP
    {
        get => hp.Value;
        set => hp.Value = Mathf.Clamp(value, 0, MAX_HP);
    }
    /// <summary>
    /// 勇者のやる気ポイントの取得と設定、値は0 - MAX_YPにクランプされる
    /// </summary>
     public int YP
     {
        get => yp.Value;
        set => yp.Value = Mathf.Clamp(value, 0, MAX_YP);
     }

    public ReadOnlyReactiveProperty<int> ReactiveProperty_HP => hp.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_YP => yp.ToReadOnlyReactiveProperty();

    //private
    ReactiveProperty<int> hp = new ReactiveProperty<int>(MAX_HP);
    ReactiveProperty<int> yp = new ReactiveProperty<int>(MAX_YP);

    private void Start()
    {

    }

}


