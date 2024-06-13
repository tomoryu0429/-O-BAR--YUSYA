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

    /// 項目をランダムに一つ取得
    public static T GetRandom<T>() where T : struct
    {
        int no = UnityEngine.Random.Range(0, GetTypeNum<T>());
        return NoToType<T>(no);
    }

    /// 全ての項目が入ったListを取得
    public static List<T> GetAllInList<T>() where T : struct
    {
        var list = new List<T>();
        foreach (T t in Enum.GetValues(typeof(T)))
        {
            list.Add(t);
        }
        return list;
    }

    /// 入力された文字列と同じ項目を取得
    public static T KeyToType<T>(string targetKey) where T : struct
    {
        return (T)Enum.Parse(typeof(T), targetKey);
    }

    /// 入力された番号の項目を取得
    public static T NoToType<T>(int targetNo) where T : struct
    {
        return (T)Enum.ToObject(typeof(T), targetNo);
    }

    /// 入力された文字列の項目が含まれているか
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

    /// 全ての項目に対してデリゲートを実行
    public static void ExcuteActionInAllValue<T>(Action<T> action) where T : struct
    {
        foreach (T t in Enum.GetValues(typeof(T)))
        {
            action(t);
        }
    }

}
