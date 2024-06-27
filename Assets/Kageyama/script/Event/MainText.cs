using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainText : MonoBehaviour
{
    public string talk;//������
    public TextMeshProUGUI textLabel;//������
    [SerializeField] Sentaku SentakuM;
    [SerializeField] EventManager EM;
    [SerializeField] bool Mati = false;//�҂�����
    [SerializeField] bool Paragraph = false;//���̒i����
    [SerializeField] bool NextFlag = false;//����㎟�ɍs���Ă��悢��
    public int Count;//���s�ڂ�
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
        //�s��ǂݏI����ĂȂ��Ƃ��Ɏ��̍s��ǂ܂Ȃ����߂̂���
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
            textLabel.text = "";//������
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
                yield return new WaitForSeconds(0.2f);//null ���̃t���[���҂�
            }
            Mati = true;

    }

}
