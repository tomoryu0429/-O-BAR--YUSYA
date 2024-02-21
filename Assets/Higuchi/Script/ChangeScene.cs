using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] Image _fadeimage;
    Button _button;
    public string scenename;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }
    void ButtonClick()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        float fadeDuration = 3.0f;
        float timer = 0;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);

            if (_fadeimage != null)
                _fadeimage.color = new Color(0, 0, 0, alpha);
            else
                Debug.Log("イメージnull");

            timer += Time.deltaTime;
            yield return null;
        }

        if (_fadeimage != null)
            _fadeimage.enabled = false;
        else
            Debug.Log("イメージnull");

        SceneManager.LoadScene(scenename);
    }
    void Update()
    {

    }
}
