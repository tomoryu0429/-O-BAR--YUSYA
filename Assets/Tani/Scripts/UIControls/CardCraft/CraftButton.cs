using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using R3.Triggers;
[RequireComponent(typeof(Button))]
public class CraftButton : MonoBehaviour
{
    [SerializeField] private CraftArea _area;
    [SerializeField] private CraftCardOutputView _outputView;
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AsObservable()
            .Subscribe(_ =>
            {
                _area.PerformCraft();
                PlayerData.Instance.CardManager.HandCardContainer.Add(_outputView.CraftCard());
            }).AddTo(this);

        _area.IsCraftable.Subscribe(craftable => button.interactable = craftable).AddTo(this.gameObject);
    }
}
