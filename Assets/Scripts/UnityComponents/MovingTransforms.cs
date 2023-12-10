using UnityEngine;

public class MovingTransforms : MonoBehaviour
{
    public Transform[] rectTransform;
    public float speed;
    float platformsDrawDistance = 0;

    private void Start()
    {
        platformsDrawDistance = rectTransform.Length / -2f;
    }

    //private void Update()
    //{
    //    for (int i = 0; i < rectTransform.Length; i++)
    //    {
    //        rectTransform[i].localPosition += Vector3.left * (speed * Time.deltaTime);

    //        if (rectTransform[i].localPosition.x < platformsDrawDistance)
    //            rectTransform[i].localPosition += Vector3.right * rectTransform.Length;
    //    }
    //}

    private void FixedUpdate()
    {
        for (int i = 0; i < rectTransform.Length; i++)
        {
            rectTransform[i].localPosition += Vector3.left * (speed * Time.fixedDeltaTime);

            if (rectTransform[i].localPosition.x < platformsDrawDistance)
                rectTransform[i].localPosition += Vector3.right * rectTransform.Length;
        }
    }

}
