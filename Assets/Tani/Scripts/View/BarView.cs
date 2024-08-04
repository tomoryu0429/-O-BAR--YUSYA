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
        /// HpŠ„‡‚ğ0 - 1‚Ì”ÍˆÍ‚Åw’è
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

