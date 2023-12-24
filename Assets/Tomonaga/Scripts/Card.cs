using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static Unity.Burst.Intrinsics.Arm;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

/// <summary>
/// �J�[�h1���P���̋���
/// </summary>


//�J�[�h�̌���
public enum CardState
{
    Mountain,
    Hand,
    Gabage,
    Death,
    Pool,
}



public class Card : MonoBehaviour
{
    public CardState state;     //�J�[�h�̏�

    public FoodKinds type;

    private bool selected = false;

    public SpriteRenderer spriteRenderer; //���̃J�[�h�̃X�v���C�g�����_���[
    public Sprite[] cardSprite = new Sprite[12];
    public Transform poolPos;             //��ʊO�̃J�[�h�ҋ@�ꏊ�̍��W
    CardBoardManager cbMa;                //�J�[�h�{�[�h�}�l�[�W���[�̃C���X�^���X
    public Transform playPos;
    public bool isCookCard  = false;                  //�����J�[�h���f�ރJ�[�h��

    EventTrigger GetTrigger;

    // Start is called before the first frame update
    void Start()
    {

      
        ////�Q�[�����n�܂������͎R�D
        //if(!isCookCard)
        //    state = CardState.Mountain;
        //else
        //    state = CardState.Pool;
    }

    // Update is called once per frame
    void Update()
    {
        CardPosition();
        setCardDesing();
    }

    //�󋵂���D�łȂ��ꍇ�A�ҋ@�ꏊ��
    void CardPosition()
    {
        if(state != CardState.Hand)
        {
            this.transform.position = poolPos.position;
        }
    }
    
    //Reset�����ƎR�D��
    public void ResetState()
    {
        state = CardState.Mountain;
        FazeManager.NowCardFaze = CardFaze.Draw;
    }

    private void setCardDesing()
    {
        spriteRenderer.sprite = cardSprite[(int)type];
    }

    void OnMouseEnter()
    {
        if (state == CardState.Hand && FazeManager.NowCardFaze == CardFaze.Selsect)
        {
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Debug.Log("UP");
            selected = true;
        }
    }

    void OnMouseExit()
    {
        if (state == CardState.Hand && FazeManager.NowCardFaze == CardFaze.Selsect)
        {
            this.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            Debug.Log("Down");
            selected = false;
        }
    }

    void OnMouseDown()
    {
        if (selected == true && state == CardState.Hand)
        {
            Debug.Log("�g�p");
            this.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            this.transform.localPosition = playPos.localPosition;
            selected = false;
            EffectManager.EffectHub(type);
            FazeManager.NowCardFaze = CardFaze.Throw;
        }
    }
}
