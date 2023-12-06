using UnityEngine;

public class TimeAccelerationSystem : MonoBehaviour
{
    [SerializeField] float arithmeticAccelerator, geometricAccelerator;

    private void FixedUpdate()
    {
        Time.timeScale *= geometricAccelerator;
        Time.timeScale += arithmeticAccelerator;
    }

    public TimeAccelerationSystem()
    {
        arithmeticAccelerator = 0;
        geometricAccelerator = 1;
    }

}
