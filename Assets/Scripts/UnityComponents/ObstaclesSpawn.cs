using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float frequency;
    [SerializeField] float yRange;

    public Queue<SpriteRenderer> spriteRenderers;
    SpriteRenderer temp;
    float timer;

    Vector3 spawnPosition => new(transform.localPosition.x, Random.Range(-yRange, +yRange), transform.localPosition.z);

    private void Awake()
    {
        spriteRenderers = new();
        foreach (Transform child in transform)
            spriteRenderers.Enqueue(child.GetComponent<SpriteRenderer>());
    }

    private void OnEnable()
    {
        timer = 0;
    }

    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;

        if (timer < 0)
        {
            MoveLastToSpawn();

            timer = frequency;
        }

        foreach (var obstacle in spriteRenderers)
        {
            if (!obstacle.gameObject.activeSelf) continue;

            obstacle.transform.localPosition += Vector3.left * (speed * Time.fixedDeltaTime);
        }
    }

    void MoveLastToSpawn()
    {
        temp = spriteRenderers.Dequeue();

        temp.transform.localPosition = spawnPosition;
        temp.gameObject.SetActive(true);

        spriteRenderers.Enqueue(temp);
    }

    private void OnDisable()
    {
        foreach (var obstacle in spriteRenderers)
            obstacle.gameObject.SetActive(false);
    }
}
