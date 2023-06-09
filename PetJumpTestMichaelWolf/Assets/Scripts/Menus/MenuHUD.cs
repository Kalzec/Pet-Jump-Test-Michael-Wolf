using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHUD : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameData.score = 32;
    }

    // Update is called once per frame
    void Update()
    {
        GameData.score += 1;
        scoreText.text = "Score: " + GameData.score;
    }
}
