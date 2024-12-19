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
    int Ernd;//�C�x���g���ʂ̑I��
   // public int number;//�{�^���g�p�̍ۂ̔ԍ�
    public ReactiveProperty<bool> selectcard = new ReactiveProperty<bool>();

    public List<AutoEnum.ECardID> select_id = new List<AutoEnum.ECardID>();

    [SerializeField] List<Button> selectbutton = new List<Button>();

    [SerializeField] List<int> probability = new List<int>();
    private void Awake()
    {

    }

    public void EventList()
    {
        //�C�x���g1
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

        //�C�x���g2
        eventlist.Add(() =>
        {
            //����A�i���C�Q�[�W��MAX�܂ŉ񕜂�����j
            selectbutton[0].OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ =>
            {
                PlayerData.Instance.Status.Motivation.Value = 100;
                TransitionSceneLoad();
            })
            .AddTo(this);

/*
            //����B�i�u�����v�����s���j
            selectbutton[1].OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ => )//SceneManager.LoadScene()�����V�[����
            .AddTo(this);
*/
            
        });

        //�C�x���g3
        eventlist.Add(() =>
        {
            //����A(���݂̂�����50%������)
            selectbutton[0].OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ =>
            {
                PlayerData.Instance.Status.Money.Value /= 2;
                TransitionSceneLoad();
            });

            //(���C�Q�[�W��30������)�o�g���ɓ˓����A��������Ƃ����~150���l������B
            selectbutton[1].OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ =>
            {
                PlayerData.Instance.Status.Motivation.Value = (int)(PlayerData.Instance.Status.Motivation.Value * 0.7f);
                //SceneManager.LoadScene();�o�g��
            })
            .AddTo(this);

        });

        //�C�x���g4
        eventlist.Add(() =>
        {
            Ernd = UnityEngine.Random.Range(1, 101);
            //����A�i�����������_���œ���j
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
            //����B
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //������ς��n
                if (Ernd <= 50)
                {

                }
                //�Â��n
                else if (Ernd <= 100)
                {

                }
            }
            //����C�i�����������ȗ����J�[�h�������_����3�̂�����1��I�ԁj
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
        //Tier���グ��
        SceneManager.LoadScene("TransitionScene");
    }
}
