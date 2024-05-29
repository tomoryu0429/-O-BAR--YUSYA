using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �J�[�h�֌W�̌����ڂ̊Ǘ�
/// </summary>


public class CardBoardManager : MonoBehaviour
{
    public GameObject _MountainCard;            //�R�D
    public GameObject _GabageCard;              //�̂ĎD
    public Text valueM;                         //�R�D�����\���p�̃e�L�X�g
    public Text valueH;                         //��D�����\���p�̃e�L�X�g
    public Text valueG;                         //�̂ĎD�̖����\���p�̃e�L�X�g
    public CardManager cardManager;             //�J�[�h�}�l�[�W���[�i�X�N���v�g�j

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        valueM.text = "�R�D: " + cardManager.getNowCardNum().MountainNum.ToString();
        valueH.text = "��D: " + cardManager.getNowCardNum().HandNum.ToString();
        valueG.text = "�̂ĎD: " + cardManager.getNowCardNum().GabageNum.ToString();
        GabageZoneCtrl();
        MountainZoneCtrl();
    }

    //�f�o�b�O�p���Z�b�g
    public void Reset()
    {
     
    }

    //�R�D�\���̐���
    void MountainZoneCtrl()
    {
        //�R�D�̖�����0�ŎR�D���\������Ă��鎞�A�R�D�̕\��������
        if(cardManager.getNowCardNum().MountainNum == 0 && _MountainCard.activeSelf)
        {
            _MountainCard.SetActive(false);
        }
        //�R�D�̖�����0�ł͂Ȃ��A�R�D���\������Ă��Ȃ����A�R�D��\������
        else if(cardManager.getNowCardNum().MountainNum != 0 && !_MountainCard.activeSelf)
        {
            _MountainCard.SetActive(true);
        }
    }

    //�̂ĎD�\���̐���
    void GabageZoneCtrl()
    {
        //�̂ĎD��0�Ŏ̂ĎD���\������Ă��鎞�A�̂ĎD�̕\��������
        if (cardManager.getNowCardNum().GabageNum == 0 && _GabageCard.activeSelf)
        {
            _GabageCard.SetActive(false);
        }
        //�̂ĎD��0�ł͂Ȃ��A�̂ĎD���\������Ă��Ȃ����A�̂ĎD��\������
        else if (cardManager.getNowCardNum().GabageNum != 0 && !_GabageCard.activeSelf)
        {
            _GabageCard.SetActive(true);
        }
    }

   

}
