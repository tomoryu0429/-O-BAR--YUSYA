using UnityEngine;
using DG.Tweening;

public class GameOverTween : MonoBehaviour
{
    public void GameOver1()
    {
        Invoke("GameOverMove", 0.5f);
    }
    private void GameOverMove()
    {
        transform.DOLocalMove(new Vector3(-14f, -18f, 0), 0.5f);
    }
}