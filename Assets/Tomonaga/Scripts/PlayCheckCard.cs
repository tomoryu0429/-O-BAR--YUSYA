using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCheckCard : MonoBehaviour
{
    public GameObject checkCard = null; 
    Card attachedCardScripts = null;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //カード使用確認のカード
    public void setCard(GameObject selectObject)
    {
        
        checkCard = selectObject;　　　　　　　　　　　　　　　　　//渡されたカードを格納
        attachedCardScripts = checkCard.GetComponent<Card>();   //格納したカードのスクリプトを取得
       
    }

    //カードの使用の獲得
    public void Use()
    {
        attachedCardScripts.UsethisCard();
    }

    //カードの仕様のキャンセル
    public void Cancele()
    {
        attachedCardScripts.CanceleUseing();
    }
}
