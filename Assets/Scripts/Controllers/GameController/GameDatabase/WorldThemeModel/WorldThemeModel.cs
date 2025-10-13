using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "WorldThemeData", menuName = "Scriptable Objects/WorldThemeData")]
internal class WorldThemeModel : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private Sprite _icon;
    [SerializeField] private SpriteLibraryAsset _spriteLibraryAsset;
    
    internal int ID => _id;
    internal Sprite Icon => _icon;
    internal SpriteLibraryAsset SpriteLibraryAsset => _spriteLibraryAsset;
}
