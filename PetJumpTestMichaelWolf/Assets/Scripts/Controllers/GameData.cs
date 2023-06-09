using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for storing Temporary data
/// </summary>
public static class GameData
{
    public static int score = 0;
    public static int highScore = 0;
    public static float speedIncrease = 0.1f;

    public static bool isPaused = true;

    public static void ResetData()
    {
        score = 0;
        GameController.restartGame = false;
    }

}
