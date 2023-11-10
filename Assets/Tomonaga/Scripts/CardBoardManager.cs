using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CardBoardManager : MonoBehaviour
{
    public static int _MountainCardNum = 9;     //�R�D�̖�����
    public static int _HandCardNum = 0;         //��D�̖�����
    public static int _GabageCardNum = 0;       //�̂ĎD�̖���
    public GameObject _MountainCard;            //�R�D
    public GameObject _GabageCard;              //�̂ĎD


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GabageZoneCtrl();
        MountainZoneCtrl();
    }

    //�f�o�b�O�p���Z�b�g
    public void Reset()
    {
        _MountainCardNum = 9;
        _HandCardNum = 0;
        _GabageCardNum = 0;
    }

    //�R�D�\���̐���
    void MountainZoneCtrl()
    {
        //�R�D�̖�����0�ŎR�D���\������Ă��鎞�A�R�D�̕\��������
        if(_MountainCardNum == 0 && _MountainCard.activeSelf)
        {
            _MountainCard.SetActive(false);
        }
        //�R�D�̖�����0�ł͂Ȃ��A�R�D���\������Ă��Ȃ����A�R�D��\������
        else if(_MountainCardNum != 0 && !_MountainCard.activeSelf)
        {
            _MountainCard.SetActive(true);
        }
    }

    //�̂ĎD�\���̐���
    void GabageZoneCtrl()
    {
        //�̂ĎD��0�Ŏ̂ĎD���\������Ă��鎞�A�̂ĎD�̕\��������
        if (_GabageCardNum == 0 && _GabageCard.activeSelf)
        {
            _GabageCard.SetActive(false);
        }
        //�̂ĎD��0�ł͂Ȃ��A�̂ĎD���\������Ă��Ȃ����A�̂ĎD��\������
        else if (_GabageCardNum != 0 && !_GabageCard.activeSelf)
        {
            _GabageCard.SetActive(true);
        }
    }

    //�v�C��
    //�J�[�h�̃h���[
    public void Draw()
    {
        //�R�D��0���ł͂Ȃ��A�������͎�D���R���łȂ��Ƃ��h���[�ł���
        if(_MountainCardNum > 0 || _HandCardNum <3)
        {
            _MountainCardNum -= 3;
            _HandCardNum += 3;
            Debug.Log("�R�D:"+ _MountainCardNum);
            Debug.Log("��D:" + _HandCardNum);
        }
        else
        {
            Debug.Log("�R�D���Ȃ�����D�������ς�����");
        }
    }

    //�v�C��
    //�J�[�h���̂Ă�
    public void ThrowCard()
    {
        //��D��0�o�Ȃ����Ɏ��s�\
        if(_HandCardNum >0)
        {
            _HandCardNum -= 3;
            _GabageCardNum += 3;
            Debug.Log("�̂ĎD:" + _GabageCardNum);
            Debug.Log("��D:" + _HandCardNum);
        }
        else
        {
            Debug.Log("��D���Ȃ���");
        }
    }

}
