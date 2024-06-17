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

    /// €–Ú‚ğƒ‰ƒ“ƒ_ƒ€‚Éˆê‚Âæ“¾
    public static T GetRandom<T>() where T : struct
    {
        int no = UnityEngine.Random.Range(0, GetTypeNum<T>());
        return NoType<T>(no);
    }

    /// “ü—Í‚³‚ê‚½”Ô†‚Ì€–Ú‚ğæ“¾
    public static T NoType<T>(int target) where T : struct
    {
        return (T)Enum.ToObject(typeof(T), target);
    }

}
