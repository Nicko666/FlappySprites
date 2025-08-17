using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] private LoadingPresenter _loadingPresenter;
    [SerializeField] private GamePresenter _gamePresenter;
    [SerializeField] private GameData _gameData;

    private GameController _gameController;

    private void Awake()
    {
        _gameController = new GameController(
            new GameSettingsController(_gameData),
            _loadingPresenter,
            _gamePresenter);
    }

    private void OnDestroy()
    {
        _gameController.Dispose();
    }
}
