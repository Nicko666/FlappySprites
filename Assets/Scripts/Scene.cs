using UnityEngine;

public class Scene : MonoBehaviour
{
    [SerializeField] private ProjectPresenter _projectPresenterPrefab;
    protected static ProjectPresenter _projectPresenter;

    protected virtual void Awake()
    {
        DontDestroyOnLoad(_projectPresenter ??= Instantiate(_projectPresenterPrefab));
    }
    protected virtual void OnDestroy()
    {
        //Destroy(_loadingPresenter.gameObject);
    }
}
