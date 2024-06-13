using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using Tani;


[RequireComponent(typeof(Tani.CardManager))]
public class PlayerData : SingletonMonoBehavior<PlayerData>
{
    //public
    public static readonly int MAX_HP = 100;
    public static readonly int MAX_YP = 100;

    /// <summary>
    /// �E�҂�HP�̎擾�Ɛݒ�A�l�� 0 - MAX_HP�ɃN�����v�����
    /// </summary>
    public int HP
    {
        get => hp.Value;
        set => hp.Value = Mathf.Clamp(value, 0, MAX_HP);
    }
    /// <summary>
    /// �E�҂̂��C�|�C���g�̎擾�Ɛݒ�A�l��0 - MAX_YP�ɃN�����v�����
    /// </summary>
    public int YP
    {
        get => yp.Value;
        set => yp.Value = Mathf.Clamp(value, 0, MAX_YP);
    }

    public int Money
    {
        get => money.Value;
        set => money.Value = value;
    }
    public CardManager CardManager => cardManager ?? GetComponent<CardManager>();


    public ReadOnlyReactiveProperty<int> ReactiveProperty_HP => hp.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_YP => yp.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_Money => money.ToReadOnlyReactiveProperty();


    //private
    ReactiveProperty<int> hp = new ReactiveProperty<int>(MAX_HP);
    ReactiveProperty<int> yp = new ReactiveProperty<int>(MAX_YP);
    ReactiveProperty<int> money = new ReactiveProperty<int>(0);
    CardManager cardManager = null;
    private void Start()
    {
        cardManager = GetComponent<CardManager>();
    }

}


