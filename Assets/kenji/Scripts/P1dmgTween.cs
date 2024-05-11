using UnityEngine;
using DG.Tweening;

public class P1dmgTween : MonoBehaviour
{
    //“G‚ðUŒ‚‚·‚é‚Æ‚«‚Ìƒ‚[ƒVƒ‡ƒ“
    public void P1dmg()
    {
        Invoke("E1dmgjump", 1.5f);
    }
    private void E1dmgjump()
    {
        this.gameObject.SetActive(true);
        transform.DOJump(new Vector3(0, 0, 0), 15f, 1, 0.3f)
            .SetRelative()
            .OnComplete(() => Endfunc());
    }
    private void Endfunc()
    {
        this.gameObject.SetActive(false);
    }
}