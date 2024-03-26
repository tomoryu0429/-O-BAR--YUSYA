using System;
using System.Linq;

/// <summary>
/// �A�C�e���i�����j�f�[�^���i�[����\����
/// ID ���Ń\�[�g����B�܂� ID �̒l���傫�������u�傫���A�C�e���v�Ƃ݂Ȃ����B
/// �A�C�e���ƃA�C�e���̘a (+) �͍������ꂽ�A�C�e���ƂȂ�A�����_���ȃA�C�e���ƂȂ�B
/// </summary>
public struct Gear : IComparable<Gear>  // Gear �ƁA�܂蓯���\���̂̒l�Ƃ̑召�֌W���`���邽�߂� IComparable<Gear> ���p������
{
    /// <summary>�A�C�e���� ID</summary>
    public int Id;
    /// <summary>�A�C�e���̖��O</summary>
    public string Name;
    /// <summary>�A�C�e���̒l�i</summary>
    public int Price;
    /// <summary>�U����</summary>
    public int Attack;
    /// <summary>�h���</summary>
    public int Defence;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public Gear(int id, string name, int price, int attack, int defence)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.Attack = attack;
        this.Defence = defence;
    }

    /// <summary>
    /// ID ���Ƃ��ă\�[�g����悤�ɒ�`����
    /// </summary>
    /// <param name="other">�\�[�g�����r���鑊��</param>
    /// <returns>�����̕������������� -1, �����̕����傫������ 1, ���l�̎��� 0</returns>
    public int CompareTo(Gear other)
    {
        return this.Id.CompareTo(other.Id);
        //if (this.Id < other.Id)
        //{
        //    return -1;  // ������ ID �����������́u�����̕����O�v�Ƃ���
        //}
        //else if (this.Id > other.Id)
        //{
        //    return 1;  // ������ ID ���傫�����́u�����̕������v�Ƃ���
        //}
        //else
        //{
        //    return 0;   // ID �������Ȃ�u�����v�Ƃ���
        //}
    }

    // ���ɂ��āA�p������C���^�[�t�F�C�X�� IComparable<T> �ł͂Ȃ� IComparable �Ƃ��鎖���ł���B

    //Gear _gaerdata  = 
    //_gearData = _gameData.OrderByDescendinhg  (g => g.Price).ToList();
    //// ���̏ꍇ�A�������郁�\�b�h�͈����� T �ł͂Ȃ� object �^�i���ׂĂ̊���N���X�j�ƂȂ�A�ȉ��̂悤�ɒ�`����B
    // object �^�Ƃ������Ƃ́u���Ƃł���r�ł���v���ƂɂȂ邪�A����̏ꍇ�iID �Ŕ�r����j�ꍇ�͈ȉ��̂悤�ɃL���X�g���邱�ƂɂȂ�B
    /*
    public int CompareTo(object o)
    {
        Gear other = (Gear) o;

        if (this.Id < other.Id)
        {
            return -1;
        }
        else if (this.Id > other.Id)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    */

    /// <summary>
    /// ������f�[�^�ɕϊ�����
    /// </summary>
    /// <returns>������</returns>
    public override string ToString()
    {
        return $"Id: {this.Id}, Name: {this.Name}, Price: {this.Price}, Attack: {this.Attack}, Defence: {this.Defence}";
    }

    /// <summary>
    /// Gear �̑����Z���`����B
    /// Gear �� Gear �𑫂����ꍇ�A�u�����v�Ƃ��ă����_���� Gear ��Ԃ��B
    /// </summary>
    /// <param name="g1">�������� Gear</param>
    /// <param name="g2">�������� Gear</param>
    /// <returns>�������ꂽ Gear</returns>
    public static Gear operator +(Gear g1, Gear g2)
    {
        int maxId = DataLoader.GearData.Max(item => item.Id);
        int id = UnityEngine.Random.Range(1, maxId + 1);
        Gear newGear = DataLoader.GearData.Where(item => item.Id == id).FirstOrDefault();
        return newGear;
    }
    // public Gear Fugion(Gear other);
}

