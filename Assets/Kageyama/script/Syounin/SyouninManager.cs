using R3;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SyouninManager : MonoBehaviour
{
    [SerializeField] GameObject BuyCanvas;
    [SerializeField] GameObject SellCanvas;
    [SerializeField] GameObject SelectCanvas;

    [SerializeField] Button selectbuy;
    [SerializeField] Button selectsell;

    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        BuyCanvas.SetActive(false);
        SellCanvas.SetActive(false);

        selectbuy.OnClickAsObservable()
                 .Subscribe(_ =>
                 {
                     BuyCanvas.SetActive(true);
                     SellCanvas.SetActive(false);
                 });

        selectsell.OnClickAsObservable()
                  .Subscribe(_ =>
                  {
                      BuyCanvas.SetActive(false);
                      SellCanvas.SetActive(true);
                  });
    }

}
