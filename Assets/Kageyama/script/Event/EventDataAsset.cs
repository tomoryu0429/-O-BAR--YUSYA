using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Scriptable/EventDataAsset")]
public class EventDataAsset : ScriptableObject
{
    public List<EventData> eventdataList = new List<EventData>();
}

[System.Serializable]
public class EventData
{
    [SerializeField] string eventname;
    [SerializeField] string maintext;
    [SerializeField] string selectA;
    [SerializeField] string selectB;
    [SerializeField] string selectC;
    [SerializeField] string effectA;
    [SerializeField] string effectB;
    [SerializeField] string effectC;

    public string EventName => eventname;
    public string MainText => maintext;
    public string SelectA => selectA;
    public string SelectB => selectB;
    public string SelectC => selectC;
    public string EffectA => effectA;
    public string EffectB => effectB;
    public string EffectC => effectC;
}