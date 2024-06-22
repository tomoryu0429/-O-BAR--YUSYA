using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;

namespace Tani
{
    //生成時点のカードのリストを表示する
    public class CardInstantContainerView : MonoBehaviour
    {
        [SerializeField]
        [LabelText("カードプレハブ")]
        [AssetsOnly]
        GameObject CardImageObj_Prefab;

        private void Awake()
        {

        }

        public void Init(IEnumerable<CardData.ECardID> list)
        {
            //子オブジェクトをすべて破棄
            if(gameObject.transform.childCount != 0)
            {
                Transform[] childs = new Transform[gameObject.transform.childCount];
                for(int i = 0; i < childs.Length; i++)
                {
                    childs[i] = transform.GetChild(i);
                }

                foreach(var n in childs)
                {
                    Destroy(n.gameObject);
                }
            }



            foreach (var n in list)
            {
                var go = Instantiate<GameObject>(CardImageObj_Prefab, this.gameObject.transform);
                NormalImage image = go.GetComponent<NormalImage>();
                image.Sprite = PlayerData.Instance.CardManager.GetCardData(n).CardSprite;
                HandCardEvent cardEvent = go.GetComponent<HandCardEvent>();

            }
        }

    }
}

