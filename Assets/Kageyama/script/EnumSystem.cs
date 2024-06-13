using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices.WindowsRuntime;

public static class EnumSystem
{
    public static int GetTypeNum<T>() where T : struct
    {
        return Enum.GetValues(typeof(T)).Length;
    }

    /// ���ڂ������_���Ɉ�擾
    public static T GetRandom<T>() where T : struct
    {
        int no = UnityEngine.Random.Range(0, GetTypeNum<T>());
        return NoToType<T>(no);
    }

    /// �S�Ă̍��ڂ�������List���擾
    public static List<T> GetAllInList<T>() where T : struct
    {
        var list = new List<T>();
        foreach (T t in Enum.GetValues(typeof(T)))
        {
            list.Add(t);
        }
        return list;
    }

    /// ���͂��ꂽ������Ɠ������ڂ��擾
    public static T KeyToType<T>(string targetKey) where T : struct
    {
        return (T)Enum.Parse(typeof(T), targetKey);
    }

    /// ���͂��ꂽ�ԍ��̍��ڂ��擾
    public static T NoToType<T>(int targetNo) where T : struct
    {
        return (T)Enum.ToObject(typeof(T), targetNo);
    }

    /// ���͂��ꂽ������̍��ڂ��܂܂�Ă��邩
    public static bool ContainsKey<T>(string tagetKey) where T : struct
    {
        foreach (T t in Enum.GetValues(typeof(T)))
        {
            if (t.ToString() == tagetKey)
            {
                return true;
            }
        }

        return false;
    }

    /// �S�Ă̍��ڂɑ΂��ăf���Q�[�g�����s
    public static void ExcuteActionInAllValue<T>(Action<T> action) where T : struct
    {
        foreach (T t in Enum.GetValues(typeof(T)))
        {
            action(t);
        }
    }

}
