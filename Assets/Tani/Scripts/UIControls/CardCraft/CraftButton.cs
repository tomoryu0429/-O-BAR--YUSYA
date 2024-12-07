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
    public void Entry()
    {
        Button button = GetComponent<Button>();
        button.onClick.AsObservable()
            .Subscribe(_ =>
            {
                _area.PerformCraft();
                var craftId = _outputView.CraftCard();
                PlayerData.Instance.CardManager.HandCardContainer.Add(craftId);
                foreach(var removeId in CardSystem.Utility.GetCardData(craftId).Ingredients)
                {
                    PlayerData.Instance.CardManager.HandCardContainer.Remove(removeId);
                }
            }).AddTo(this);

        _area.IsCraftable.Subscribe(craftable => button.interactable = craftable).AddTo(this.gameObject);
    }
}
