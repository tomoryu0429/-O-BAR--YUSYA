using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using R3.Triggers;

public class DropReceivable : MonoBehaviour, IDropReceivable
{
    public RectTransform GetTransform()
    {
        return (RectTransform)transform;
    }

    public void OnDrop(GameObject drop)
    {
       
    }
}
