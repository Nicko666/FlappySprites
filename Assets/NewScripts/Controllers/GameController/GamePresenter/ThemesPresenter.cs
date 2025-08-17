using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
internal class ThemesPresenter<T>
{
    [SerializeField] private
    List<T> List;

    internal void OutputList(T[] list, Sprite icon)
    {

    }
    
}
