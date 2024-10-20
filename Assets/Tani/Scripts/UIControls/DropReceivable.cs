using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
