using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to control game logic
/// </summary>
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private PlayerController player;
    [SerializeField] private ObstacleSpawner obstacleSpawner;

    [SerializeField] private ScrollingTexture foreGround;
    [SerializeField] private ScrollingTexture midGround;

    public static bool increaseSpeed = false;
    public static bool restartGame = true;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("IncreaseScore");
        RestartGame();
    }

    IEnumerator IncreaseScore()
    {
        yield return new WaitForSeconds(1);
        if (GameData.isPaused == false)
        {
            GameData.score += 1;
        }
        StartCoroutine("IncreaseScore");
    }

    private void Update()
    {
        if (GameData.score % 10 == 0 && GameData.score != 0)
        {
            if (increaseSpeed == false)
            {
                increaseSpeed = true;
                StartCoroutine("IncreaseSpeed");
            }
        }

        if (GameData.score > GameData.highScore)
        {
            GameData.highScore = GameData.score;
        }
    }

    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(1f);
        foreGround.targetScrollSpeed += GameData.speedIncrease / 14f;
        midGround.targetScrollSpeed += GameData.speedIncrease / 16f;
        increaseSpeed = false;

    }

    public void RestartGame()
    {
        GameData.ResetData();
        restartGame = true;
        StartCoroutine("resetBool");

        player.ResetPlayer();
        increaseSpeed = false;

        obstacleSpawner.resetPool();
        foreGround.resetSpeed();
        midGround.resetSpeed();
    }

    IEnumerator resetBool()
    {
        restartGame = false;
        yield return new WaitForSeconds(0.1f);
    }

    public void LevelComplete()
    {
        GameData.isPaused = true;
        NMenuManager.Manager.ShowLevelCompleteMenu();
    }
}
