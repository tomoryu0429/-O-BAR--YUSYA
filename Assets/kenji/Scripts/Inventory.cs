using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Inventory�i�������j�𑀍삷��R���|�[�l���g
/// </summary>
public class InventoryTest : MonoBehaviour
{
    /// <summary>�������̃f�[�^�BKey: Gear ID, Value: �����Ă��鐔</summary>
    Dictionary<int, int> _inventory = new Dictionary<int, int>();
    /// <summary>�������E�C���h�E�̃��[�g</summary>
    [SerializeField] Transform _inventoryWindow = default;
    /// <summary>�������f�[�^��\������v���n�u</summary>
    [SerializeField] GearDataEntryController _inventoryDataEntryPrefab = default;

    void Start()
    {
        // �i�_�~�[�́j�������f�[�^�����
        _inventory.Add(1, 3);
        _inventory.Add(3, 2);
        _inventory.Add(4, 1);
        _inventory.Add(5, 4);
    }

    /// <summary>
    /// �\�����X�V����
    /// </summary>
    public void RefreshInventoryUI()
    {
        // �\����S�폜����
        foreach (Transform t in _inventoryWindow)   // �����̑S�Ă̎q�I�u�W�F�N�g�����[�v���������͂��̂悤�Ȏw����@������
        {
            Destroy(t.gameObject);
        }

        // �������f�[�^����\�������
        foreach (var k in _inventory.Keys)
        {
            var gearDataEntry = Instantiate(_inventoryDataEntryPrefab, _inventoryWindow);
            gearDataEntry.ItemName = DataLoader.GetGear(k).Name;
            gearDataEntry.ItemCount = _inventory[k];
        }
    }

    /// <summary>
    /// �A�C�e������������B
    /// �������̒����烉���_���ɂQ�̃A�C�e����I��ō�������B
    /// </summary>
    public void Fusion()
    {
        if (_inventory.Values.Sum() < 2)
        {
            Debug.Log("�����ł��鑕��������܂���");
            return;
        }

        // ��������A�C�e���������_���ɑI��
        int id1 = _inventory.Keys.ToArray()[Random.Range(0, _inventory.Keys.Count)];
        Remove(id1);    // ���������猸�炷
        int id2 = _inventory.Keys.ToArray()[Random.Range(0, _inventory.Keys.Count)];
        Remove(id2);    // ���������猸�炷
        Gear gear1 = DataLoader.GetGear(id1);
        Gear gear2 = DataLoader.GetGear(id2);
        // �A�C�e�����������Ď������ɒǉ�����
        Gear newGear = gear1 + gear2;   // �����Z�ō������邱�Ƃ��ł���
        Add(newGear.Id);
        // ���b�Z�[�W���o���� UI ���X�V����
        string message = $"{gear1.Name} �� {gear2.Name} ���������� {newGear.Name} ���ł��܂����B";
        Debug.Log(message);
        RefreshInventoryUI();
    }

    /// <summary>
    /// ����������A�C�e��������炷
    /// </summary>
    /// <param name="id">���炷�A�C�e���� ID</param>
    void Remove(int id)
    {
        if (_inventory[id] > 1)
        {
            _inventory[id]--;
        }
        else
        {
            _inventory.Remove(id);
        }
    }

    /// <summary>
    /// �������ɃA�C�e������ǉ�����
    /// </summary>
    /// <param name="id">�ǉ�����A�C�e���� ID</param>
    void Add(int id)
    {
        if (_inventory.ContainsKey(id))
        {
            _inventory[id]++;
        }
        else
        {
            _inventory.Add(id, 1);
        }
    }
}
