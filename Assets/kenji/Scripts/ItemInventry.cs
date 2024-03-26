using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �A�C�e����\������X�N���v�g
/// </summary>
public class GearDataEntryController : MonoBehaviour
{
    /// <summary>�A�C�e������\�����邽�߂� Text</summary>
    [SerializeField] Text _itemName = default;
    /// <summary>�����Ă��鐔��\�����邽�߂� Text</summary>
    [SerializeField] Text _itemCount = default;

    /// <summary>
    /// �\������Ă���A�C�e����
    /// </summary>
    public string ItemName
    {
        // �ȉ��̂悤�Ƀ����_���Ńv���p�e�B���`���邱�Ƃ��ł���
        get => _itemName.text;
        set => _itemName.text = value;
    }

    /// <summary>
    /// �\������Ă��鏊����
    /// </summary>
    public int ItemCount
    {
        get
        {
            if (int.TryParse(_itemCount.text, out int itemCount))
            {
                return itemCount;
            }

            return 0;
        }

        set => _itemCount.text = value.ToString();
    }
}
