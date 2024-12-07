using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftWindowPresenter : UIGroup
{
    [SerializeField] private CraftHandCardView _handCardView;
    [SerializeField] private CraftCardOutputView _outPutView;
    [SerializeField] private CraftButton _button;
    public override void Initialize()
    {
        _button.Entry();
        _handCardView.Entry();
        _outPutView.Entry();
    }
}
