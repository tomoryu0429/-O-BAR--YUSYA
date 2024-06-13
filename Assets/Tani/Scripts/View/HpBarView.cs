using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using R3.Triggers;

namespace Tani
{
    public class HpBarView : MonoBehaviour
    {
        [SerializeField]
        Image hp_bar_green;


        /// <summary>
        /// HpŠ„‡‚ğ0 - 1‚Ì”ÍˆÍ‚Åw’è
        /// </summary>
        /// <param name="value"></param>
        public void SetHpPercent(float value)
        {
            value = Mathf.Clamp01(value);
            hp_bar_green.fillAmount = value;
        }

        private void Start()
        {

        }
    }
}

