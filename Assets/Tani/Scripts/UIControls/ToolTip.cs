using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UIControls
{
    public class ToolTip : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI textObj;

        public void SetText(string text)
        {
            textObj.text = text;
        }
    }
}
