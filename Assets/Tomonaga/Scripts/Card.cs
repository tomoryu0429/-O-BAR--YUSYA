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

    public FoodKinds type;      //�J�[�h�̐H�ރ^�C�v
    Food thisFood;              //���̃J�[�h��Food�R���|�[�l���g�i�X�N���v�g�j

    private bool selected = false;  //�I������Ă����Ԃ�

   
    public PlayCheckCard checkScripts;  //PlayerCheckCard�X�N���v�g

    public SpriteRenderer spriteRenderer;           //���̃J�[�h�̃X�v���C�g�����_���[
    public Sprite[] cardSprite = new Sprite[12];    //�e�H�ނɑΉ������X�v���C�g
    public Transform poolPos;                       //��ʊO�̃J�[�h�ҋ@�ꏊ�̍��W
    CardBoardManager cbMa;                          //�J�[�h�{�[�h�}�l�[�W���[�̃C���X�^���X
    public Transform playPos;                       //�J�[�h���o����̈ʒu
    public bool isCookCard  = false;                //�����J�[�h���f�ރJ�[�h��
    public EffectManager effectManager;             //effectManager�i�X�N���v�g�j
    public CardManager cardManager;                 //cardManager(�X�N���v�g)
    EventTrigger GetTrigger;
    public GameObject playcheck;                    //Playcheck�I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        setCardDesing();
        spriteRenderer = GetComponent<SpriteRenderer>();
        thisFood = this.GetComponent<Food>();
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
    
    //Reset�����ƎR�D��
    public void ResetState()
    {
        state = CardState.Mountain;
        FazeManager.NowCardFaze = CardFaze.Draw;
    }

    //���g�̐H�ރ^�C�v�ɍ��킹�āA�J�[�h�̃f�U�C����ς���
    private void setCardDesing()
    {
        spriteRenderer.sprite = cardSprite[(int)type];
    }

    //��D����J�[�h��I�ԃt�F�C�Y�̎��ɃJ�[�\�������킹��Ƒ傫���Ȃ�
    void OnMouseEnter()
    {
        if (state == CardState.Hand && FazeManager.NowCardFaze == CardFaze.Selsect)
        {
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Debug.Log("UP");
            selected = true;
        }
    }


    //�J�[�\���������ƌ��ɖ߂�
    void OnMouseExit()
    {
        if (state == CardState.Hand && FazeManager.NowCardFaze == CardFaze.Selsect)
        {
            this.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            Debug.Log("Down");
            selected = false;
        }
    }

    //�J�[�h�I�����̏���
    void OnMouseDown()
    {
        if (selected == true && state == CardState.Hand && FazeManager.NowCardFaze == CardFaze.Selsect)
        {
            Debug.Log("�g�p");
            //�g�p���邩�ǂ����̊m�F�E�B���h�E�\��
            playcheck.SetActive(true);
            //�m�F�����J�[�h��n��
            checkScripts.setCard(this.gameObject);
            FazeManager.NowCardFaze = CardFaze.Play;
        }
    }

    //�J�[�h�g�p
    public void UsethisCard()
    {   
        selected = false;
        //�J�[�h�̌��ʔ���
        for(int i = 0;i< thisFood.getEffectNum(); i++){
            //�J�[�h���ʏ㏸�̏ꍇ
            if(thisFood.getInfo(i).effect == FoodEffect.CardEfcUp){
                effectManager.BufEffect(thisFood.getInfo(i-1),thisFood.getInfo(i).size);
            }
            //�J�[�h�g�p�����̑����̏ꍇ
            else if(thisFood.getInfo(i).effect == FoodEffect.UsableCardAdd){
                cardManager.setisUsableCardNumIncreasing(true);
            }
            //����ȊO�̌��ʂ̏ꍇ
            else{
                effectManager.EffectHub(thisFood.getInfo(i));
            }
        }
        
        //PlayerCheck�I�u�W�F�N�g�̔�\��
        playcheck.SetActive(false);

        //�̂ĎD��
        state = CardState.Gabage;

        //�J�[�h�̎g�p�\�������������Ȃ�A�������������B�������łȂ��Ȃ玟�̏�����
        if (!cardManager.getisUsableCardNumIncreasing()){
            cardManager.ThrowCard();
        }
        else{
            cardManager.setisUsableCardNumIncreasing(false);
        }
    }

    //�J�[�h�g�p�L�����Z��
    public void CanceleUseing()
    {
        selected = false;
        playcheck.SetActive(false);
        FazeManager.NowCardFaze = CardFaze.Selsect;

    }
}
