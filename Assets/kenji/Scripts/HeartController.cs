using System;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;


public class HartController : MonoBehaviour
{
    /// <summary>ライフを回復（減少）させる値</summary>
    [SerializeField] int _recoverLife = 10;
    [Tooltip("ライフの初期値")]
    [SerializeField] int _charaLife = 500;    // Start is called before the first frame update
    [Tooltip("ライフを表示するための Text (UI)")]
    [SerializeField] Text _lifeText = null;
    [Tooltip("ゲージを変化させる秒数 Text (UI)")]
    /// <summary>ゲージを変化させる秒数</summary>
    [SerializeField] float _changeValueInterval = 0.5f;
    Slider _slider = default;

    /// <summary>ライフの現在値</summary>
    int _life;
    /// <summary>ライフを表示するための GameObject</summary>
    GameObject _lifeObject = null;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<UnityEngine.UI.Slider>();
    }
    /// <summary>
    /// ゲージを減らす
    /// </summary>
    /// <param name="value">増減させる量（割合）</param>
    public void Change(float value)
    {
        ChangeValue(_slider.value + value);
    }
    /// <summary>
    /// ゲージを満タンにする
    /// </summary>
    public void Fill()
    {
        ChangeValue(1f);
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeValue(float v)
    {
        throw new NotImplementedException();
    }


}
