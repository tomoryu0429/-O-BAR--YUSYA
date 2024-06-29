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

    public List<TextMeshProUGUI> EffectLabel;//テキスト文
    public List<TextMeshProUGUI> Select;//選択肢
    [SerializeField] TextMeshProUGUI Eventname;//イベントの名前

    [SerializeField] List<int> percent = new List<int>();//イベント1から4までの選択

    [SerializeField] List<TextMeshProUGUI> UIText = new List<TextMeshProUGUI>();

    [SerializeField] PlayerData pd;//プレイヤーのデータ

    [SerializeField] int E1percent;
    int random;//どのイベントが選択されるか
    int Ernd;//イベント結果の選択
    private void Awake()
    {
        random = Random.Range(1, 101);//1から100までランダム
        //一つ目のイベントへ
        if (random <= percent[0])
        {
            //イベントの名前
            Eventname.text = "運試しをしよう！";
            //メイン
            MainT.GetComponent<MainText>().talk = "目的地に向かって進んでいると裏向きのカードが落ちていた。\nカードをめくって運試しをしよう！";
            //選択肢A
            Select[0].text = "カードをめくる";
            //選択Aテキスト
            EffectLabel[0].text = "成功すればランダムな3つの素材カードの中から1つ選び獲得、失敗すればバトルに突入。\n今回はの確率で失敗する。";
            //選択肢B
            Select[1].text = "その場を離れる";
            //選択Bテキスト
            EffectLabel[1].text = "何も起こらない";
        }
        //二つ目のイベントへ
        else if (random <= percent[1])
        {
            Eventname.text = "冒険に休息は付き物";
            MainT.GetComponent<MainText>().talk = "目的地に向かって進んでいると、疲れを感じた。\n簡易テントと調理キットのどちらを取り出そうか。";
            Select[0].text = "テントで横になって休憩する";
            EffectLabel[0].text = "やる気ゲージをMAXまで回復する。";
            Select[1].text = "素材を調理し、料理を作る";
            EffectLabel[1].text = "「調理」を1回行う";
        }
        //三つ目のイベントへ
        else if (random <= percent[2])
        {
            Eventname.text = "お金とやる気の天秤";
            MainT.GetComponent<MainText>().talk = "洞窟を進んでいると、「チャリーン」と音が鳴った。振り返ると落としたお金を、スライムたちが拾って逃げようとしてる。";
            Select[0].text = "見逃して先へ進む";
            EffectLabel[0].text = "現在のお金の50%を失う。";
            Select[1].text = "お金を取り返す";
            EffectLabel[1].text = "バトルに突入し、勝利するとお金×150を獲得する。";
        }
        //四つ目のイベントへ
        else if (random <= percent[3])
        {
            Eventname.text = "一攫千金チャンス";
            MainT.GetComponent<MainText>().talk = "洞窟を進んでいると、カラフルな鉱脈を発見した。\r\nすぐ近くにボロボロなピッケルも落ちている。";
            Select[0].text = "鈍く灯りを反射する黒色の鉱石を割る";
            EffectLabel[0].text = "運次第でお金を100または500獲得する。\r\n稀に1000獲得する。";
            Select[1].text = "眩しいほど輝く赤色の鉱石を割る";
            EffectLabel[1].text = "美味しそうな素材カードを全種類の中から1つ選び獲得できる。";
            //選択肢C
            Select[2].text = "怪しく光りを放つ紫色の鉱石を割る";
            //選択テキストC
            EffectLabel[2].text = "美味しそうな料理カードをランダムな3つの中から1つ選び獲得できる。";
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        MainT = FindAnyObjectByType<MainText>();
        sentaku = FindAnyObjectByType<Sentaku>();

        //やる気
          pd.ReactiveProperty_YP
          .Subscribe((yp) => { yp.ToString(); })
          .AddTo(this);

        //所持金
          pd.ReactiveProperty_Money
          .Subscribe((money) => { money.ToString(); })
          .AddTo(this);

        Ernd = Random.Range(1, 101);
    }
    // Update is called once per frame
    void Update()
    {
        //イベント1
        if (random <= percent[0])
        {
            Event1();
        }
        //イベント2
        else if(random <= percent[1])
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
    }
    void Event1()
    {
        //データを入手後記載
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //SceneManager.LoadScene()
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
            pd.YP = PlayerData.MAX_YP;

        }
        //結果B（「調理」を一回行う）
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
    }

    void Event3()
    {
        //結果A(現在のお金の50%を失う)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pd.Money /= 2;
        }
        //結果B(バトルに突入し、勝利するとお金×150を獲得する。)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pd.YP *= 3/10;
            //SceneManager.LoadScene();
        }
    }

    void Event4()
    {
        //結果A（お金をランダムで入手）
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
}
