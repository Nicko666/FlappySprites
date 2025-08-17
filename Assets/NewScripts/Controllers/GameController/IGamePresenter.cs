using System;

public interface IGamePresenter
{
    public event Action OnPlay;
    public event Action OnCollidePoint;
    public event Action OnCollideBorder;

    void OutputPlayerThemeModel(PlayerThemeModel model);
    void OutputPlayerThemesModel(PlayerThemeModel[] obj);
    void OutputWorldThemeModel(WorldThemeModel model);
    void OutputWorldThemesModel(WorldThemeModel[] obj);
}