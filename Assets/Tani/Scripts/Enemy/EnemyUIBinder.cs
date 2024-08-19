using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;

public class EnemyUIBinder : MonoBehaviour
{
    [SerializeField] Image _fillImage;
    [SerializeField] EnemyBase _enemyData;

    private void Start()
    {
        _enemyData.HealthObservable.Subscribe(health =>
        {
            _fillImage.fillAmount = (float)health / (float)_enemyData.HealthValueRange.maxHealth;
        }).AddTo(this);
    }
}
