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

    //�J�[�h�g�p�m�F�̃J�[�h
    public void setCard(GameObject selectObject)
    {
        
        checkCard = selectObject;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//�n���ꂽ�J�[�h���i�[
        attachedCardScripts = checkCard.GetComponent<Card>();   //�i�[�����J�[�h�̃X�N���v�g���擾
       
    }

    //�J�[�h�̎g�p�̊l��
    public void Use()
    {
        attachedCardScripts.UsethisCard();
    }

    //�J�[�h�̎d�l�̃L�����Z��
    public void Cancele()
    {
        attachedCardScripts.CanceleUseing();
    }
}
