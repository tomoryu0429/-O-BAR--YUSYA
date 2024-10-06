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

        [SerializeField,Header("‚â‚é‚«‘¬"), LabelText("•Ï‰»’l")] private int _changeValue = 10;

        public int ChangeValue { 
            get =>  _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "‚â‚é‚«‘¬";

        public void ApplyEffect(PlayerStatus status)
        {
            status.Motivation.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class MotivationIncreaseMiddle : ICardEffect
    {
        [SerializeField, Header("‚â‚é‚«‘’†"), LabelText("•Ï‰»’l")] private int _changeValue = 25;

        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "‚â‚é‚«‘’†";

        public void ApplyEffect(PlayerStatus status)
        {
            status.Motivation.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class MotivationIncreaseLarge : ICardEffect
    {
        [SerializeField, Header("‚â‚é‚«‘‘å"),LabelText("•Ï‰»’l")] private int _changeValue = 40;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "‚â‚é‚«‘‘å";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Motivation.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class GuardIncreaseSmall : ICardEffect
    {
        [SerializeField, Header("–hŒä‘¬"), LabelText("•Ï‰»’l")] private int _changeValue = 10;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "–hŒä‘¬";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Guard.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class GuardIncreaseMiddle : ICardEffect
    {
        [SerializeField, Header("–hŒä‘’†"), LabelText("•Ï‰»’l")] private int _changeValue = 25;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "–hŒä‘’†";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Guard.Value += _changeValue;
        }


    }

    [System.Serializable]
    public class GuardIncreaseLarge : ICardEffect
    {
        [SerializeField, Header("–hŒä‘‘å"), LabelText("•Ï‰»’l")] private int _changeValue = 40;
        public int ChangeValue
        {
            get => _changeValue;
            set => _changeValue = value;
        }

        public string EffectLabel => "–hŒä‘‘å";
        public void ApplyEffect(PlayerStatus status)
        {
            status.Guard.Value += _changeValue;
        }


    }
}
