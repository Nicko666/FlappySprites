using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneData : MonoBehaviour
{
    [Header("Scene")]
    [Space(10)]
    public Transform playerSpawnPoint;
    public ObstaclesSpawn obstaclesSpawn;
    public TimeAccelerationSystem timeAccelerationSystem;
    public GameObject player;
    
    [Header("World")]
    [Space(10)]
    public SpriteRenderer sky;
    public MovingTransforms farBackground;
    public MovingTransforms closeBackground;
    public MovingTransforms platforms;

    [Header("UI")]
    [Space(10)]
    public UI menuUI;
    public UI gameUI, endGameUI;

    public Button menuButton, jumpButton, startButton;

    public TMP_Text[] currentPointsTexts;
    public TMP_Text[] personalRecordText, oldPersonalRecordText, globalRecordText, endGameMessage;

    //public TwoStateButtonInt[] playerThemesButtons, worldThemesButtons;
    public TwoStateButtonClick[] playerThemesButtons, worldThemesButtons;

}
