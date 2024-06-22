using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonExtension
{
    [RequireComponent(typeof(Button))]
    public class ButtonEx_CreatePile : ButtonExtension.ButtonEx_CreatePrefab
    {
        [SerializeField]
        EPileType type;
        protected override void Awake()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                createdObject = Instantiate<GameObject>(PrefabManager.Instance.GetPrefabData(key));
                Tani.CardInstantContainerView inst = createdObject.GetComponentInChildren<Tani.CardInstantContainerView>();
                switch (type)
                {
                    case EPileType.Invalid:
                        break;
                    case EPileType.Hand:
                        
                        break;
                    case EPileType.Draw:
                        inst.Init(PlayerData.Instance.CardManager.Draw.GetAllCards);
                        break;
                    case EPileType.Discard:
                        inst.Init(PlayerData.Instance.CardManager.Discard.GetAllCards);
                        break;
                }


            });

            

        }
    }
}

public enum EPileType
{
    Invalid = -1,Hand,Draw,Discard
}