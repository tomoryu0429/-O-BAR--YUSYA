using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Linq.Expressions;

public class HPBar : MonoBehaviour
{
    //UI
    [SerializeField] Text text;
    [SerializeField] Slider slider;
    [SerializeField] Image sliderFill;

    //�A�j���[�V�����̎���
    [SerializeField] float animTime;

    //HP�̍ő�l
    [SerializeField] int maxHP;
    [SerializeField] int maxYP = 80;

    //���C�Q�[�W�̌���
    [SerializeField] float ypdamage = 0.05f;
    //�^�[����
    public TurnManager addTurnState;

    //HP��0�`�ő�l�̊�
    int hp;
    int yp;
    int HP
    {
        get => hp;
        set => hp = Mathf.Clamp(value, 0, maxHP);
    }
    int YP
    {
        get => yp;
        set => yp = Mathf.Clamp(value,0, maxYP);
    }

    void Start()
    {
        //�^�[�����̊m�F
        int TurnNum = 0;

        //HP���ő�l�ɂ���
        HP = maxHP;

        //YP���ő�l�ɂ���
        YP = maxYP;

        //UI�̍X�V
        UpdateUI(HP);

        //UI�̍X�V
        UpdateUI(YP);//�o�O��Ȃ��̂��F��
    }

    //UI(�X���C�_�[�ƃe�L�X�g)
    void UpdateUI(float animHP)
    {
        //UI��ύX
        text.text = $"{(int)animHP}/{maxHP}";
        slider.value = animHP / maxHP;

        //�c��HP�ɉ����ăX���C�_�[�̐F��ύX
        if (slider.value < 0.25f)
        {
            sliderFill.color = Color.red;
        }
        else if (slider.value < 0.5f)
        {
            sliderFill.color = Color.yellow;
        }
        else
        {
            sliderFill.color = Color.green;
        }
    }

    public IEnumerator Attacked(int damage)
    {
        //�_���[�W��^����O��HP���擾
        float animHP = HP;

        //�_���[�W��^�������HP���v�Z
        HP -= damage;

        //HP��ړI�̒l�܂œ�����
        yield return DOTween.To(() => animHP, (x) => animHP = x, HP, animTime)
            .SetEase(Ease.Linear)
            .OnUpdate(() => UpdateUI(animHP));
    }
    public IEnumerator YPDegreeced(int ypdamage)
    {
        yield return new WaitForSeconds(1);
        YP -= ypdamage;
        int addTurnState = (int)TurnManager.turnState;
        if (addTurnState > 0)
        {
            TurnManager.AddTurnState();
        }
        //v = YP == addTurnState * 0.05;
    }//�^�[�����i�ނ��ƂɂT�����C�Q�[�W������������
}