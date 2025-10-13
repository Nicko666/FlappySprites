using UnityEngine;

[CreateAssetMenu(fileName = "PlayerThemeData", menuName = "Scriptable Objects/PlayerThemeData")]
internal class PlayerThemeModel : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private Sprite _icon;
    [SerializeField] private RuntimeAnimatorController _runtimeAnimatorController;

    internal int ID => _id;
    internal Sprite Icon => _icon;
    internal RuntimeAnimatorController RuntimeAnimatorController => _runtimeAnimatorController;
}
