using R3;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIControls
{
    public class CardUseMenu : MonoBehaviour
    {
        [SerializeField] private Image _cardSpriteImage;
        [SerializeField] private TextMeshProUGUI _cardNameText;
        [SerializeField] private TextMeshProUGUI _cardEffectLabels;
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _cancelButton;

        public Observable<(int index, AutoEnum.ECardID id)> OnCardUseSelected => _onCardUseSelected;

        private Subject<(int index, AutoEnum.ECardID id)> _onCardUseSelected = new();
        private (int index, AutoEnum.ECardID id) _currentDefinedInfo;
        
        private void Start()
        {

            _useButton.onClick.AsObservable()
                .Subscribe(_ =>
                {
                    gameObject.SetActive(false);
                    _onCardUseSelected.OnNext(_currentDefinedInfo);
                }
                ).AddTo(this);

            _cancelButton.onClick.AsObservable()
                .Subscribe(_ =>
                {
                    gameObject.SetActive(false);
                }
                ).AddTo(this);
        }

        public void DefineCardInfo(int index, AutoEnum.ECardID id)
        {
            _currentDefinedInfo = (index,id);
            var data = CardSystem.Utility.GetCardData(id);
            _cardSpriteImage.sprite = data.CardSprite;
            _cardNameText.text = data.CardName;

            _cardEffectLabels.text = "";
            foreach(var effect in data.Effects)
            {
                _cardEffectLabels.text += effect.EffectLabel + "\n";
            }
        }
    }
}
