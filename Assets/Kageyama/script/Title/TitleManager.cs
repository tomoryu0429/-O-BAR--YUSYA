using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] List<Button> loadSceneButton = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        /*
        //�v���C�@�퓬�V�[����
        loadSceneButton[0].OnClickAsObservable()
            .Subscribe(_ => SceneManager.LoadScene())
            .AddTo(this);
        
        //�N���W�b�g�@�N���W�b�g�V�[����
        loadSceneButton[1].OnClickAsObservable()
            .Subscribe(_ => SceneManager.LoadScene())
            .AddTo(this);
        */
    }

}
