using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HPBar;

public class PlayerChenge : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] pSprite = new Sprite[3];
    public static pState NowpState = pState.Yaruki90;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (NowpState)
        {
            case pState.Yaruki0: case pState.Yaruki26:
                spriteRenderer.sprite = pSprite[0];
                break;
            case pState.Yaruki51: case pState.Yaruki70:
                spriteRenderer.sprite = pSprite[1];
                break;
            case pState.Yaruki90:
                spriteRenderer.sprite = pSprite[2];
                break;
                default: break;
        }

    }
}
