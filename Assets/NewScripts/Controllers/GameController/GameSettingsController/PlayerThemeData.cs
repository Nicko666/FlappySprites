//using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerThemeData", menuName = "Scriptable Objects/PlayerThemeData")]
internal class PlayerThemeData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    //[SerializeField] private AnimatorController _animatorController;

    internal Sprite Icon => _icon;
    //internal AnimatorController AnimatorController => _animatorController;
}
