using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{

    public int _maxHp = 100;
    public int _maxYp = 100;

    int _NowHp;
    int _NowYp;
    int _NowDef;
    int _NowPow;

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
        phpBar.fillAmount = (float)_NowHp / (float)_maxHp; 
        pypBar.fillAmount = (float)_NowYp / (float)_maxYp;

    }

    public void playerInit()
    {
        _NowHp = _maxHp;
        _NowYp = _maxYp;
        _NowDef = 0;
        UpdatepState();

        phpBar.fillAmount = 1;
        pypBar.fillAmount = 1;
    }

    public void PlayerDamage(int damage)
    {
        int damageSum = damage - _NowDef;

        if(damageSum < 0)
        {
            damageSum = 0;
        }

        _NowHp -= damageSum;
    }

    public void PlayerYarukiValueChange(int value = -5)
    {
        _NowYp += value;
    }
    public void PlayerDefenceValueChange(int value )
    {
        _NowDef += value;
    }

    public int getPlayerAttackPower()
    {
        return _NowPow;
    }

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