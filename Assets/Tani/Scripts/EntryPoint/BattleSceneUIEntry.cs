using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Tani
{
    public class BattleSceneUIEntry : MonoBehaviour
    {
        [SerializeField]
        GameObject HpBar;
        
        [SerializeField]
        GameObject DebugButton;
        



        private void Awake()
        {
            Instantiate(HpBar, this.transform);
            Instantiate(PrefabManager.Instance.GetPrefabData(PrefabManager.PrefabKey.HandContainerView), this.transform);


            GameObject DrawPileButton = Instantiate<GameObject>(DebugButton, this.transform);
            DrawPileButton.name = "DrawPileButton";
            GameObject DiscardPileButton = Instantiate<GameObject>(DebugButton, this.transform);
            DiscardPileButton.name = "DiscardPileButton";


            DrawPileButton.GetComponent<Button>().onClick.AddListener(
                () => PrefabManager.Instance
                .GetPrefabInstance(PrefabManager.PrefabKey.DrawContainerView)
                .SetActive(true)
                );
            DrawPileButton.GetComponentInChildren<TextMeshProUGUI>().text = "ŽRŽD";


            DiscardPileButton.GetComponent<Button>().onClick.AddListener(
                () => PrefabManager.Instance
                .GetPrefabInstance(PrefabManager.PrefabKey.DiscardContainerView)
                .SetActive(true)
                );
            DiscardPileButton.GetComponentInChildren<TextMeshProUGUI>().text = "ŽÌ‚ÄŽD";

        }
    }
}

