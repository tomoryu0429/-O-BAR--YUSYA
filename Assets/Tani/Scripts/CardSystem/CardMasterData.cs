using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using Alchemy;
[CreateAssetMenu(fileName = "CardMasterData",menuName = "ScriptableObjects/CardMasterData")]
public class CardMasterData : ScriptableObject
{
    
    [field: SerializeField, LabelText("やる気 増小"), Header("カードの効果を設定")] public int MotivationIncreaseSmall { get; private set; }

    [field: SerializeField, LabelText("やる気 増中")] public int MotivationIncreaseMiddle { get; private set; }

    [field: SerializeField, LabelText("やる気 増大")] public int MotivationIncreaseLarge { get; private set; }

    [field: SerializeField, LabelText("防御　増小")] public int GuardIncreaseSmall { get; private set; }

    [field: SerializeField, LabelText("防御　増中")] public int GuardIncreaseMiddle { get; private set; }

    [field: SerializeField, LabelText("防御　増大")] public int GuardIncreaseLarge { get; private set; }

    [field: SerializeField, LabelText("カード効果 増小"), Tooltip("25%増加は1.25を指定")] public float CardEffectIncreaseSmall { get; private set; }

    [field: SerializeField, LabelText("カード効果 増中"), Tooltip("25%増加は1.25を指定")] public float CardEffectIncreaseMiddle { get; private set; }

    [field: SerializeField, LabelText("カード効果 増大"), Tooltip("25%増加は1.25を指定")] public float CardEffectIncreaseLarge { get; private set; }



}
