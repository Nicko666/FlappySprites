using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

internal class WorldPresenter : MonoBehaviour
{
    [SerializeField] private ObstaclesPresenter _obstaclesPresenter;
    [SerializeField] private MovingSprite[] _movingSprites;
    [SerializeField] private SpriteLibrary _spriteLibrary;
    [SerializeField] private float _width = 10.80f;

    internal void OutputIdol() =>
        _obstaclesPresenter.OutputIdol();

    internal void OutputPause() =>
        _obstaclesPresenter.OutputPause();

    internal void OutputPlay() =>
        _obstaclesPresenter.OutputPlay();

    internal void OutputWorldThemeModel(WorldThemeModel worldThemeModel)
    {
        _spriteLibrary.spriteLibraryAsset = worldThemeModel.SpriteLibraryAsset;
        _obstaclesPresenter.OutputWorldThemeModel(worldThemeModel);

        Array.ForEach(_movingSprites, i => i.OutputSize(_width));
    }

    private void Update() =>
        Array.ForEach(_movingSprites, i => i.Move());
}

[Serializable]
internal class MovingSprite
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;
    private float _width;

    internal void OutputSize(float limits)
    {
        if (_spriteRenderer.sprite == null) return;

        _width = _spriteRenderer.sprite.rect.width / _spriteRenderer.sprite.pixelsPerUnit;
        float height = _spriteRenderer.sprite.rect.height / _spriteRenderer.sprite.pixelsPerUnit;
        _spriteRenderer.size = new Vector2(limits + _width, height);
    }

    internal void Move()
    {
        _spriteRenderer.transform.position += Vector3.left * (_speed * Time.deltaTime);

        if (_spriteRenderer.transform.position.x < -_width / 2)
            _spriteRenderer.transform.position += Vector3.right * _width;
    }
}