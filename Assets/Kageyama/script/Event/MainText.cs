using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainText : MonoBehaviour
{
    public string talk;//説明文
    public TextMeshProUGUI textLabel;//説明文
    [SerializeField] Sentaku SentakuM;
    [SerializeField] EventManager EM;
    [SerializeField] bool Mati = false;//待ち時間
    [SerializeField] bool Paragraph = false;//次の段落へ
    [SerializeField] bool NextFlag = false;//決定後次に行ってもよいか
    public int Count;//何行目か
    // Start is called before the first frame update
    void Start()
    {
        SentakuM = FindAnyObjectByType<Sentaku>();
        EM = FindAnyObjectByType<EventManager>();
            StartCoroutine(Dialogue());
    }

    // Update is called once per frame
    void Update()
    {
        //行を読み終わってないときに次の行を読まないためのもの
        if (Input.GetKeyDown(KeyCode.Space) && Mati)
        {
            Paragraph = true;
        }
        for (int i = 0; i > 4; i++)
        {
            if (SentakuM.GetComponent<Sentaku>().Kettei[i])
            {
                NextFlag = true;
            }

        }
        if (Paragraph && Mati && Count != 12)
        {
            textLabel.text = "";//初期化
            Paragraph = false;
            Mati = false;
            Count++;
            Debug.Log(Count);
            for(int i = 0; i > 4; i++)
            {
                SentakuM.GetComponent<Sentaku>().Kettei[i] = false;
            }
        }
    }

    IEnumerator Dialogue()
    {
            foreach(var word in talk)
            {
                textLabel.text = textLabel.text + word;
                yield return new WaitForSeconds(0.2f);//null 次のフレーム待つ
            }
            Mati = true;

    }

}
