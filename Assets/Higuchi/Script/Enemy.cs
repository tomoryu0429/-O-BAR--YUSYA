using UnityEngine;
[CreateAssetMenu(fileName = "newEnemy", menuName = "EnemyScriptableObject/Enemy")]
public class Enemy : ScriptableObject
{
    public string EnemyNeme; //�G�̖��O
    public int type; //�G�̎��
    public int ID; //�G��ID
    public int health; //�G��HP
    public int power; //�G�̍U����
    public int defense; //�G�̖h���
    public int money; //�h���b�v���邨��
    public EnemyActionType[] actions; //�G�̍s��
}
public enum EnemyActionType
{
    Attack, //�U��
    Defence, //�h��
    increasedAttackPower, //�U���͏㏸
    demotivation, //���C����
}
