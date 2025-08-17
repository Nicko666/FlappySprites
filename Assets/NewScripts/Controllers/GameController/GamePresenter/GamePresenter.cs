using System;
using UnityEngine;

public class GamePresenter : MonoBehaviour, IGamePresenter
{
    public event Action OnPlay;
    public event Action OnCollidePoint;
    public event Action OnCollideBorder;

    public void OutputPlayerThemeModel(PlayerThemeModel model)
    {
        Debug.Log("OutputPlayerThemeModel");
    }

    public void OutputPlayerThemesModel(PlayerThemeModel[] obj)
    {
        Debug.Log("OutputPlayerThemesModel");
    }

    public void OutputWorldThemeModel(WorldThemeModel model)
    {
        Debug.Log("OutputWorldThemeModel");
    }

    public void OutputWorldThemesModel(WorldThemeModel[] obj)
    {
        Debug.Log("OutputWorldThemesModel");
    }
}
