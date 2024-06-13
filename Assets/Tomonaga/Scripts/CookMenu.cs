using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using old;

public class CookMenu : MonoBehaviour
{
    public GameObject Brind;            //選択できないメニューを押せないようにするブラインド
    public FoodKinds thisFood;          //このメニューが担当する料理の種類

    public int MaterialNum ;            //材料の数（インスペクタービューで設定）

    bool[] ishavingMaterial = new bool[3] { false, false, false };  //既に持っている材料の状態
    
    public FoodKinds[] MaterialFood = new FoodKinds[3];             //材料の食材

    public CardManager cardManager;                                 //カードマネージャー（スクリプト）
 

    // Start is called before the first frame update
    void Start()
    {
       
        resetishavingMaterial();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ブラインドの設定
    public void setBrindState()
    {
        //材料を持っているかどうかのリセット
        resetishavingMaterial();

        //現在の手札の食材の種類を取得
        List<FoodKinds> foodKinds = cardManager.getNowHandCardFoodKinds();

        //取得した種類と調理のために必要な材料の種類が符合するかの確認
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
        //符合していない場合はブラインドを付ける
        Brind.SetActive(!isAllhavingTrue());
    }

    //材料を持っているかどうかのリセット
    void resetishavingMaterial()
    {
        for (int i = 0; i < MaterialNum; i++)
        {
            ishavingMaterial[i] = false; // 初期値をfalseで追加
        }
    }

    //全ての材料を持っている場合、Trueを返す
    bool isAllhavingTrue()
    {
        for (int i = 0; i < MaterialNum;i++)
        {
            if (ishavingMaterial[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    //調理の処理
    public void CookFunc()
    {
        //材料の食材を捨てる
        for (int i = 0; i < MaterialNum; i++)
        {
            cardManager.WhenCookedCardThrow(MaterialFood[i]);
        }

        //このメニューの料理の番号から
        int foodNum = (int)thisFood;

        //新しく調理を行う
        cardManager.CreateNewCard(foodNum,CardState.Hand);
    }

}
