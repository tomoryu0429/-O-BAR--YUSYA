using System;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;


public class HartController : MonoBehaviour
{
    /// <summary>���C�t���񕜁i�����j������l</summary>
    [SerializeField] int _recoverLife = 10;
    [Tooltip("���C�t�̏����l")]
    [SerializeField] int _charaLife = 500;    // Start is called before the first frame update
    [Tooltip("���C�t��\�����邽�߂� Text (UI)")]
    [SerializeField] Text _lifeText = null;
    [Tooltip("�Q�[�W��ω�������b�� Text (UI)")]
    /// <summary>�Q�[�W��ω�������b��</summary>
    [SerializeField] float _changeValueInterval = 0.5f;
    Slider _slider = default;

    /// <summary>���C�t�̌��ݒl</summary>
    int _life;
    /// <summary>���C�t��\�����邽�߂� GameObject</summary>
    GameObject _lifeObject = null;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<UnityEngine.UI.Slider>();
    }
    /// <summary>
    /// �Q�[�W�����炷
    /// </summary>
    /// <param name="value">����������ʁi�����j</param>
    public void Change(float value)
    {
        ChangeValue(_slider.value + value);
    }
    /// <summary>
    /// �Q�[�W�𖞃^���ɂ���
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
