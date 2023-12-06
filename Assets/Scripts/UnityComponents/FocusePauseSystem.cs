using UnityEngine;

public class FocusePauseSystem : MonoBehaviour
{
    float time = 1.0f;

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //Debug.Log("Focus");
            Time.timeScale = time;
        }
        else
        {
            //Debug.Log("Unfocus");
            time = Time.timeScale;
            Time.timeScale = 0.0f;
        }
    }
}