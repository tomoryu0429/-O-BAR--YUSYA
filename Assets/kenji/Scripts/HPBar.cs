using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HPBar : TurnManager
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
    protected int damage = 1;

    //HP��0�`�ő�l�̊�
    int hp;
    int yp;

    public enum pState
    {
        Yaruki0, Yaruki26, Yaruki51, Yaruki70, Yaruki90,
    }//PlayerManager����
    protected int HP
    {
        get => hp;
        set => hp = Mathf.Clamp(value, 0, maxHP);
    }
    protected int YP
    {
        get => yp;
        set => yp = Mathf.Clamp(value,0, maxYP);
    }

    void Start()
    {

        //HP���ő�l�ɂ���
        HP = maxHP;

        //YP���ő�l�ɂ���
        YP = maxYP;

        //UI�̍X�V
        UpdateUI(HP);

        //UI�̍X�V
        UpdateUI(YP);//�o�O��Ȃ��̂��F��
    }
    private void Update()
    {
        setpState();//PlayerManager����
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
        public void setpState()
    {
        if (YP < 90)
        {
            PlayerChenge.NowpState = pState.Yaruki70;
        }
        if (YP < 70)
        {
            PlayerChenge.NowpState = pState.Yaruki51;
        }
        if (YP < 51)
        {
            PlayerChenge.NowpState = pState.Yaruki26;
        }
        if (YP < 26)
        {
            PlayerChenge.NowpState = pState.Yaruki0;
        }
        if (YP >= 90)
        {
            PlayerChenge.NowpState = pState.Yaruki90;
        }
    }//PlayerManager����

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
        if (turnState == TurnState.HeroAttack)
        {
            YP -= ypdamage;
        }
    }//�^�[�����i�ނ��ƂɂT�����C�Q�[�W������������
    protected void Die()
    {
        if (HP <= 0)
        {
            Debug.Log("����");
        }
    }
}