using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using Alchemy;
[CreateAssetMenu(fileName = "CardMasterData",menuName = "ScriptableObjects/CardMasterData")]
public class CardMasterData : ScriptableObject
{
    
    [field: SerializeField, LabelText("���C ����"), Header("�J�[�h�̌��ʂ�ݒ�")] public int MotivationIncreaseSmall { get; private set; }

    [field: SerializeField, LabelText("���C ����")] public int MotivationIncreaseMiddle { get; private set; }

    [field: SerializeField, LabelText("���C ����")] public int MotivationIncreaseLarge { get; private set; }

    [field: SerializeField, LabelText("�h��@����")] public int GuardIncreaseSmall { get; private set; }

    [field: SerializeField, LabelText("�h��@����")] public int GuardIncreaseMiddle { get; private set; }

    [field: SerializeField, LabelText("�h��@����")] public int GuardIncreaseLarge { get; private set; }

    [field: SerializeField, LabelText("�J�[�h���� ����"), Tooltip("25%������1.25���w��")] public float CardEffectIncreaseSmall { get; private set; }

    [field: SerializeField, LabelText("�J�[�h���� ����"), Tooltip("25%������1.25���w��")] public float CardEffectIncreaseMiddle { get; private set; }

    [field: SerializeField, LabelText("�J�[�h���� ����"), Tooltip("25%������1.25���w��")] public float CardEffectIncreaseLarge { get; private set; }



}
