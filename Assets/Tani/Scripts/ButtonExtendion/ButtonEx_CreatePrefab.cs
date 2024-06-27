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
        protected PrefabManager.PrefabKey key;

        protected GameObject createdObject;
        protected virtual void Awake()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(() => createdObject=  Instantiate<GameObject>(PrefabManager.Instance.GetPrefabData(key)));
        }
    }
}
