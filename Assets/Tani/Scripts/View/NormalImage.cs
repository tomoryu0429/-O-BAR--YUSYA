using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Tani
{

    public class NormalImage : MonoBehaviour
    {
        [SerializeField]
        Image image;
        
        public Sprite Sprite
        {
            get => image.sprite;
            set => image.sprite = value;
        }

        public Color Color
        {
            get => image.color;
            set => image.color = value;
        }

        public Image Image => image;
    }
}

