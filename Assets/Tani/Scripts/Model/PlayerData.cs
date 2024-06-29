using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using Tani;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

public class PlayerData : MonoBehaviour
{
    //public
    public static readonly int MAX_HP = 100;
    public static readonly int MAX_YP = 100;
    public UniTaskCompletionSource CS_Init { get; private set; } = new UniTaskCompletionSource();
    [field: SerializeField]
    public CardManager CardManager { get; set; }
    

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
    /// <summary>
    ///�E�҂̏�����
    /// </summary>
    public int Money
    {
        get => money.Value;
        set => money.Value = value;
    }

    public int Attack
    {
        get => attack.Value;
        set => attack.Value = value;
    }
    public int Diffense
    {
        get => diffese.Value;
        set => diffese.Value = value;
    }

    public ReadOnlyReactiveProperty<int> ReactiveProperty_HP => hp.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_YP => yp.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_Money => money.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_Attack => attack.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_Diffense => diffese.ToReadOnlyReactiveProperty();



    //private
    ReactiveProperty<int> hp = new ReactiveProperty<int>(MAX_HP);
    ReactiveProperty<int> yp = new ReactiveProperty<int>(MAX_YP);
    ReactiveProperty<int> money = new ReactiveProperty<int>(0);
    ReactiveProperty<int> attack = new ReactiveProperty<int>(0);
    ReactiveProperty<int> diffese = new ReactiveProperty<int>(0);
 



    private async void Start()
    {
        await CardManager.CS_Init.Task;


        CS_Init.TrySetResult();

        CardManager.containers[(int)CardManager.EPileType.Hand].AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0,(int)AutoEnum.ECardID.Max)));
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max)));
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max)));
        CardManager.containers[(int)CardManager.EPileType.Hand].AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max)));
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max)));
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max)));
        CardManager.containers[(int)CardManager.EPileType.Hand].AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max)));
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max)));
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max)));




    }

}


