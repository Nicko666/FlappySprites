using System;
using UnityEngine;

internal class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    private const string colliderPointTag = "Point";
    private const string colliderObstacleTag = "Obstacle";

    internal Action onInputPoint;
    internal Action onInputObstacle;
    internal Action<float> onInputMoveX;

    private void OnEnable()
    {
        _collider.enabled = true;
        _collider.attachedRigidbody.linearVelocity = Vector3.zero;
        _collider.attachedRigidbody.gravityScale = 1;
        onInputMoveX?.Invoke(_collider.attachedRigidbody.linearVelocityY);
    }
    private void OnDisable()
    {
        _collider.enabled = false;
        _collider.attachedRigidbody.linearVelocity = Vector3.zero;
        _collider.attachedRigidbody.gravityScale = 0;
        onInputMoveX?.Invoke(_collider.attachedRigidbody.linearVelocityY);
    }
    private void Update()
    {
        onInputMoveX?.Invoke(_collider.attachedRigidbody.linearVelocityY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Action action = collision.tag switch
        {
            colliderPointTag => onInputPoint,
            colliderObstacleTag => onInputObstacle,
            _ => null
        };
        action?.Invoke();
    }

    internal void OutputJump(float value) =>
        _collider.attachedRigidbody.linearVelocity = Vector2.up * value;
}
