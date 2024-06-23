using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using R3.Triggers;
using Alchemy.Inspector;
namespace Tani
{
    public class CardView : NormalImage
    {
        [field: SerializeField]
        ObservableEventTrigger ObservableEvent;

        [SerializeField]
        [AssetsOnly]
        GameObject DiscriptionPrefab;


        GameObject discriptionInstance = null;
        public void Init(CardManager.EPileType type,CardData cardData,PlayerData data)
        {
            

            this.ObservableEvent
                .OnPointerEnterAsObservable()
                .Subscribe(_ =>
                {
                    //tooltip�����݂���Ƃ���return
                    if (discriptionInstance != null) return;

                    //�J�[�h���g��
                    transform.localScale = new Vector3(1.2f, 1.2f, 0);

                    //tooltip���쐬
                    var go = Instantiate<GameObject>(DiscriptionPrefab, transform);
                    discriptionInstance = go;
                    go.transform.localPosition = new Vector3(0, 150, 0);

                    //tooltip�̃e�L�X�g��ݒ�
                    var tmp = go.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                    //�����̃J�[�h�ɑΉ�����CardData�̏��̎擾���K�v
                    tmp.text = cardData.CardName;
                }).AddTo(this);

            this.ObservableEvent
                .OnPointerExitAsObservable()
                .Subscribe(_ =>
                {
                    Reset();
                }).AddTo(this);

            this.ObservableEvent
                .OnPointerClickAsObservable()
                .Subscribe(_ =>
                {
             
                    if(type == CardManager.EPileType.Hand)
                    {
                        data.CardManager.containers[(int)CardManager.EPileType.Hand].UseCard(transform.GetSiblingIndex());
                    }
                }).AddTo(this);

        }
        private void Reset()
        {
            transform.localScale = Vector3.one;
            if (discriptionInstance)
            {
                Destroy(discriptionInstance);
            }
            discriptionInstance = null;
        }
    }
}

