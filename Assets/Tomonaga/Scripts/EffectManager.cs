using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    CardEffect cardScript;                  //�J�[�h�i�X�N���v�g�j
    public PlayerControll playerControll;   //�v���C���[�R���g���[���i�X�N���v�g�j

    // Start is called before the first frame update
    void Start()
    {
        cardScript = GetComponent<CardEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�J�[�h���ʂ̕���
    public void EffectHub(FoodEffectInfo foodinfo,float bufvalue = 1)
    {

        switch (foodinfo.effect)
        {
            //���C�A�b�v
            case FoodEffect.YarukiUp:
                switch (foodinfo.size)
                {
                    case FoodEfcSize.S:
                        playerControll.PlayerYarukiValueChange((int)(10f * bufvalue));
                        break;
                    case FoodEfcSize.M:
                        playerControll.PlayerYarukiValueChange((int)(25f * bufvalue));
                        break;
                    case FoodEfcSize.L:
                        playerControll.PlayerYarukiValueChange((int)(40f * bufvalue));
                        break;
                }
                break;

            //�h��͂̃A�b�v
            case FoodEffect.DefenceUp:
                switch (foodinfo.size)
                {
                    case FoodEfcSize.S:
                        playerControll.PlayerDefenceValueChange((int)(10f * bufvalue));
                        break;
                    case FoodEfcSize.M:
                        playerControll.PlayerDefenceValueChange((int)(25f * bufvalue));
                        break;
                    case FoodEfcSize.L:
                        playerControll.PlayerDefenceValueChange((int)(40f * bufvalue));
                        break;
                }
                break;
            case FoodEffect.CardEfcUp:
                break;
            case FoodEffect.UsableCardAdd: 
                break;
        }

    }


    //�J�[�h���ʂ̃o�t
    public void BufEffect(FoodEffectInfo foodinfo,FoodEfcSize foodsize)
    {
        //�^����ꂽ���ʂ��ēx��������B���̔{���͗^����ꂽ���ʂ̃T�C�Y�Ɉˑ�����
        switch (foodsize)
        {
            case FoodEfcSize.S:
                EffectHub(foodinfo, 0.25f);
                break;
            case FoodEfcSize.M:
                EffectHub(foodinfo, 0.50f);
                break;
            case FoodEfcSize.L:
                EffectHub(foodinfo, 0.75f);
                break;
        }
    }
}
