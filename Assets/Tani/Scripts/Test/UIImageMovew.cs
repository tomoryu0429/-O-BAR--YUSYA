using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIImageMovew : MonoBehaviour
{
    [SerializeField] RectTransform parent;

    [SerializeField] float speed = 1;

    [SerializeField] Text text1;
    [SerializeField] Text text2;
    [SerializeField] Text text3;
    [SerializeField] Text text4;
    [SerializeField] Text text5;



    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) { transform.Translate(0, speed * Time.deltaTime, 0); }
        if (Input.GetKey(KeyCode.DownArrow)) { transform.Translate(0, -speed * Time.deltaTime, 0); }
        if (Input.GetKey(KeyCode.RightArrow)) { transform.Translate(speed * Time.deltaTime, 0,  0); }
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }

        text1.text = $"World = {transform.position}";
        text2.text = $"Local = {transform.localPosition}";
        text3.text = $"mouse Position = {Input.mousePosition}";
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, Input.mousePosition, null, out Vector2 localPos);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parent, Input.mousePosition, null, out Vector3 Pos);

        text4.text = $"Mouse Position Converted Local = {localPos}";
        text5.text = $"Mouse Position Converted World = {Pos}";




    }
}
