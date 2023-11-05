using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
    Mountain,
    Hand,
    Gabage,
}

public class Card : MonoBehaviour
{
    public State state;     //�J�[�h�̏�
    public int Type; //�J�[�h�̎��

    public SpriteRenderer spriteRenderer ;
    public GameObject poolPos;
    CardBoardManager cbMa;


    // Start is called before the first frame update
    void Start()
    {
        CardColor();
        state = State.Mountain;
    }

    // Update is called once per frame
    void Update()
    {
        CardPosition();
    }

    void CardPosition()
    {
        if(state != State.Hand)
        {
            this.transform.position = poolPos.transform.position;
        }
    }

    

    public void ResetState()
    {
        state = State.Mountain;
    }

    //����p
    void CardColor()
    {
        switch (Type)
        {
            case 0:
                spriteRenderer.color = Color.red;
                break;
            case 1:
                spriteRenderer.color = Color.blue;
                break;
            case 2:
                spriteRenderer.color = Color.green;
                break;
        }
    }

}
