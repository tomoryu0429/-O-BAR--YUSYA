using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tani
{
    public class CardManager
    {
        PlayerData Owner { get; }

        public CardManager(PlayerData data)
        {
            Owner = data;
        }

        DrawPile drawPile;
        HandPile handPile;
        DiscardPile discardPile;

    }
}


