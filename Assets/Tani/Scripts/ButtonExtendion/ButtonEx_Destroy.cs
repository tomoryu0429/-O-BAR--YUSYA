using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ButtonExtension
{
    [RequireComponent(typeof(Button))]
    public class ButtonEx_Destroy : MonoBehaviour
    {
        [SerializeField]
        GameObject destroy_target;
        private void Awake()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(() => Destroy(destroy_target));
        }
    }
}
