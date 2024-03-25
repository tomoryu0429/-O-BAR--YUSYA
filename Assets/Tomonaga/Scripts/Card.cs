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
    Food thisFood;

    private bool selected = false;

   
    public PlayCheckCard checkScripts;

    public SpriteRenderer spriteRenderer;        //���̃J�[�h�̃X�v���C�g�����_���[
    public Sprite[] cardSprite = new Sprite[12];
    public Transform poolPos;             //��ʊO�̃J�[�h�ҋ@�ꏊ�̍��W
    CardBoardManager cbMa;                //�J�[�h�{�[�h�}�l�[�W���[�̃C���X�^���X
    public Transform playPos;
    public bool isCookCard  = false;                  //�����J�[�h���f�ރJ�[�h��
    public EffectManager effectManager;
    public CardManager cardManager;
    EventTrigger GetTrigger;
    public GameObject playcheck;

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

    //�J�[�h�I�����̏���
    void OnMouseDown()
    {
        if (selected == true && state == CardState.Hand && FazeManager.NowCardFaze == CardFaze.Selsect)
        {
            Debug.Log("�g�p");
            playcheck.SetActive(true);
            checkScripts.setCard(this.gameObject);
            FazeManager.NowCardFaze = CardFaze.Play;
        }
    }

    //�J�[�h�g�p
    public void UsethisCard()
    {   
        selected = false;
        for(int i = 0;i< thisFood.getEffectNum(); i++){
            if(thisFood.getInfo(i).effect == FoodEffect.CardEfcUp){
                effectManager.BufEffect(thisFood.getInfo(i-1),thisFood.getInfo(i).size);
            }
            else if(thisFood.getInfo(i).effect == FoodEffect.UsableCardAdd){
                cardManager.setisUsableCardNumIncreasing(true);
            }
            else{
                effectManager.EffectHub(thisFood.getInfo(i));
            }
        } 
        playcheck.SetActive(false);
        state = CardState.Gabage;

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
