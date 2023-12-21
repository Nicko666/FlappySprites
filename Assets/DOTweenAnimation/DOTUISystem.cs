using System.Collections;
using UnityEngine;

public class DOTUISystem : MonoBehaviour
{
    public static float duration = 0;
    
    [SerializeField] float animationSpeed;

    private void Start()
    {
        StartCoroutine(NextFrame());
    }

    IEnumerator NextFrame()
    {
        yield return new WaitForEndOfFrame();

        duration = animationSpeed;
    }

}