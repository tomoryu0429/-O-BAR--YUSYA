using UnityEngine;
using DG.Tweening;

public class E1dmgTween : MonoBehaviour
{
    //Player���U������Ƃ��̃��[�V����
    public void E1dmg()
    {
        Invoke("E1dmgjump", 0.5f);
    }
    private void E1dmgjump() //�_���[�W�l��\�����ăW�����v������
    {
        this.gameObject.SetActive(true); //�_���[�W�l��\��
        transform.DOJump(new Vector3(0, 0, 0), 15f, 1, 0.3f)
            //�W�����v������i�ړ��I���n�_, �W�����v��, �W�����v��, �A�j���[�V�������ԁj
            .SetEase(Ease.Linear) //���炩��
            .SetRelative() //���΍��W��
            .OnComplete(() => Endfunc()); //�I�������Endfunc���s
    }
    private void Endfunc()
    {
        this.gameObject.SetActive(false); //�_���[�W�l���\��
    }
}