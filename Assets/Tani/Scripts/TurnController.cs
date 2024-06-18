using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using UnityEngine.Events;
namespace Tani
{
    public class TurnController 
    {
        static public ETurn CurrentTurn => currentTurn;
        static public event UnityAction<ETurn> OnTurnEnd;
        static public event UnityAction<ETurn> OnTurnStart;

        static private ETurn currentTurn = ETurn.Invalid;


        static public void ChangeTurn(ETurn eTurn)
        {
            OnTurnEnd(currentTurn);
            currentTurn = eTurn;
            OnTurnStart(currentTurn);
        }

        public enum ETurn
        {
            Invalid = -1
            ,CardTurn,YusyaTurn,EnemyTurn
                ,TurnMax
        }
    }

}



