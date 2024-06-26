using UnityEngine;
[CreateAssetMenu(fileName = "newEnemy", menuName = "EnemyScriptableObject/Enemy")]
public class Enemy : ScriptableObject
{
    public string EnemyNeme; //GÌ¼O
    public int type; //GÌíÞ
    public int ID; //GÌID
    public int health; //GÌHP
    public int power; //GÌUÍ
    public int defense; //GÌhäÍ
    public int money; //hbv·é¨à
    public EnemyActionType[] actions; //GÌs®
}
public enum EnemyActionType
{
    Attack, //U
    Defence, //hä
    increasedAttackPower, //UÍã¸
    demotivation, //âéC¸­
}
