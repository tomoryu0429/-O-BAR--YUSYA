using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tani
{
    public interface IVisibilityControllable
    {
        public abstract void SetVisible(bool visibility);
        public abstract void SwitchVisibility();
    }
}
