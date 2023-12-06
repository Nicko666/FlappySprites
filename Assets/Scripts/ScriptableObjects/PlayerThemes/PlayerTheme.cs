using UnityEngine;

[CreateAssetMenu]
public class PlayerTheme : ScriptableObject
{
    [SerializeField] RuntimeAnimatorController animatorController;

    public RuntimeAnimatorController AnimatorController => animatorController;

}
