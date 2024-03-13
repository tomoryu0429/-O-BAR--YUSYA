using UnityEngine;
using DG.Tweening;

public class ClearTween : MonoBehaviour
{
    public void Clear()
    {
        Invoke("Move", 0.5f);
    }
    private void Move()
    {
        transform.DOLocalMove(new Vector3(-14f, -18f, 0), 0.5f);
        //オブジェクトをローカル座標で移動（座標,アニメーション時間）
    }
}