using UnityEngine;
using UnityEngine.U2D.Animation;

internal class ObstaclePresenter : MonoBehaviour
{
    [SerializeField] private SpriteLibrary _spriteLibrary;

    internal void OutputWorldThemeModel(WorldThemeModel worldThemeModel) =>
        _spriteLibrary.spriteLibraryAsset = worldThemeModel.SpriteLibraryAsset;
}
