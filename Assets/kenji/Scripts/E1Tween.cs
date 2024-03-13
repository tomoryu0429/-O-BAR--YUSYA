using UnityEngine;
using DG.Tweening;

public class E1Tween : MonoBehaviour
{
    public void E1Move()
    {
        EMoveGo();
    }
    private void EMoveGo()
    {
        transform.DOLocalMove(new Vector3(391, 0, 0), 0.1f)
            .SetRelative()
            .OnComplete(() => EMoveBack());
    }
    private void EMoveBack()
    {
        transform.DOLocalMove(new Vector3(-391, 0, 0), 0.1f)
            .SetRelative();
    }
}