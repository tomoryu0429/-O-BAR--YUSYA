using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField] MainText MainT;
    [SerializeField] Sentaku sentaku;

    [SerializeField] bool NextE = true;
    public bool PercentCheck = false;

    public List<TextMeshProUGUI> EffectLabel;//�e�L�X�g��
    public List<TextMeshProUGUI> Select;//�I����
    [SerializeField] TextMeshProUGUI Eventname;//�C�x���g�̖��O

    [SerializeField] List<int> percent = new List<int>();//�C�x���g1����4�܂ł̑I��

    [SerializeField] List<TextMeshProUGUI> UIText = new List<TextMeshProUGUI>();

    [SerializeField] PlayerData pd;//�v���C���[�̃f�[�^

    [SerializeField] int E1percent;
    int random;//�ǂ̃C�x���g���I������邩
    int Ernd;//�C�x���g���ʂ̑I��
    private void Awake()
    {
        random = Random.Range(1, 101);//1����100�܂Ń����_��
        //��ڂ̃C�x���g��
        if (random <= percent[0])
        {
            //�C�x���g�̖��O
            Eventname.text = "�^���������悤�I";
            //���C��
            MainT.GetComponent<MainText>().talk = "�ړI�n�Ɍ������Đi��ł���Ɨ������̃J�[�h�������Ă����B\n�J�[�h���߂����ĉ^���������悤�I";
            //�I����A
            Select[0].text = "�J�[�h���߂���";
            //�I��A�e�L�X�g
            EffectLabel[0].text = "��������΃����_����3�̑f�ރJ�[�h�̒�����1�I�ъl���A���s����΃o�g���ɓ˓��B\n����͂̊m���Ŏ��s����B";
            //�I����B
            Select[1].text = "���̏�𗣂��";
            //�I��B�e�L�X�g
            EffectLabel[1].text = "�����N����Ȃ�";
        }
        //��ڂ̃C�x���g��
        else if (random <= percent[1])
        {
            Eventname.text = "�`���ɋx���͕t����";
            MainT.GetComponent<MainText>().talk = "�ړI�n�Ɍ������Đi��ł���ƁA�����������B\n�ȈՃe���g�ƒ����L�b�g�̂ǂ�������o�������B";
            Select[0].text = "�e���g�ŉ��ɂȂ��ċx�e����";
            EffectLabel[0].text = "���C�Q�[�W��MAX�܂ŉ񕜂���B";
            Select[1].text = "�f�ނ𒲗����A���������";
            EffectLabel[1].text = "�u�����v��1��s��";
        }
        //�O�ڂ̃C�x���g��
        else if (random <= percent[2])
        {
            Eventname.text = "�����Ƃ��C�̓V��";
            MainT.GetComponent<MainText>().talk = "���A��i��ł���ƁA�u�`�����[���v�Ɖ��������B�U��Ԃ�Ɨ��Ƃ����������A�X���C���������E���ē����悤�Ƃ��Ă�B";
            Select[0].text = "�������Đ�֐i��";
            EffectLabel[0].text = "���݂̂�����50%�������B";
            Select[1].text = "���������Ԃ�";
            EffectLabel[1].text = "�o�g���ɓ˓����A��������Ƃ����~150���l������B";
        }
        //�l�ڂ̃C�x���g��
        else if (random <= percent[3])
        {
            Eventname.text = "�ꝺ����`�����X";
            MainT.GetComponent<MainText>().talk = "���A��i��ł���ƁA�J���t���ȍz���𔭌������B\r\n�����߂��Ƀ{���{���ȃs�b�P���������Ă���B";
            Select[0].text = "�݂�����𔽎˂��鍕�F�̍z�΂�����";
            EffectLabel[0].text = "�^����ł�����100�܂���500�l������B\r\n�H��1000�l������B";
            Select[1].text = "ῂ����قǋP���ԐF�̍z�΂�����";
            EffectLabel[1].text = "�����������ȑf�ރJ�[�h��S��ނ̒�����1�I�ъl���ł���B";
            //�I����C
            Select[2].text = "���������������F�̍z�΂�����";
            //�I���e�L�X�gC
            EffectLabel[2].text = "�����������ȗ����J�[�h�������_����3�̒�����1�I�ъl���ł���B";
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        MainT = FindAnyObjectByType<MainText>();
        sentaku = FindAnyObjectByType<Sentaku>();

        //���C
          pd.ReactiveProperty_YP
          .Subscribe((yp) => { yp.ToString(); })
          .AddTo(this);

        //������
          pd.ReactiveProperty_Money
          .Subscribe((money) => { money.ToString(); })
          .AddTo(this);

        Ernd = Random.Range(1, 101);
    }
    // Update is called once per frame
    void Update()
    {
        //�C�x���g1
        if (random <= percent[0])
        {
            Event1();
        }
        //�C�x���g2
        else if(random <= percent[1])
        {
            Event2();
        }
        //�C�x���g3
        else if (random <= percent[2])
        {
            Event3();
        }
        //�C�x���g4
        else if (random <= percent[3])
        {
            Event4();
        }
    }
    void Event1()
    {
        //�f�[�^������L��
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //SceneManager.LoadScene()
        }
        //����B�i�����N����Ȃ��j
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
    }

    void Event2()
    {
        //����A�i���C�Q�[�W��MAX�܂ŉ񕜂�����j
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pd.YP = PlayerData.MAX_YP;

        }
        //����B�i�u�����v�����s���j
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
    }

    void Event3()
    {
        //����A(���݂̂�����50%������)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pd.Money /= 2;
        }
        //����B(�o�g���ɓ˓����A��������Ƃ����~150���l������B)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pd.YP *= 3/10;
            //SceneManager.LoadScene();
        }
    }

    void Event4()
    {
        //����A�i�����������_���œ���j
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(Ernd <= 60)
            {
                pd.Money += 150;
            }
            else if(Ernd <= 90)
            {
                pd.Money += 500;
            }
            else if(Ernd <= 100)
            {
                pd.Money += 1000;
            }
        }
        //����B
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //������ς��n
            if(Ernd <= 50)
            {

            }
            //�Â��n
            else if(Ernd <= 100)
            {

            }
        }
        //����C�i�����������ȗ����J�[�h�������_����3�̂�����1��I�ԁj
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {


        }
    }
}
