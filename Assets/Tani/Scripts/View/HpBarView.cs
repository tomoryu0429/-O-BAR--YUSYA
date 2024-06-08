using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tani
{
    public class HpBarView : MonoBehaviour
    {
        [SerializeField]
        Image hp_bar_green;

        /// <summary>
        /// Hp割合を0 - 1の範囲で指定
        /// </summary>
        /// <param name="value"></param>
        public void SetHpPercent(float value)
        {
            value = Mathf.Clamp01(value);
            hp_bar_green.fillAmount = value;
        }
    }
}

