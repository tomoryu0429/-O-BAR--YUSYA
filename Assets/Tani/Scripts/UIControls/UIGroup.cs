using Alchemy.Inspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public abstract class UIGroup : MonoBehaviour
{
    [LabelText("��������UI�̗D��x"), Tooltip("��SortOrder�̃L�����o�X�ł͑傫���قǏ�ɗ��܂�")]
    [field: SerializeField] public int MergePriority { get; private set; }

    private CanvasGroup _canvasGroup = null;

    public CanvasGroup GetCanvasGroup()
    {
        if (_canvasGroup == null) { _canvasGroup = GetComponent<CanvasGroup>(); }
        return _canvasGroup; 
    }

    /// <summary>
    /// UIManager�ɓ������ꂽ�ۂɎ��s����܂�
    /// </summary>
    public abstract void Initialize();
}
