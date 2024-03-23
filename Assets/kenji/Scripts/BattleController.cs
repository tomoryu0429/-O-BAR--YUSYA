using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public bool playerTurn; //trueのときプレイヤーのターン
    public bool enemyalive; //敵が生きているか
    public bool playeralive; //プレイヤーが生きているか

    public GameObject clear; //ゲームクリアの画像
    ClearTween script;  //クリア画像を動かすスクリプト
    public GameObject gameover; //ゲームオーバーの画像
    GameOverTween scriptGO;  //ゲームオーバー画像を動かすスクリプト


    public GameObject player1;  //プレイヤーオブジェクト
    public GameObject enemy1;  //敵オブジェクト
    P1Tween scriptP;  //プレイヤーを動かすスクリプト
    E1Tween scriptE;  //敵を動かすスクリプト

    public GameObject p1dmgtxt; //プレイヤーダメージ表記オブジェクト
    public GameObject e1dmgtxt; //敵ダメージ表記オブジェクト
    private Text P1DamageText; //プレイヤーダメージ表記テキスト
    private Text E1DamageText; //敵ダメージ表記テキスト
    E1dmgTween scriptE1dmg; //敵ダメージ表記を動かすスクリプト
    P1dmgTween scriptP1dmg; //プレイヤーダメージ表記を動かすオブジェクト

    T_Player _maxHP; //プレイヤーHP
    T_Player at; //プレイヤー攻撃力
    MonsterEntity AT; //敵攻撃力
    MonsterEntity HP; //敵HP

    void Start()
    {
        playerTurn = true;
        enemyalive = true;
        playeralive = true;

        player1 = GameObject.Find("Player1");
        enemy1 = GameObject.Find("Enemy1");

        p1dmgtxt = GameObject.Find("P1Damage");
        p1dmgtxt.SetActive(false);
        e1dmgtxt = GameObject.Find("E1Damage");
        e1dmgtxt.SetActive(false);

        Debug.Log("バトルスタート");
        Debug.Log("敵HP" + HP);
        Debug.Log("プレイヤーHP" + _maxHP);
    }

    void Update()
    {
        if (playerTurn == true && playeralive == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("プレイヤーターン");
                Invoke("Player1Move", 0.5f); //プレイヤー動かす
                Ehp -= Patk; //敵のHPを減らす
                Debug.Log("敵HP" + Ehp);

                E1DamageText = e1dmgtxt.GetComponent<Text>();
                //敵ダメージ表記オブジェクトからテキストを取得
                E1DamageText.text = "-" + Patk; //テキストにダメージを入れる
                scriptE1dmg = e1dmgtxt.GetComponent<E1dmgTween>();
                //E1Damageにアタッチされているスクリプトを取得
                scriptE1dmg.E1dmg(); //ダメージを動かしながら表示

                if (Ehp <= 0) //敵HPが0以下のとき
                {
                    enemyalive = false;
                    Invoke("Enemy1Dead", 1f); //敵を非アクティブにする
                    Invoke("AllEnemyDead", 1f); //ゲームクリア画面表示
                }

                playerTurn = false;
            }
        }

        if (playerTurn == false && enemyalive == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("敵ターン");

                Invoke("Enemy1Move", 1.5f); //敵動かす
                _maxHP -= Eatk; //プレイヤーのHPを減らす
                Debug.Log("プレイヤーHP" + _maxHP);

                P1DamageText = p1dmgtxt.GetComponent<Text>();
                //プレイヤーダメージ表記オブジェクトからテキストを取得
                P1DamageText.text = "-" + Eatk; //テキストにダメージを入れる
                scriptP1dmg = p1dmgtxt.GetComponent<P1dmgTween>();
                //P1Damageにアタッチされているスクリプトを取得
                scriptP1dmg.P1dmg();　//ダメージを動かしながら表示

                if (_maxHP <= 0)　//プレイヤーHPが0以下のとき
                {
                    playeralive = false;
                    Invoke("Player1Dead", 1f); //プレイヤーを非アクティブにする
                    Invoke("GameOver", 1f); //ゲームオーバー画面表示
                }

                playerTurn = true;
            }//https://feynman.co.jp/unityforest/game-create-lesson/2drpg-game/enemy-pattern-ai/
        }
    }

    void Player1Move()
    {
        scriptP = player1.GetComponent<P1Tween>();
        scriptP.P1Move();
    }

    void Enemy1Move()
    {
        scriptE = enemy1.GetComponent<E1Tween>();
        scriptE.E1Move();
    }

    void Player1Dead()
    {
        player1.SetActive(false);
    }

    void Enemy1Dead()
    {
        enemy1.SetActive(false);
    }

    void GameOver()
    {
        gameover = GameObject.Find("GameOver");
        scriptGO = gameover.GetComponent<GameOverTween>();
        scriptGO.GameOver1();
        Debug.Log("ゲームオーバー");
    }

    void AllEnemyDead()
    {
        clear = GameObject.Find("Clear");
        script = clear.GetComponent<ClearTween>();
        script.Clear();
        Debug.Log("ゲームクリア");
    }
}