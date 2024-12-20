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
        /// Hp割合を0 - 1の範囲で指定
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

