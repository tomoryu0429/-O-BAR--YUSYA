using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tani
{
    
    public abstract class CardEffect
    {
        public abstract void ApplyEffect(PlayerData player,float mul = 1f);
    }
    [System.Serializable]
    public sealed class CardEffectNone : CardEffect
    {
        public override void ApplyEffect(PlayerData player, float mul = 1)
        {
          
        }
    }

    [System.Serializable]
    public class YP_Increase_S : CardEffect
    {
        public override void ApplyEffect(PlayerData player, float mul = 1)
        {
            player.YP += (int)(PlayerData.MAX_YP * 0.1f);
        }
    }

    [System.Serializable]
    public class YP_Increase_M : CardEffect
    {
        public override void ApplyEffect(PlayerData player, float mul = 1)
        {
            player.YP += (int)(PlayerData.MAX_YP * 0.25f);
        }
    }

    [System.Serializable]
    public class YP_Increase_L : CardEffect
    {
        public override void ApplyEffect(PlayerData player, float mul = 1)
        {
            player.YP += (int)(PlayerData.MAX_YP * 0.4f);
        }
    }


}

