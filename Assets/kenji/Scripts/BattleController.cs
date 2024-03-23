using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public bool playerTurn; //true�̂Ƃ��v���C���[�̃^�[��
    public bool enemyalive; //�G�������Ă��邩
    public bool playeralive; //�v���C���[�������Ă��邩

    public GameObject clear; //�Q�[���N���A�̉摜
    ClearTween script;  //�N���A�摜�𓮂����X�N���v�g
    public GameObject gameover; //�Q�[���I�[�o�[�̉摜
    GameOverTween scriptGO;  //�Q�[���I�[�o�[�摜�𓮂����X�N���v�g


    public GameObject player1;  //�v���C���[�I�u�W�F�N�g
    public GameObject enemy1;  //�G�I�u�W�F�N�g
    P1Tween scriptP;  //�v���C���[�𓮂����X�N���v�g
    E1Tween scriptE;  //�G�𓮂����X�N���v�g

    public GameObject p1dmgtxt; //�v���C���[�_���[�W�\�L�I�u�W�F�N�g
    public GameObject e1dmgtxt; //�G�_���[�W�\�L�I�u�W�F�N�g
    private Text P1DamageText; //�v���C���[�_���[�W�\�L�e�L�X�g
    private Text E1DamageText; //�G�_���[�W�\�L�e�L�X�g
    E1dmgTween scriptE1dmg; //�G�_���[�W�\�L�𓮂����X�N���v�g
    P1dmgTween scriptP1dmg; //�v���C���[�_���[�W�\�L�𓮂����I�u�W�F�N�g

    T_Player _maxHP; //�v���C���[HP
    T_Player at; //�v���C���[�U����
    MonsterEntity AT; //�G�U����
    MonsterEntity HP; //�GHP

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

        Debug.Log("�o�g���X�^�[�g");
        Debug.Log("�GHP" + HP);
        Debug.Log("�v���C���[HP" + _maxHP);
    }

    void Update()
    {
        if (playerTurn == true && playeralive == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("�v���C���[�^�[��");
                Invoke("Player1Move", 0.5f); //�v���C���[������
                Ehp -= Patk; //�G��HP�����炷
                Debug.Log("�GHP" + Ehp);

                E1DamageText = e1dmgtxt.GetComponent<Text>();
                //�G�_���[�W�\�L�I�u�W�F�N�g����e�L�X�g���擾
                E1DamageText.text = "-" + Patk; //�e�L�X�g�Ƀ_���[�W������
                scriptE1dmg = e1dmgtxt.GetComponent<E1dmgTween>();
                //E1Damage�ɃA�^�b�`����Ă���X�N���v�g���擾
                scriptE1dmg.E1dmg(); //�_���[�W�𓮂����Ȃ���\��

                if (Ehp <= 0) //�GHP��0�ȉ��̂Ƃ�
                {
                    enemyalive = false;
                    Invoke("Enemy1Dead", 1f); //�G���A�N�e�B�u�ɂ���
                    Invoke("AllEnemyDead", 1f); //�Q�[���N���A��ʕ\��
                }

                playerTurn = false;
            }
        }

        if (playerTurn == false && enemyalive == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("�G�^�[��");

                Invoke("Enemy1Move", 1.5f); //�G������
                _maxHP -= Eatk; //�v���C���[��HP�����炷
                Debug.Log("�v���C���[HP" + _maxHP);

                P1DamageText = p1dmgtxt.GetComponent<Text>();
                //�v���C���[�_���[�W�\�L�I�u�W�F�N�g����e�L�X�g���擾
                P1DamageText.text = "-" + Eatk; //�e�L�X�g�Ƀ_���[�W������
                scriptP1dmg = p1dmgtxt.GetComponent<P1dmgTween>();
                //P1Damage�ɃA�^�b�`����Ă���X�N���v�g���擾
                scriptP1dmg.P1dmg();�@//�_���[�W�𓮂����Ȃ���\��

                if (_maxHP <= 0)�@//�v���C���[HP��0�ȉ��̂Ƃ�
                {
                    playeralive = false;
                    Invoke("Player1Dead", 1f); //�v���C���[���A�N�e�B�u�ɂ���
                    Invoke("GameOver", 1f); //�Q�[���I�[�o�[��ʕ\��
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
        Debug.Log("�Q�[���I�[�o�[");
    }

    void AllEnemyDead()
    {
        clear = GameObject.Find("Clear");
        script = clear.GetComponent<ClearTween>();
        script.Clear();
        Debug.Log("�Q�[���N���A");
    }
}