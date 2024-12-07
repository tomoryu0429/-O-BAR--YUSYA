using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class UI_Merge_Canvas : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    private void Awake()
    {
        FindAnyObjectByType<UIManager>().RegisterGroup(_canvas.sortingOrder,GetComponentsInChildren<UIGroup>(true));
        Destroy(this.gameObject);
    }

    
}
