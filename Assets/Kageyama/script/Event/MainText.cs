using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using R3.Triggers;
using R3;

<<<<<<< HEAD
public class MainText : MonoBehaviour
{
    public string talk;//������
    public TextMeshProUGUI textLabel;//������
=======
//public class MainText : MonoBehaviour
//{
//    public string talk;//������
//    public TextMeshProUGUI textLabel;//������
//    [SerializeField] Sentaku SentakuM;
//    [SerializeField] EventManager EM;
//    [SerializeField] bool Mati = false;//�҂�����
//    [SerializeField] bool Paragraph = false;//���̒i����
//    [SerializeField] bool NextFlag = false;//����㎟�ɍs���Ă��悢��
//    public int Count;//���s�ڂ�
//    // Start is called before the first frame update
//    void Start()
//    {
//        SentakuM = FindAnyObjectByType<Sentaku>();
//        EM = FindAnyObjectByType<EventManager>();
//        StartCoroutine(Dialogue());
//    }
>>>>>>> 1a8189b090cc11dbde180e1d9a04f336057a7578

    [SerializeField] bool Mati = false;//�҂�����
    [SerializeField] bool Paragraph = false;//���̒i����
    [SerializeField] bool nextFlag = false;//����㎟�ɍs���Ă��悢��

<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dialogue());

    }
=======
//        }
//        if (Paragraph && Mati && Count != 12)
//        {
//            textLabel.text = "";//������
//            Paragraph = false;
//            Mati = false;
//            Count++;
//            Debug.Log(Count);
//            for (int i = 0; i > 4; i++)
//            {
//                SentakuM.GetComponent<Sentaku>().Kettei[i] = false;
//            }
//        }
//    }

//    IEnumerator Dialogue()
//    {
//        foreach (var word in talk)
//        {
//            textLabel.text = textLabel.text + word;
//            yield return new WaitForSeconds(0.2f);//null ���̃t���[���҂�
//        }
//        Mati = true;
<<<<<<< HEAD
>>>>>>> 1a8189b090cc11dbde180e1d9a04f336057a7578
=======
>>>>>>> 1a8189b090cc11dbde180e1d9a04f336057a7578

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
