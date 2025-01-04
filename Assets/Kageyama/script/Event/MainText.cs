using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using R3.Triggers;
using R3;


public class MainText : MonoBehaviour
{
    public string talk;//à–¾•¶
    public TextMeshProUGUI textLabel;//à–¾•¶
    [SerializeField] Sentaku SentakuM;
    [SerializeField] EventManager EM;
    [SerializeField] bool Mati = false;//‘Ò‚¿ŠÔ
    [SerializeField] bool Paragraph = false;//Ÿ‚Ì’i—‚Ö
    [SerializeField] bool NextFlag = false;//Œˆ’èŒãŸ‚És‚Á‚Ä‚à‚æ‚¢‚©
    public int Count;//‰½s–Ú‚©
    // Start is called before the first frame update
    void Start()
    {
        SentakuM = FindAnyObjectByType<Sentaku>();
        EM = FindAnyObjectByType<EventManager>();
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        foreach (var word in talk)
        {
            textLabel.text = textLabel.text + word;
            yield return new WaitForSeconds(0.2f);
        }
        Mati = true;

    }

}
