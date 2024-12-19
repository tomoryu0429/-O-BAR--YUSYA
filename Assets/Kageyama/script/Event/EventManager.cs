using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;
using R3.Triggers;
using UnityEditor.Experimental.GraphView;

public class EventManager : MonoBehaviour
{
    [SerializeField] MainText MainT;
    [SerializeField] EventSelect Es;

    [SerializeField] bool NextE = true;
    public bool PercentCheck = false;

    public List<TextMeshProUGUI> EffectLabel;//�e�L�X�g��
    public List<TextMeshProUGUI> select;//�I����
    [SerializeField] TextMeshProUGUI Eventname;//�C�x���g�̖��O

    [Header("�C�x���g�m��"), SerializeField] List<int> percent = new List<int>();//�C�x���g1����4�܂ł̑I��
    [SerializeField] List<GameObject> effectobj = new List<GameObject>();//�G�t�F�N�g�I��\��

    [SerializeField] int E1percent;
    int random;//�ǂ̃C�x���g���I������邩

    [SerializeField] EventDataAsset edata_asset;
        
    void Awake()
    {
        EventSelection();
        Es.EventList();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        MainT = FindAnyObjectByType<MainText>();

        //���C
        PlayerData.Instance.Status.Motivation.Observable
            .Subscribe(yaruki => yaruki.Value.ToString())
            .AddTo(this);

        //������
        PlayerData.Instance.Status.Money.Observable
            .Subscribe(money => money.Value.ToString())
            .AddTo(this);

        //�Ă΂��C�x���g
        if (random <= percent[0])
        {
            Es.eventlist[0]();
        }

        for (int i = 1; i < 4; i++)
        {
            if (random > percent[i - 1] && random <= percent[i])
            {
                Es.eventlist[i]();
            }
        }
        /*
        //�C�x���g1
        if (random <= percent[0])
        {
            Event1();
        }
        //�C�x���g2
        else if (random <= percent[1])
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
        */

        //�C�x���g1�@�I����1
        Es.selectcard
            .Where(select => select == true)
            .Subscribe(_ =>
            {
                effectobj[0].transform.Translate(0, 30, 0);
                effectobj[1].transform.Translate(0, 35, 0);
                effectobj[2].SetActive(true);

                select[0].text = "" + Es.select_id[0];
                select[1].text = "" + Es.select_id[1];
                select[2].text = "" + Es.select_id[2];

                EffectLabel[0].text = "";
                EffectLabel[1].text = "";
                EffectLabel[2].text = "";
            })
            .AddTo(this);

    }

   
    /*
    void Event1()
    {
        //�f�[�^������L��
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("TransitionScene");
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
            PlayerData.Instance.Status.Motivation.Value = 100;

        }
        //����B�i�u�����v�����s���j
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //SceneManager.LoadScene
        }
    }

    void Event3()
    {
        //����A(���݂̂�����50%������)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerData.Instance.Status.Money.Value /= 2;
        }
        //����B(�o�g���ɓ˓����A��������Ƃ����~150���l������B)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //SceneManager.LoadScene();
        }
    }

    void Event4()
    {
        Ernd = UnityEngine.Random.Range(1, 101);
        //����A�i�����������_���œ���j
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(Ernd <= 60)
            {
                PlayerData.Instance.Status.Money.Value += 150;
            }
            else if(Ernd <= 90)
            {
                PlayerData.Instance.Status.Money.Value += 500;
            }
            else if(Ernd <= 100)
            {
                PlayerData.Instance.Status.Money.Value += 1000;
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
    */

    void EventSelection()
    {
        random = UnityEngine.Random.Range(1, 101);//1����100�܂Ń����_��

        if (random < percent[3])
        {
            effectobj[0].transform.Translate(0, -30, 0);
            effectobj[1].transform.Translate(0, -35, 0);
            effectobj[2].SetActive(false);
        }

        for (int i = 0; i < 4; i++)
        {
            if (random <= percent[i])
            {
                Eventname.text = edata_asset.eventdataList[i].EventName;
                MainT.GetComponent<MainText>().talk = edata_asset.eventdataList[i].MainText;
                select[0].text = edata_asset.eventdataList[i].SelectA;
                EffectLabel[0].text = edata_asset.eventdataList[i].EffectA;
                select[1].text = edata_asset.eventdataList[i].SelectB;
                EffectLabel[1].text = edata_asset.eventdataList[i].EffectB;
                //�I����C
                select[2].text = edata_asset.eventdataList[i].SelectC;
                //�I���e�L�X�gC
                EffectLabel[2].text = edata_asset.eventdataList[i].EffectC;
                return;
            }
        }

    }

}
