using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using R3.Triggers;

namespace Tani
{
    public class BarView : MonoBehaviour
    {
        [SerializeField]
        Image fillableImage;


        /// <summary>
        /// Hp������0 - 1�͈̔͂Ŏw��
        /// </summary>
        /// <param name="value"></param>
        public void SetBarPercent(float value)
        {
            value = Mathf.Clamp01(value);
            fillableImage.fillAmount = value;
        }

        private void Start()
        {

        }
    }
}

