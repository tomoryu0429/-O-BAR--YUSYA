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
        //�I�u�W�F�N�g�����[�J�����W�ňړ��i���W,�A�j���[�V�������ԁj
    }
}