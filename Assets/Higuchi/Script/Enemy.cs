using UnityEngine;
[CreateAssetMenu(fileName = "newEnemy", menuName = "EnemyScriptableObject/Enemy")]
public class Enemy : ScriptableObject
{
    public string EnemyNeme; //“G‚Ì–¼‘O
    public int type; //“G‚Ìí—Ş
    public int ID; //“G‚ÌID
    public int health; //“G‚ÌHP
    public int power; //“G‚ÌUŒ‚—Í
    public int defense; //“G‚Ì–hŒä—Í
    public int money; //ƒhƒƒbƒv‚·‚é‚¨‹à
    public EnemyActionType[] actions; //“G‚Ìs“®
}
public enum EnemyActionType
{
    Attack, //UŒ‚
    Defence, //–hŒä
    increasedAttackPower, //UŒ‚—Íã¸
    demotivation, //‚â‚é‹CŒ¸­
}
