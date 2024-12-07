//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class Sentaku : MonoBehaviour
//{
//    public List<bool> Kettei = new List<bool>() { false, false, false, false };
//    [SerializeField] MainText MainT;
//    [SerializeField] EventManager EM;
//    // Start is called before the first frame update
//    void Start()
//    {
//        MainT = FindAnyObjectByType<MainText>();
//        EM = FindAnyObjectByType<EventManager>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Decision();
//    }

//    void Decision()
//    {
//        //1‚Â–Ú‚ÌŒˆ’è
//        if (MainT.GetComponent<MainText>().Count == 12 && Input.GetKeyDown(KeyCode.Alpha1))
//        {
//            Kettei[0] = true;
//        }
//        //2‚Â–Ú‚ÌŒˆ’è
//        if (MainT.GetComponent<MainText>().Count == 12 && Input.GetKeyDown(KeyCode.Alpha2))
//        {
//            Kettei[1] = true;
//        }
//        //3‚Â–Ú‚ÌŒˆ’è
//        if (MainT.GetComponent<MainText>().Count == 12 && Input.GetKeyDown(KeyCode.Alpha3))
//        {
//            Kettei[2] = true;
//        }
//        //4‚Â–Ú‚ÌŒˆ’è
//        if (MainT.GetComponent<MainText>().Count == 12 && Input.GetKeyDown(KeyCode.Alpha4))
//        {
//            Kettei[3] = true;
//        }
//    }


//}
