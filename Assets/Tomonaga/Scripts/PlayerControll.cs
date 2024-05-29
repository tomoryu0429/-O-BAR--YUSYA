using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{

    public int _maxHp = 100;        //HPの上限
    public int _maxYp = 100;        //やる気の上限

    int _NowHp;                     //現在のHP
    int _NowYp;                     //現在のやるき
    int _NowDef;                    //現在の防御力
    int _NowPow;                    //現在の攻撃力

    SpriteRenderer spriteRenderer;
    public Sprite[] pSprite = new Sprite[3];

    public Image phpBar;
    public Image pypBar;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInit();
    }

    // Update is called once per frame
    void Update()
    {
        //HPバーとやる気バーの値は常にプレイヤーのパラメータを参照
        phpBar.fillAmount = (float)_NowHp / (float)_maxHp; 
        pypBar.fillAmount = (float)_NowYp / (float)_maxYp;

    }

    //プレイヤーのパラメータの初期化
    public void playerInit()
    {
        _NowHp = _maxHp;
        _NowYp = _maxYp;
        _NowDef = 0;
        UpdatepState();

        phpBar.fillAmount = 1;
        pypBar.fillAmount = 1;
    }

    //プレイヤーのダメージ判定
    public void PlayerDamage(int damage)
    {
        int damageSum = damage - _NowDef;

        if(damageSum < 0)
        {
            damageSum = 0;
        }

        _NowHp -= damageSum;
    }

    //やるきの値の減少
    public void PlayerYarukiValueChange(int value = -5)
    {
        _NowYp += value;
    }

    //防御力の値は減少
    public void PlayerDefenceValueChange(int value )
    {
        _NowDef += value;
    }

    //プレイヤーの攻撃力の取得
    public int getPlayerAttackPower()
    {
        return _NowPow;
    }

    //やる気の値によって攻撃力や見た目を変更する
    public void UpdatepState()
    {
        if (_NowYp < 90)
        {
            _NowPow = 25;
            spriteRenderer.sprite = pSprite[1];
        }
        else if (_NowYp < 71)
        {
            _NowPow = 20;
            spriteRenderer.sprite = pSprite[1];
        }
        else if (_NowYp < 51)
        {
            _NowPow = 10;
            spriteRenderer.sprite = pSprite[2];
        }
        else if (_NowYp < 26)
        {
            _NowPow = 0;
            spriteRenderer.sprite = pSprite[2];
        }
        else
        {
            _NowPow = 35;
            spriteRenderer.sprite = pSprite[0];
        }
    }

}