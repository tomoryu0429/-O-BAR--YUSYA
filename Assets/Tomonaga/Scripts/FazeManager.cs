using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// �J�[�h�^�[�����̃t�F�C�Y�̊Ǘ�
/// </summary>

public enum CardFaze
{
    Draw,
    Selsect,
    Play,
    Cook,
}

public enum CookFaze
{
    FoodSel, //�����̑I��
    MaterialSel, //�f�ނ̑I��
}


public class FazeManager : MonoBehaviour
{

    public static CardFaze NowCardFaze;     //���̃t�F�C�Y
    public Text FazeText;                   //���݂̃t�F�C�Y��\������e�L�X�g

    // Start is called before the first frame update
    void Start()
    {
        NowCardFaze = CardFaze.Draw;
    }

    // Update is called once per frame
    void Update()
    {
        FazeText.text = "���݂̃t�F�C�Y: " + NowCardFaze.ToString();
    }

}
