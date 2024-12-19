using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CraftCardOutputView : MonoBehaviour
{
    private Image _image;
    private AutoEnum.ECardID _currentId;
    public void Entry()
    {
        _image = GetComponent<Image>();
        SetCardPreview(AutoEnum.ECardID.Invalid);
    }

    public void SetCardPreview(AutoEnum.ECardID id)
    {
        _currentId = id;
        if(id == AutoEnum.ECardID.Invalid)
        {
            _image.sprite = null;
            return;
        }

        var sprite = CardSystem.Utility.GetCardData(id).CardSprite;
        _image.sprite = sprite;
    }

    public AutoEnum.ECardID CraftCard()
    {
        _image.sprite = null;
        return _currentId;
    }

}
