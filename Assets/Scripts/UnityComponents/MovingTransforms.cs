using UnityEngine;

public class MovingTransforms : MonoBehaviour
{
    public float speed;
    public float platformsDrawDistance;

    private void Start()
    {
        platformsDrawDistance = transform.localScale.y / 2f;
    }

    private void FixedUpdate()
    {
        transform.localPosition += Vector3.left * (speed * Time.fixedDeltaTime);

        if (transform.localPosition.x < -platformsDrawDistance)
            transform.localPosition += Vector3.right * (transform.localScale.y);
    }

}
