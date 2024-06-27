using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SibilingTest : MonoBehaviour
{
    [SerializeField]
    Transform target;

    private void Start()
    {
        print(target.GetSiblingIndex());
    }
}
