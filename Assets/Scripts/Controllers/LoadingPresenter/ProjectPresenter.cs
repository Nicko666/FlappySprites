using UnityEngine;

public class ProjectPresenter : MonoBehaviour, IProjectPresenter
{
    [SerializeField] private Animator _animator;
    private const string IsLoadingBool = "IsLoading";

    public void OutputLoading(bool value) =>
        _animator.SetBool(IsLoadingBool, value);
}