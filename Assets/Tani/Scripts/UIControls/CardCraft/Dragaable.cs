using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//ドラッグ可能で特定のエリアに配置できるUIを定義します
//このコンポーネントを持つUIはIPlacableを実装した親オブジェクトのみの子となることができます
//Placableは左からSibilingIndexの順に配置されていることが前提です(Horizontal LayOut Groupの使用)
public class Dragaable : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    /// <summary>
    /// Parent RectTransform While Dragging 
    /// </summary>
    [SerializeField] private RectTransform _rectTransform;

    private void Start ()
    {
        if(_rectTransform == null)
        {

            _rectTransform = (RectTransform)GetComponentInParent<Canvas>().transform;
        }

        if(!transform.parent.TryGetComponent(out IPlacable placable))
        {
            Destroy(this.gameObject);
            return;
        }
        _lastPlacable = placable;
    }

    /// <summary>
    /// Last Placable 
    /// </summary>
    private IPlacable _lastPlacable;
    /// <summary>
    /// Last Sibiling Index Before Start Dragging
    /// </summary>
    private int _lastSibilingIndex;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _lastSibilingIndex = transform.GetSiblingIndex();
        transform.SetParent(_rectTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, eventData.position, null, out Vector2 pos);
        transform.localPosition = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventData, results);
        bool IsFound = false;
        IPlacable placable = null;
        foreach (var result in results)
        {
            if(result.gameObject.TryGetComponent(out  placable))
            {
                //Dropした際にIPlacableを検知

                //SibilingIndexの計算(間にはさむなど)
                RectTransform rt = placable.GetTransform();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, eventData.position, null, out Vector2 pos);
                int sibilingIndex = 0;
                for (int i = 0; i < rt.childCount; i++)
                {
                    if (rt.GetChild(i).localPosition.x < pos.x)
                    {
                        sibilingIndex++;
                    }
                }

                //親とSibilingIndexを指定
                transform.SetParent(rt);
                transform.SetSiblingIndex(sibilingIndex);
                placable.OnPlace(gameObject);
                IsFound = true;
                break;
            }
        }
        if(IsFound == false)
        {
            //Placableが発見できなかった場合
            transform.SetParent(_lastPlacable.GetTransform());
            transform.SetSiblingIndex(_lastSibilingIndex);
        }
        else
        {
            _lastPlacable.OnAway(gameObject);
            _lastPlacable = placable;
        }
    }
}


public interface IPlacable
{
    RectTransform GetTransform();
    void OnAway(GameObject exit);
    void OnPlace(GameObject drop);
}
