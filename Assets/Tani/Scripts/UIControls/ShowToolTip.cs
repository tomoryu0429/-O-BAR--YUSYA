using R3.Triggers;
using System.Collections;
using System.Collections.Generic;
using Tani;
using UnityEngine;
using R3;

namespace UIControls
{
    public class ShowToolTip : MonoBehaviour,IVisibilityControllable
    {
        [SerializeField] CardView view;
        [SerializeField] ToolTip toolTip;
        [SerializeField] ObservableEventTrigger trigger;

        private void Start()
        {
            SetVisible(false);

            trigger.OnPointerEnterAsObservable()
                .Subscribe(_ =>
                {
                    SetVisible(true);
                    toolTip.SetText(CardSystem.Utility.GetCardData(view.ID).CardName);
                    view.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 0);
                    //view.gameObject.transform.localPosition = new Vector3(0, 30, 0);
                }).AddTo(this);

            trigger
               .OnPointerExitAsObservable()
               .Subscribe(_ =>
               {
                   SetVisible(false);
                   view.gameObject.transform.localScale = Vector3.one;
                   //view.gameObject.transform.localPosition = Vector3.zero;
               }).AddTo(this);
        }


        public void SetVisible(bool visibility)
        {
            toolTip.gameObject.SetActive(visibility);
            
        }

        public void SwitchVisibility()
        {
            SetVisible(toolTip.gameObject.activeSelf);
        }
    }
}

