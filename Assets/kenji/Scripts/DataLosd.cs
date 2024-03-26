using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;

/// <summary>
/// �A�C�e���f�[�^�𑀍삷��R���|�[�l���g
/// �}�X�^�[�f�[�^�̓ǂݍ��݁AID �����ɂ����f�[�^�i�N���X�j�̎擾�A���ł���
/// </summary>
public class DataLoader : MonoBehaviour
{
    /// <summary>�ǂݍ��񂾃A�C�e���̃f�[�^</summary>
    static List<Gear> _gearData = new List<Gear>();
    [SerializeField] TextAsset _gearDataCsv = default;

    /// <summary>
    /// �A�C�e���f�[�^�i�}�X�^�[�f�[�^�j�̃��X�g
    /// </summary>
    public static List<Gear> GearData => _gearData; // �ǂݎ���p�v���p�e�B�����̂悤�Ƀ����_���Œ�`�ł���

    /// <summary>
    /// �w�肵�� CSV �t�@�C������A�C�e���f�[�^��ǂݍ���
    /// </summary>
    public void LoadGearData()
    {
        _gearData.Clear();  // ���݂̃f�[�^���N���A����
        Debug.Log("�A�C�e���f�[�^�ǂݍ��݊J�n");
        StringReader sr = new StringReader(_gearDataCsv.text);
        sr.ReadLine();  // �擪�s�̓w�b�_�Ȃ̂ŃX�L�b�v����

        // ��s���ǂݍ���ŃC���X�^���X�����X�g�ɒǉ�����
        while (sr.Peek() != -1)
        {
            string line = sr.ReadLine();
            var d = line.Split(',');
            Gear gear = new Gear(int.Parse(d[0]), d[1], int.Parse(d[2]), int.Parse(d[3]), int.Parse(d[4]));
            _gearData.Add(gear);
        }

        Debug.Log("�A�C�e���f�[�^�ǂݍ��݊���");
    }

    /// <summary>
    /// �A�C�e���f�[�^���\�[�g���AConsole �Ƀ\�[�g�O��̏����o�͂���
    /// �\�[�g���� Gear �\���̂ɒ�`����Ă���
    /// </summary>
    public void SortGearData()
    {
        StringBuilder sb = new StringBuilder(); // �������������鎞�Ɏg���N���X
        sb.AppendLine("=== �\�[�g�O ===");

        foreach (var i in _gearData)
        {
            sb.AppendLine(i.ToString());
        }

        _gearData.Sort();   // Gear �^�� IComparable �ɂ�菇�Ԃ���`����Ă���̂ŁASort() ���ĂԂ����Ń\�[�g�ł���i�j��I���\�b�h�j
        // �ȉ��̂悤�Ƀ\�[�g�����Ă��\��Ȃ��B�������e�t�B�[���h�Ń\�[�g�����������́A�ȉ��̂悤�ȏ������K�v�ɂȂ�i��j�󃁃\�b�h�j
        // _gearData = _gearData.OrderBy(g => g.Id).ToList();
        sb.AppendLine("=== �\�[�g�� ===");

        foreach (var i in _gearData)
        {
            sb.AppendLine(i.ToString());
        }

        Debug.Log(sb.ToString());
    }

    /// <summary>
    /// ID ���w�肵�ăA�C�e���f�[�^���擾����
    /// </summary>
    /// <param name="id">�擾�������A�C�e���� ID</param>
    /// <returns>�A�C�e���f�[�^�̃C���X�^���X</returns>
    public static Gear GetGear(int id)
    {
        return DataLoader.GearData.Where(item => item.Id == id).FirstOrDefault();
    }
}
