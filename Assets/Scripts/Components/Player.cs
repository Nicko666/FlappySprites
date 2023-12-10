using Leopotam.Ecs;
using UnityEngine;

public struct Player
{
    public EcsEntity entity;
    public Transform transform;
    public Rigidbody2D rigidbody;
    public Animator animator;
    public PlayerThemesAddressables playerThemes;
    public PlayerCollision playerCollision;
}