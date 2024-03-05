using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCheckCard : MonoBehaviour
{
    public GameObject checkCard = null; 
    Card attachedCardScripts = null;
    //SpriteRenderer CardSprite = null;

    //private Image imageComponent;

    // Start is called before the first frame update
    void Start()
    {
        //imageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCard(GameObject selectObject)
    {
        checkCard = selectObject;
        attachedCardScripts = checkCard.GetComponent<Card>();
        //imageComponent.sprite = attachedCardScripts.GetComponent<SpriteRenderer>().sprite;
    }

    public void Use()
    {
        attachedCardScripts.UsethisCard();
    }

    public void Cancele()
    {
        attachedCardScripts.CanceleUseing();
    }
}
