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

    public List<TextMeshProUGUI> EffectLabel;//テキスト文
    public List<TextMeshProUGUI> select;//選択肢
    [SerializeField] TextMeshProUGUI Eventname;//イベントの名前

    [Header("イベント確率"), SerializeField] List<int> percent = new List<int>();//イベント1から4までの選択
    [SerializeField] List<GameObject> effectobj = new List<GameObject>();//エフェクト選択表示

    [SerializeField] int E1percent;
    int random;//どのイベントが選択されるか

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

        //やる気
        PlayerData.Instance.Status.Motivation.Observable
            .Subscribe(yaruki => yaruki.Value.ToString())
            .AddTo(this);

        //所持金
        PlayerData.Instance.Status.Money.Observable
            .Subscribe(money => money.Value.ToString())
            .AddTo(this);

        //呼ばれるイベント
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
        //イベント1
        if (random <= percent[0])
        {
            Event1();
        }
        //イベント2
        else if (random <= percent[1])
        {
            Event2();
        }
        //イベント3
        else if (random <= percent[2])
        {
            Event3();
        }
        //イベント4
        else if (random <= percent[3])
        {
            Event4();
        }
        */

        //イベント1　選択肢1
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
        //データを入手後記載
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("TransitionScene");
        }
        //結果B（何も起こらない）
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
    }
    void Event2()
    {
        //結果A（やる気ゲージをMAXまで回復させる）
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerData.Instance.Status.Motivation.Value = 100;

        }
        //結果B（「調理」を一回行う）
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //SceneManager.LoadScene
        }
    }

    void Event3()
    {
        //結果A(現在のお金の50%を失う)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerData.Instance.Status.Money.Value /= 2;
        }
        //結果B(バトルに突入し、勝利するとお金×150を獲得する。)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //SceneManager.LoadScene();
        }
    }

    void Event4()
    {
        Ernd = UnityEngine.Random.Range(1, 101);
        //結果A（お金をランダムで入手）
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
        //結果B
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //しょっぱい系
            if(Ernd <= 50)
            {

            }
            //甘い系
            else if(Ernd <= 100)
            {

            }
        }
        //結果C（美味しそうな料理カードをランダムに3つのうちに1つを選ぶ）
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {


        }
    }
    */

    void EventSelection()
    {
        random = UnityEngine.Random.Range(1, 101);//1から100までランダム

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
                //選択肢C
                select[2].text = edata_asset.eventdataList[i].SelectC;
                //選択テキストC
                EffectLabel[2].text = edata_asset.eventdataList[i].EffectC;
                return;
            }
        }

    }

}
