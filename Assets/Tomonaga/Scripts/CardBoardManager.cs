using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CardBoardManager : MonoBehaviour
{
    public static int _MountainCardNum = 9;
    public static int _HandCardNum = 0;
    public static int _GabageCardNum = 0;
    public GameObject _MountainCard;
    public GameObject _GabageCard;


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

    //�̂ĎD�\���̐���
    void GabageZoneCtrl()
    {
        if(_MountainCardNum == 0 && _MountainCard.activeSelf)
        {
            _MountainCard.SetActive(false);
        }
        else if(_MountainCardNum != 0 && !_MountainCard.activeSelf)
        {
            _MountainCard.SetActive(true);
        }
    }

    //�R�D�\���̐���
    void MountainZoneCtrl()
    {
        if (_GabageCardNum == 0 && _GabageCard.activeSelf)
        {
            _GabageCard.SetActive(false);
        }
        else if (_GabageCardNum != 0 && !_GabageCard.activeSelf)
        {
            _GabageCard.SetActive(true);
        }
    }

    //�v�C��
    //�J�[�h�̃h���[
    public void Draw()
    {
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
    //�J�[�h�̎g�p
    public void UseCard()
    {
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
