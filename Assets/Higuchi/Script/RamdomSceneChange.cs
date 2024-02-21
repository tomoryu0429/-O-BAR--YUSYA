using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//�Ƃ肠�����e�X�g�p�ɃX�y�[�X��������V�[���ڍs����悤�ɂ���

public class RamdomSceneChange : MonoBehaviour
{
    [SerializeField] Image _fadeimage;
    public string scene_candidates;
    public string scene_candidates2;

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        bool _random = Random.Range(0, 2) == 0;
        float fadeDuration = 1.5f;
        float timer = 0;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);

            if (_fadeimage != null)
                _fadeimage.color = new Color(0, 0, 0, alpha);
            else
                Debug.Log("�C���[�Wnull");

            timer += Time.deltaTime;
            yield return null;
        }

        if (_fadeimage != null)
            _fadeimage.enabled = false;
        else
            Debug.Log("�C���[�Wnull");

        if (_random)
            SceneManager.LoadScene(scene_candidates);

        else
            SceneManager.LoadScene(scene_candidates2);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("������܂����B�����_���ȃV�[���Ɉڍs���܂��B");
            StartCoroutine(ChangeScene());
        }
    }
}
