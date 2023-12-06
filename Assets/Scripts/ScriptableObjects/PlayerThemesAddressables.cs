using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerThemesAddressables : MonoBehaviour
{
    //public AssetReferenceT<PlayerTheme>[] playerThemesAssets;
    //private AsyncOperationHandle<PlayerTheme> _currentThemeOperatinoHanfle;

    //public void SetPlayerTheme(Player player, int index)
    //{
    //    StartCoroutine(ChangePlayerTheme(player, index));
    //}

    //IEnumerator ChangePlayerTheme(Player player, int index)
    //{
    //    if (_currentThemeOperatinoHanfle.IsValid())
    //        Addressables.Release(_currentThemeOperatinoHanfle);

    //    _currentThemeOperatinoHanfle = playerThemesAssets[index].LoadAssetAsync<PlayerTheme>();
    //    yield return _currentThemeOperatinoHanfle;
    //    player.animator.runtimeAnimatorController = _currentThemeOperatinoHanfle.Result.AnimatorController;

    //}

}
