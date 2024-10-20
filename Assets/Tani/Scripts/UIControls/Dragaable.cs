using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Dragaable : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    [SerializeField] private RectTransform _parentRectTransform;


    private Transform _prev;
    private int _prevSibilingIndex;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _prev = transform.parent;
        _prevSibilingIndex = transform.GetSiblingIndex();
        transform.SetParent(_parentRectTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, eventData.position, null, out Vector2 pos);
        transform.localPosition = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        bool IsFound = false;
        foreach(var result in results)
        {
            
            if(result.gameObject.TryGetComponent(out IDropReceivable receivable))
            {
                //SibilingIndex‚ÌŒvŽZ(ŠÔ‚É‚Í‚³‚Þ‚È‚Ç)
                RectTransform rt = receivable.GetTransform();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, eventData.position, null, out Vector2 pos);
                int sibilingIndex = 0;
                for (int i = 0; i < rt.childCount; i++)
                {
                    if (rt.GetChild(i).localPosition.x < pos.x)
                    {
                        sibilingIndex++;
                    }
                }

                //e‚ÆSibilingIndex‚ðŽw’è
                transform.SetParent(rt);
                transform.SetSiblingIndex(sibilingIndex);
                receivable.OnDrop(gameObject);
                IsFound = true;
                break;
            }
        }
        if(IsFound == false)
        {
            transform.SetParent(_prev);
            transform.SetSiblingIndex(_prevSibilingIndex);
        }
    }
}

public interface IDropReceivable
{
    RectTransform GetTransform();
    void OnDrop(GameObject drop);
}
