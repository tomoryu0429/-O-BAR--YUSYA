using UnityEngine;
using DG.Tweening;

public class E1dmgTween : MonoBehaviour
{
    //Playerを攻撃するときのモーション
    public void E1dmg()
    {
        Invoke("E1dmgjump", 0.5f);
    }
    private void E1dmgjump() //ダメージ値を表示してジャンプさせる
    {
        this.gameObject.SetActive(true); //ダメージ値を表示
        transform.DOJump(new Vector3(0, 0, 0), 15f, 1, 0.3f)
            //ジャンプさせる（移動終了地点, ジャンプ力, ジャンプ回数, アニメーション時間）
            .SetEase(Ease.Linear) //滑らかに
            .SetRelative() //相対座標で
            .OnComplete(() => Endfunc()); //終わったらEndfunc実行
    }
    private void Endfunc()
    {
        this.gameObject.SetActive(false); //ダメージ値を非表示
    }
}