using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using UnityEngine.SceneManagement;
using TMPro;
using R3.Triggers;
using System;
using UnityEngine.Events;

public class SceneTransition : MonoBehaviour
{
    public SerializableReactiveProperty<int> Tier = new SerializableReactiveProperty<int>();
    [SerializeField] List<Button> selectbutton = new List<Button>();
    [SerializeField] List<GameObject> selectcanvas = new List<GameObject>();
    [SerializeField] List<TextMeshProUGUI> paratext = new List<TextMeshProUGUI>();
    List<Action> stagelist = new List<Action>();
    [SerializeField] Image motivationgage;

    void Start()
    {
        Tier.Value++;

        Parameter();

        StageList();

        //‰æ‘œ•\Ž¦‚Ì•ÏX
        Tier
            .Subscribe(tier => stagelist[tier]())
            .AddTo(this);

    }

    void Parameter()
    {
        float percent = (float)PlayerData.Instance.Status.Motivation.Value / 100;
        motivationgage.fillAmount = percent;
        paratext[0].text = "HP(" + PlayerData.Instance.Status.Health.Value + "/100)";
        paratext[1].text = Tier + "/5";
        paratext[2].text = "" + PlayerData.Instance.Status.Money.Value;
    }

    void StageList()
    {
        stagelist.Add(() =>
        {
            selectcanvas[0].SetActive(true);
            selectcanvas[1].SetActive(false);
            selectcanvas[2].SetActive(false);
        });

        stagelist.Add(() =>
        {
            selectcanvas[0].SetActive(false);
            selectcanvas[1].SetActive(true);
            selectcanvas[2].SetActive(false);
        });

        stagelist.Add(() =>
        {
            selectcanvas[0].SetActive(false);
            selectcanvas[1].SetActive(false);
            selectcanvas[2].SetActive(true);
        });
    }

}
