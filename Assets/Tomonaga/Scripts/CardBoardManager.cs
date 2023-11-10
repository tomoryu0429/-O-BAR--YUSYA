using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CardBoardManager : MonoBehaviour
{
    public static int _MountainCardNum = 9;     //ŽRŽD‚Ì–‡”‚Ì
    public static int _HandCardNum = 0;         //ŽèŽD‚Ì–‡”‚Ì
    public static int _GabageCardNum = 0;       //ŽÌ‚ÄŽD‚Ì–‡”
    public GameObject _MountainCard;            //ŽRŽD
    public GameObject _GabageCard;              //ŽÌ‚ÄŽD


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GabageZoneCtrl();
        MountainZoneCtrl();
    }

    //ƒfƒoƒbƒO—pƒŠƒZƒbƒg
    public void Reset()
    {
        _MountainCardNum = 9;
        _HandCardNum = 0;
        _GabageCardNum = 0;
    }

    //ŽRŽD•\Ž¦‚Ì§Œä
    void MountainZoneCtrl()
    {
        //ŽRŽD‚Ì–‡”‚ª0‚ÅŽRŽD‚ª•\Ž¦‚³‚ê‚Ä‚¢‚éŽžAŽRŽD‚Ì•\Ž¦‚ðÁ‚·
        if(_MountainCardNum == 0 && _MountainCard.activeSelf)
        {
            _MountainCard.SetActive(false);
        }
        //ŽRŽD‚Ì–‡”‚ª0‚Å‚Í‚È‚­AŽRŽD‚ª•\Ž¦‚³‚ê‚Ä‚¢‚È‚¢ŽžAŽRŽD‚ð•\Ž¦‚·‚é
        else if(_MountainCardNum != 0 && !_MountainCard.activeSelf)
        {
            _MountainCard.SetActive(true);
        }
    }

    //ŽÌ‚ÄŽD•\Ž¦‚Ì§Œä
    void GabageZoneCtrl()
    {
        //ŽÌ‚ÄŽD‚ª0‚ÅŽÌ‚ÄŽD‚ª•\Ž¦‚³‚ê‚Ä‚¢‚éŽžAŽÌ‚ÄŽD‚Ì•\Ž¦‚ðÁ‚·
        if (_GabageCardNum == 0 && _GabageCard.activeSelf)
        {
            _GabageCard.SetActive(false);
        }
        //ŽÌ‚ÄŽD‚ª0‚Å‚Í‚È‚­AŽÌ‚ÄŽD‚ª•\Ž¦‚³‚ê‚Ä‚¢‚È‚¢ŽžAŽÌ‚ÄŽD‚ð•\Ž¦‚·‚é
        else if (_GabageCardNum != 0 && !_GabageCard.activeSelf)
        {
            _GabageCard.SetActive(true);
        }
    }

    //—vC³
    //ƒJ[ƒh‚Ìƒhƒ[
    public void Draw()
    {
        //ŽRŽD‚ª0–‡‚Å‚Í‚È‚¢A‚à‚µ‚­‚ÍŽèŽD‚ª‚R–‡‚Å‚È‚¢‚Æ‚«ƒhƒ[‚Å‚«‚é
        if(_MountainCardNum > 0 || _HandCardNum <3)
        {
            _MountainCardNum -= 3;
            _HandCardNum += 3;
            Debug.Log("ŽRŽD:"+ _MountainCardNum);
            Debug.Log("ŽèŽD:" + _HandCardNum);
        }
        else
        {
            Debug.Log("ŽRŽD‚ª‚È‚¢‚©ŽèŽD‚ª‚¢‚Á‚Ï‚¢‚¾‚æ");
        }
    }

    //—vC³
    //ƒJ[ƒh‚ðŽÌ‚Ä‚é
    public void ThrowCard()
    {
        //ŽèŽD‚ª0o‚È‚¢Žž‚ÉŽÀs‰Â”\
        if(_HandCardNum >0)
        {
            _HandCardNum -= 3;
            _GabageCardNum += 3;
            Debug.Log("ŽÌ‚ÄŽD:" + _GabageCardNum);
            Debug.Log("ŽèŽD:" + _HandCardNum);
        }
        else
        {
            Debug.Log("ŽèŽD‚ª‚È‚¢‚æ");
        }
    }

}
