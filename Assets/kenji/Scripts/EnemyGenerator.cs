using System.Collections.Generic;
using Yusya.Enum;
using UnityEngine;
public class EnemyGenerator : MonoBehaviour
{

    // “G‚ÌoŒ»ƒ|ƒCƒ“ƒg.
    [SerializeField] List<Transform> enemySpawnPoints = new List<Transform>();
    [SerializeField] GameObject[] _enemyPrefabs;
    [SerializeField] int _enemyAttack = 0;
    [SerializeField] HPStatus _hpStatus = 0;

    void Start()
    {
        foreach(var point  in enemySpawnPoints)
        {
            int number = Random.Range(0, _enemyPrefabs.Length);
            //enemy‚ğƒCƒ“ƒXƒ^ƒ“ƒX‰»‚·‚é(ƒ‰ƒ“ƒ_ƒ€¶¬‚·‚é)
            Instantiate(_enemyPrefabs[number],point.position,Quaternion.identity);
        }
    }
    //“G‚ÌUŒ‚ˆ—
    public void eAttack()
    {
        T_Player._currentHP -= _enemyAttack - T_Player._currentDif;
        TurnManager.turnState = TurnState.End;
    }
    public void Update()
    {
         if (_hpStatus < 0)
        {
            Debug.Log("“G€–S");
            this.gameObject.SetActive(false);
        }//“G‚Ì€–Sˆ—
    }
    public void eTurn()
    {

    }
}
