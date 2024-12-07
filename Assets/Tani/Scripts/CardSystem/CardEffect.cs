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

        [SerializeField,Header("やるき増小"), LabelText("変化値")] private int _changeValue = 10;

        public int ChangeValue { 
            get =>  _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "やるき増小";

        public void ApplyEffect(PlayerStatus status)
        {
            status.Motivation.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class MotivationIncreaseMiddle : ICardEffect
    {
        [SerializeField, Header("やるき増中"), LabelText("変化値")] private int _changeValue = 25;

        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "やるき増中";

        public void ApplyEffect(PlayerStatus status)
        {
            status.Motivation.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class MotivationIncreaseLarge : ICardEffect
    {
        [SerializeField, Header("やるき増大"),LabelText("変化値")] private int _changeValue = 40;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "やるき増大";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Motivation.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class GuardIncreaseSmall : ICardEffect
    {
        [SerializeField, Header("防御増小"), LabelText("変化値")] private int _changeValue = 10;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "防御増小";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Guard.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class GuardIncreaseMiddle : ICardEffect
    {
        [SerializeField, Header("防御増中"), LabelText("変化値")] private int _changeValue = 25;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "防御増中";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Guard.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class GuardIncreaseLarge : ICardEffect
    {
        [SerializeField, Header("防御増大"), LabelText("変化値")] private int _changeValue = 40;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "防御増大";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Guard.Value += _changeValue;
        }


    }
    [System.Serializable]
    public class IncreaseUseCardCount : ICardEffect
    {
        [SerializeField, Header("カードの使用回数+1"), LabelText("変化値")] private int _changeValue = 1;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "カードの使用回数+1";
        public void ApplyEffect(PlayerStatus status)
        {
            status.RemainingUseCount.Value += _changeValue;
        }


    }
}
