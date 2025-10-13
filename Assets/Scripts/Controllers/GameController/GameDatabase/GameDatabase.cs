using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameDatabase : ScriptableObject
{
    [SerializeField] private PlayerThemeModel[] _playerThemesModel;
    [SerializeField] private WorldThemeModel[] _worldThemesModel;
    [SerializeField] private SpeedModel _speedModels;

    internal PlayerThemeModel[] PlayerThemeModels => _playerThemesModel;
    internal WorldThemeModel[] WorldThemeModels => _worldThemesModel;
    internal SpeedModel SpeedModels => _speedModels;
    
}
