using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMenu : MonoBehaviour
{
    public GameObject Brind;
    public FoodKinds thisFood;

    public int MaterialNum ;

    List<bool> ishavingMaterial = new List<bool>();
    
    public FoodKinds[] MaterialFood = new FoodKinds[3];

    public CardManager cardManager;
 

    // Start is called before the first frame update
    void Start()
    {
        resetishavingMaterial();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBrindState()
    {
        resetishavingMaterial();

        List<FoodKinds> foodKinds = cardManager.getNowHandCardFoodKinds();

        

        for(int i = 0; i < MaterialNum; i++)
        {
            for(int j = 0;j< foodKinds.Count; j++)
            {
                if (MaterialFood[i] == foodKinds[j])
                {
                    ishavingMaterial[i] = true;
                    break;
                }
            }
        }

        Brind.SetActive(!isAllhavingTrue());

    }

    void resetishavingMaterial()
    {
        for (int i = 0; i < MaterialNum; i++)
        {
            ishavingMaterial[i] = false; // ‰Šú’l‚ðfalse‚Å’Ç‰Á
        }
    }

    bool isAllhavingTrue()
    {
        for (int i = 0; i < MaterialNum;i++)
        {
            if (ishavingMaterial[i]== false)
            {
                return false;
            }
        }
        return true;
    }

}
