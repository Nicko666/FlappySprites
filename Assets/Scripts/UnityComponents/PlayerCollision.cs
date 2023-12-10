using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Collider2D collider2d;

    public UnityEvent onCheckpoint;
    public UnityEvent onObstacle;

    GameObject lastPoint;

    private void OnEnable()
    {
        collider2d.enabled = true;
        lastPoint = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            onObstacle?.Invoke();
        }
        if (collision.gameObject.tag == "Point" & collision.gameObject != lastPoint)
        {
            lastPoint = collision.gameObject;
            onCheckpoint?.Invoke();
        }
    }

    private void OnDisable()
    {
        collider2d.enabled = false;
    }
}
