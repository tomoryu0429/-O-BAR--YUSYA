using UnityEngine;
[CreateAssetMenu(fileName = "newEnemy",menuName = "EnemyScriptableObject/Enemy")]
public class Enemy : ScriptableObject
{
    public string EnemyNeme; //�G�̖��O
    public int health; //�G��HP
    public string description; //�G�̐���
    public int power; //�G�̍U����
}
