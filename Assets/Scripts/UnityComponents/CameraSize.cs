using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [SerializeField] float size;

    private void Start()
    {
        SetCameraSize();
    }

    void SetCameraSize()
    {
        Camera.main.orthographicSize = size / Camera.main.aspect;
        Debug.Log(Camera.main.orthographicSize);
    }

}
