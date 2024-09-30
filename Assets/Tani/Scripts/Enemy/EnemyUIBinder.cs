using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using R3.Triggers;
using UnityEngine.Events;

public class EnemyUIBinder : MonoBehaviour
{
    [SerializeField] Image _fillImage;
    [SerializeField] EnemyBase _enemyData;
    [SerializeField] ObservableEventTrigger observableEventTrigger;


    [HideInInspector] public UnityEvent<EnemyBase> OnClickEvent;
    [HideInInspector] public UnityEvent<EnemyBase> OnEnemyDieEvent;
    
    private void Start()
    {
        _enemyData.Status.Health
            .Observable
            .Subscribe(health =>
        {
            _fillImage.fillAmount = (float)health.Value / (float)health.Max;
        }).AddTo(this);


        _enemyData.Status
            .DieAsObservable
            .Subscribe(_ =>
            {
                print($"{gameObject.name}‚ð“|‚µ‚½");
                gameObject.SetActive(false) ;
            }).AddTo(this);


        observableEventTrigger
            .OnPointerClickAsObservable()
            .Where(_=>_enemyData.Status.Health.Value != 0)
            .Subscribe(_ =>
            {
                OnClickEvent.Invoke(_enemyData);
            }).AddTo(this);


        observableEventTrigger
            .OnDisableAsObservable()
            .Subscribe(_ =>
            {
                OnEnemyDieEvent.Invoke(_enemyData);
            }).AddTo(this);
    }


}
