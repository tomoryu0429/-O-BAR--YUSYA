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
    [field:SerializeField]public EnemyBase Enemy { get; private set; }
    [SerializeField] ObservableEventTrigger observableEventTrigger;


    [HideInInspector] public UnityEvent<EnemyBase> OnClickEvent;
    [HideInInspector] public UnityEvent<EnemyBase> OnEnemyDieEvent;

    private void Start()
    {
        Enemy.Status.Health
            .Observable
            .Subscribe(health =>
        {
            _fillImage.fillAmount = (float)health.Value / (float)health.Max;
        }).AddTo(this);


        Enemy.Status
            .Health
            .Observable
            .Where(h => h.Value == 0)
            .Subscribe(_ =>
            {
                print($"{gameObject.name}‚ð“|‚µ‚½");
                gameObject.SetActive(false);
            }).AddTo(this);


        observableEventTrigger
            .OnPointerClickAsObservable()
            .Where(_ => Enemy.Status.Health.Value != 0)
            .Subscribe(_ =>
            {
                OnClickEvent.Invoke(Enemy);
            }).AddTo(this);

    }
}
