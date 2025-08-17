using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private PlayerThemeData[] _playerThemeModels;
    [SerializeField] private WorldThemeData[] _worldThemeModels;

    internal PlayerThemeData[] PlayerThemeModels => _playerThemeModels;
    internal WorldThemeData[] WorldThemeModels => _worldThemeModels;
}
