using UnityEngine;

public class GameScene : Scene
{
    [SerializeField] private GameDatabase _gameModel;
    [SerializeField] private GamePresenter _gamePresenter;

    private GameController _gameController;

    protected override void Awake()
    {
        base.Awake();

        _gameController = new GameController(_projectPresenter, _gameModel, _gamePresenter);
    }
    protected override void OnDestroy()
    {
        _gameController.Dispose();

        base.OnDestroy();
    }
}
