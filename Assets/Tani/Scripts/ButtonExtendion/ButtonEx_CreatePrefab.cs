using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonExtension
{
    [RequireComponent(typeof(Button))]
    public class ButtonEx_CreatePrefab : MonoBehaviour
    {
        [SerializeField]
        PrefabManager.PrefabKey key;

        private void Awake()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(() => Instantiate(PrefabManager.Instance.GetPrefabData(key)));
        }
    }
}
