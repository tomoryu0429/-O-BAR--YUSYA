using UnityEngine;
using UnityEngine.UI; // Text�iUI�j�������̂ł��ꂪ�K�v

public class TextTest : MonoBehaviour
{
    [SerializeField] private MonsterDTSO excelData; // �f�[�^���i�[
    [SerializeField] private Text nameText; // �\�����郂���X�^�[�̖��O�̃e�L�X�g

    private void Start()
    {
        // �\���̃e�L�X�g�������X�^�[�̖��O�i���X�g��1�Ԃ͂��߂́j�ɕς���
        nameText.text = excelData.Entities[0].Name;
    }
}

