using UnityEngine;
using DG.Tweening; //DOTweenを使うために追加

public class P1Tween : MonoBehaviour
{
    public void P1Move()
    {
        MoveGo();
    }
    private void MoveGo() //プレイヤーを敵に向かって移動
    {
        transform.DOLocalMove(new Vector3(-389f, 0, 0), 0.1f)
            .SetRelative() //相対座標で動かす
            .OnComplete(() => MoveBack()); //終わったらMoveBackを実行
    }
    private void MoveBack() //プレイヤーを元の位置に戻す
    {
        transform.DOLocalMove(new Vector3(389f, 0, 0), 0.1f)
            .SetRelative();
    }
}