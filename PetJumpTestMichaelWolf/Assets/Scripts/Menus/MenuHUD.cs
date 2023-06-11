using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHUD : IMenu
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    [SerializeField] private Button pauseButton;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameData.score;
        highScoreText.text = "High Score: " + GameData.highScore;
    }

    public override void Show()
    {
        base.Show();
        GameData.isPaused = false;
    }

    private void PauseOnClick()
    {
        if (PlayerController.isGrounded == true)
        {
            GameData.isPaused = true;
            NMenuManager.Manager.ShowPauseMenu();
        }
    }
}
