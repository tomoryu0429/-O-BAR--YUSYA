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
        return NoType<T>(no);
    }

    /// ���͂��ꂽ�ԍ��̍��ڂ��擾
    public static T NoType<T>(int target) where T : struct
    {
        return (T)Enum.ToObject(typeof(T), target);
    }

}
