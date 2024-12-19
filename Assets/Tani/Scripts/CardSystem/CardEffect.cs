using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
namespace CardSystem
{
    public interface ICardEffect
    {
        void ApplyEffect(PlayerStatus status);
        int ChangeValue { get; set; }
        string EffectLabel { get; }
    }

    [System.Serializable ]
    public class MotivationIncreaseSmall : ICardEffect
    {

        [SerializeField,Header("��邫����"), LabelText("�ω��l")] private int _changeValue = 10;

        public int ChangeValue { 
            get =>  _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "��邫����";

        public void ApplyEffect(PlayerStatus status)
        {
            status.Motivation.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class MotivationIncreaseMiddle : ICardEffect
    {
        [SerializeField, Header("��邫����"), LabelText("�ω��l")] private int _changeValue = 25;

        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "��邫����";

        public void ApplyEffect(PlayerStatus status)
        {
            status.Motivation.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class MotivationIncreaseLarge : ICardEffect
    {
        [SerializeField, Header("��邫����"),LabelText("�ω��l")] private int _changeValue = 40;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "��邫����";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Motivation.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class GuardIncreaseSmall : ICardEffect
    {
        [SerializeField, Header("�h�䑝��"), LabelText("�ω��l")] private int _changeValue = 10;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "�h�䑝��";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Guard.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class GuardIncreaseMiddle : ICardEffect
    {
        [SerializeField, Header("�h�䑝��"), LabelText("�ω��l")] private int _changeValue = 25;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "�h�䑝��";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Guard.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class GuardIncreaseLarge : ICardEffect
    {
        [SerializeField, Header("�h�䑝��"), LabelText("�ω��l")] private int _changeValue = 40;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "�h�䑝��";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Guard.Value += _changeValue;
        }


    }
    [System.Serializable]
    public class IncreaseUseCardCount : ICardEffect
    {
        [SerializeField, Header("�J�[�h�̎g�p��+1"), LabelText("�ω��l")] private int _changeValue = 1;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "�J�[�h�̎g�p��+1";
        public void ApplyEffect(PlayerStatus status)
        {
            status.RemainingUseCount.Value += _changeValue;
        }


    }
}
