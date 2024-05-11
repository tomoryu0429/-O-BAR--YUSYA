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

    //アニメーションの時間
    [SerializeField] float animTime;

    //HPの最大値
    [SerializeField] int maxHP;
    [SerializeField] int maxYP = 80;

    //HPは0～最大値の間
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
        set => yp = Mathf.Clamp(value,0, maxHP);
    }

    void Start()
    {
        //HPを最大値にする
        HP = maxHP;

        //YPを最大値にする
        YP = maxYP;

        //UIの更新
        UpdateUI(HP);

        //UIの更新
        UpdateUI(YP);//バグらないのを祈る
    }

    //UI(スライダーとテキスト)
    void UpdateUI(float animHP)
    {
        //UIを変更
        text.text = $"{(int)animHP}/{maxHP}";
        slider.value = animHP / maxHP;

        //残りHPに応じてスライダーの色を変更
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
        //ダメージを与える前のHPを取得
        float animHP = HP;

        //ダメージを与えた後のHPを計算
        HP -= damage;

        //HPを目的の値まで動かす
        yield return DOTween.To(() => animHP, (x) => animHP = x, HP, animTime)
            .SetEase(Ease.Linear)
            .OnUpdate(() => UpdateUI(animHP));
    }

    public IEnumerator YPDegreeced(int ypdamage)
    {
        yield return new WaitForSeconds(1);
        YP -= ypdamage;
    }
}