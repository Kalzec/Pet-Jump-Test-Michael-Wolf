using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuGameOver : IMenu
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button retryButton;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        homeButton.onClick.AddListener(HomeOnClick);
        retryButton.onClick.AddListener(RetryOnClick);
    }

    private void HomeOnClick()
    {
        NMenuManager.Manager.ClearToMainMenu();
    }

    private void RetryOnClick()
    {
        NMenuManager.Manager.ClearToMainMenu();
        NMenuManager.Manager.StartGame();
    }

    public override void Show()
    {
        base.Show();

        scoreText.text = $"Score: {GameData.score}";
    }
}
