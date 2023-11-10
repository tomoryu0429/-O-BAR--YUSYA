using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�J�[�h�̌���
public enum CardState
{
    Mountain,
    Hand,
    Gabage,
}

public class Card : MonoBehaviour
{
    public CardState state;     //�J�[�h�̏�
    public int Type; //�J�[�h�̎��
    private bool selected = false;

    public SpriteRenderer spriteRenderer; //���̃J�[�h�̃X�v���C�g�����_���[
    public Transform poolPos;             //��ʊO�̃J�[�h�ҋ@�ꏊ�̍��W
    CardBoardManager cbMa;                //�J�[�h�{�[�h�}�l�[�W���[�̃C���X�^���X
    public Transform playPos;


    // Start is called before the first frame update
    void Start()
    {
        CardColor();
        //�Q�[�����n�܂������͎R�D
        state = CardState.Mountain;
    }

    // Update is called once per frame
    void Update()
    {
        CardPosition();
    }

    //�󋵂���D�łȂ��ꍇ�A�ҋ@�ꏊ��
    void CardPosition()
    {
        if(state != CardState.Hand)
        {
            this.transform.position = poolPos.position;
        }
    }

    //�J�[�\���������Ă�ԃT�C�Y���A�b�v
    public void CardSizeUp()
    {
        if(state == CardState.Hand)
        {
            this.transform.localScale = playPos.localScale * 1.5f;
            Debug.Log("UP");
            selected = true;
        }
    }
    //�J�[�\�����O���ƃT�C�Y�_�E��
    public void CardSizeDown()
    {
        if(state == CardState.Hand)
        {
            this.transform.localScale = playPos.localScale;
            Debug.Log("Down");
            selected = false;
        }
      
    }

    public void UseSelectCard()
    {
        if(selected == true && state == CardState.Hand)
        {
            Debug.Log("�g�p");
            this.transform.localScale = playPos.localScale;
            this.transform.localPosition = playPos.localPosition;
            selected = false;
        }
    }
    
    //Reset�����ƎR�D��
    public void ResetState()
    {
        state = CardState.Mountain;
    }

    //������p
    void CardColor()
    {
        switch (Type)
        {
            case 0:
                spriteRenderer.color = Color.red;
                break;
            case 1:
                spriteRenderer.color = Color.blue;
                break;
            case 2:
                spriteRenderer.color = Color.green;
                break;
        }
    }

}
