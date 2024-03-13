using UnityEngine;
using DG.Tweening; //DOTween���g�����߂ɒǉ�

public class P1Tween : MonoBehaviour
{
    public void P1Move()
    {
        MoveGo();
    }
    private void MoveGo() //�v���C���[��G�Ɍ������Ĉړ�
    {
        transform.DOLocalMove(new Vector3(-389f, 0, 0), 0.1f)
            .SetRelative() //���΍��W�œ�����
            .OnComplete(() => MoveBack()); //�I�������MoveBack�����s
    }
    private void MoveBack() //�v���C���[�����̈ʒu�ɖ߂�
    {
        transform.DOLocalMove(new Vector3(389f, 0, 0), 0.1f)
            .SetRelative();
    }
}