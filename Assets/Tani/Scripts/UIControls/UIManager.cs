using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Cysharp.Threading.Tasks;
/// <summary>
/// すべてのUIを管理します
/// すべてのUIはUIManagerが保持する各キャンバス以下に配置されます
/// UI_Merge_Canvasを使うことで任意の位置からUIManagerに結合できます
/// 
/// </summary>
public class UIManager : MonoBehaviour
{
   
    [SerializeField]private GameObject _canvasPrefab;
    private List<CanvasData> _canvases = new();

    private void Awake()
    {
        if (_canvasPrefab == null)
        {
            Debug.LogError("CanvasPrefabが未設定");
            return;
        }
        if (!_canvasPrefab.TryGetComponent(out CanvasData canvasData))
        {
            Debug.LogError("CanvasPrefabがCanvasを含みません"); return;
        }

    }
    
    public void RegisterGroup(int sortOrder, IEnumerable<UIGroup> groups)
    {
        var canvasData = GetCanvasData(sortOrder);
        foreach(var g in groups)
        {
            canvasData.AddGroup(g);
        }
    }

    public CanvasData GetCanvasData(int sortOrder)
    {
        int index = _canvases.FindIndex(c => c.Canvas.sortingOrder == sortOrder);
        if (index != -1)
        {
            return _canvases[index];
        }
        else
        {
            return CreateNewCanvas(sortOrder);
        }
    }

    private CanvasData CreateNewCanvas(int sortOrder)
    {
        GameObject canvasObject = Instantiate(_canvasPrefab);
        canvasObject.name = $"Canvas_{sortOrder}";
        CanvasData canvasData = canvasObject.GetComponent<CanvasData>();
        int index = _canvases.FindIndex(c => c.Canvas.sortingOrder > sortOrder);
        if(index != -1)
        {
            _canvases.Insert(index, canvasData);
            canvasObject.transform.SetParent(transform);
            canvasObject.transform.SetSiblingIndex(index);
        }
        else
        {
            _canvases.Add(canvasData);
            canvasObject.transform.SetParent(transform);
            canvasObject.transform.SetAsLastSibling();
        }
        canvasData.Canvas.sortingOrder = sortOrder;
        return canvasData;
    }



}
