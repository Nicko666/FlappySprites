using UnityEngine;

public class MovingTransforms : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderers;
    public float speed;
    float platformsDrawDistance = 0;

    private void Start()
    {
        platformsDrawDistance = spriteRenderers.Length / -2f;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].transform.localPosition += Vector3.left * (speed * Time.fixedDeltaTime);

            if (spriteRenderers[i].transform.localPosition.x < platformsDrawDistance)
                spriteRenderers[i].transform.localPosition += Vector3.right * spriteRenderers.Length;
        }
    }
}
