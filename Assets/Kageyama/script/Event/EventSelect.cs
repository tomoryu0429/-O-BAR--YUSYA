using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.FlowStateWidget;
using UnityEngine.UI;
using R3;

public class EventSelect : MonoBehaviour
{
    public List<Action> eventlist = new List<Action>();
    int Ernd;//イベント結果の選択
   // public int number;//ボタン使用の際の番号
    public ReactiveProperty<bool> selectcard = new ReactiveProperty<bool>();

    public List<AutoEnum.ECardID> select_id = new List<AutoEnum.ECardID>();

    [SerializeField] List<Button> selectbutton = new List<Button>();

    [SerializeField] List<int> probability = new List<int>();
    private void Awake()
    {

    }

    public void EventList()
    {
        //イベント1
        eventlist.Add(() =>
        {
            ButtonSelect();

            selectbutton[0].OnClickAsObservable()
               .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
               .Subscribe(_ =>
               {
                   SelectID();
                   selectcard.Value = true;
               })
               .AddTo(this);

            selectbutton[1].OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ => TransitionSceneLoad())
            .AddTo(this);

        });

        //イベント2
        eventlist.Add(() =>
        {
            //結果A（やる気ゲージをMAXまで回復させる）
            selectbutton[0].OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ =>
            {
                PlayerData.Instance.Status.Motivation.Value = 100;
                TransitionSceneLoad();
            })
            .AddTo(this);

/*
            //結果B（「調理」を一回行う）
            selectbutton[1].OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ => )//SceneManager.LoadScene()料理シーンへ
            .AddTo(this);
*/
            
        });

        //イベント3
        eventlist.Add(() =>
        {
            //結果A(現在のお金の50%を失う)
            selectbutton[0].OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ =>
            {
                PlayerData.Instance.Status.Money.Value /= 2;
                TransitionSceneLoad();
            });

            //(やる気ゲージを30％消費)バトルに突入し、勝利するとお金×150を獲得する。
            selectbutton[1].OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ =>
            {
                PlayerData.Instance.Status.Motivation.Value = (int)(PlayerData.Instance.Status.Motivation.Value * 0.7f);
                //SceneManager.LoadScene();バトル
            })
            .AddTo(this);

        });

        //イベント4
        eventlist.Add(() =>
        {
            Ernd = UnityEngine.Random.Range(1, 101);
            //結果A（お金をランダムで入手）
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //60%
                if (Ernd <= probability[0])
                {
                    PlayerData.Instance.Status.Money.Value += 150;
                }
                //30%
                else if (Ernd <= probability[0] + probability[1])
                {
                    PlayerData.Instance.Status.Money.Value += 500;
                }
                //10%
                else if (Ernd <= probability[0] + probability[1] + probability[2])
                {
                    PlayerData.Instance.Status.Money.Value += 1000;
                }
                TransitionSceneLoad();
            }
            //結果B
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //しょっぱい系
                if (Ernd <= 50)
                {

                }
                //甘い系
                else if (Ernd <= 100)
                {

                }
            }
            //結果C（美味しそうな料理カードをランダムに3つのうちに1つを選ぶ）
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {


            }
        });
    }

    void SelectID()
    {
        for(int i = 0; i < 3; i++)
        {
            select_id[i] = EnumSystem.GetRandom<AutoEnum.ECardID>();
        }
    }

    void ButtonSelect()
    {
        for (int i = 0; i < 3;i++)
        {
            int index = i;
            selectbutton[index].OnClickAsObservable()
                .Where(_ => selectcard.Value)
                .Subscribe(_ =>
                {
                    Debug.Log(index);

                    PlayerData.Instance.CardManager.HandCardContainer.Add(select_id[index]);
                    selectcard.Value = false;
                    TransitionSceneLoad();
                });
        }
    }

    void TransitionSceneLoad()
    {
        //Tierを上げる
        SceneManager.LoadScene("TransitionScene");
    }
}
