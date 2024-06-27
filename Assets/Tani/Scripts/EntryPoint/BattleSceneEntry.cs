using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tani
{
    public class BattleSceneEntry : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> prefabs;
        private void Start()
        {
            foreach(var n in prefabs)
            {
                print(n);
                Instantiate(n);
            }
        }
    }
}

