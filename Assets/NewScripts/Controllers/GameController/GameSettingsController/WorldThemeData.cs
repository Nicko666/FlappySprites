using UnityEngine;

[CreateAssetMenu(fileName = "WorldThemeData", menuName = "Scriptable Objects/WorldThemeData")]
internal class WorldThemeData : ScriptableObject
{
    [SerializeField] private Sprite _icon;

    internal Sprite Icon => _icon;
}
