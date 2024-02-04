using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHpBar : MonoBehaviour
{
    
    Image image;
    T_Enemy t_Enemy;
    public GameObject enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        t_Enemy = enemy.GetComponent<T_Enemy>();
        if (t_Enemy == null)
        {
            Debug.LogWarning("コンポーネントを取得出来ていません");
        }
        image = GetComponent<Image>();
        image.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = (float)t_Enemy.Hp / (float)t_Enemy.maxHp;
    }
}
