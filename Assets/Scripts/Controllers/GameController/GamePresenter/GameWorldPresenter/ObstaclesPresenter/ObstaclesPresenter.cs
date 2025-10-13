using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

internal class ObstaclesPresenter : MonoBehaviour
{
    [SerializeField] private ObstaclePresenter _obstaclePresenterPrefab;
    [SerializeField] private float _spawnDistanceX, _spawnY, _spawnDelay, _speed;
    private float _spanwDelayTimer, _modifiedSpeed;
    private WorldThemeModel _worldThemeModel;

    private ObjectPool<ObstaclePresenter> _obstaclePresenterPool;
    private List<ObstaclePresenter> _obstaclePresenters = new();
    
    internal void OutputIdol()
    {
        enabled = false;

        _spanwDelayTimer = 0;

        _modifiedSpeed = _speed;

        while (_obstaclePresenters.Count > 0)
            _obstaclePresenterPool.Release(_obstaclePresenters[0]);
    }

    internal void OutputPause() =>
        enabled = false;

    internal void OutputPlay() =>
        enabled = true;

    private void Awake() =>
        _obstaclePresenterPool = new(CreateObstacle, GetObstacle, ReleaseObstacle, DestroyObstacle);
    private void OnDestroy() =>
        _obstaclePresenterPool.Dispose();

    private void Update()
    {
        _spanwDelayTimer -= Time.deltaTime * _speed;

        if(_spanwDelayTimer < 0)
        {
            _obstaclePresenterPool.Get();
            _spanwDelayTimer = _spawnDelay;
        }

        _obstaclePresenters.ForEach(i => i.transform.localPosition += Vector3.left * Time.deltaTime * _speed);

        while(_obstaclePresenters.Any(i => i.transform.localPosition.x < -_spawnDistanceX))
            _obstaclePresenterPool.Release(_obstaclePresenters.First(i => i.transform.localPosition.x < -_spawnDistanceX));
    }

    private ObstaclePresenter CreateObstacle() =>
        Instantiate(_obstaclePresenterPrefab, transform);
    private void DestroyObstacle(ObstaclePresenter obstaclePresenter) =>
        Destroy(obstaclePresenter.gameObject);
    private void GetObstacle(ObstaclePresenter obstaclePresenter)
    {
        obstaclePresenter.OutputWorldThemeModel(_worldThemeModel);
        
        obstaclePresenter.transform.localPosition = new Vector3(_spawnDistanceX, Random.Range(-_spawnY, _spawnY));
        obstaclePresenter.gameObject.SetActive(true);

        _obstaclePresenters.Add(obstaclePresenter);
    }
    private void ReleaseObstacle(ObstaclePresenter obstaclePresenter)
    {
        obstaclePresenter.gameObject.SetActive(false);
        obstaclePresenter.transform.localPosition = new Vector3(_spawnDistanceX, 0);

        _obstaclePresenters.Remove(obstaclePresenter);
    }

    internal void OutputSpeed(float speedModel) =>
        _modifiedSpeed *= speedModel;

    internal void OutputWorldThemeModel(WorldThemeModel worldThemeModel)
    {
        _worldThemeModel = worldThemeModel;
        _obstaclePresenters.ForEach(i => i.OutputWorldThemeModel(_worldThemeModel));
    }
}