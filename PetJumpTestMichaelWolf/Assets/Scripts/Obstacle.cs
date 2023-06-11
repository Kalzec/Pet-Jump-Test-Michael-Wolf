using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to control the obstacles that spawn
/// </summary>
public class Obstacle : MonoBehaviour
{
    Rigidbody rb;

    public float startSpeed = -2.6f;
    public float obstacleSpeed = -2.6f;
    public bool speedIncrease = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameController.restartGame == true)
        {
            obstacleSpeed = startSpeed;
        }
    }

    private void FixedUpdate()
    {
        if(!GameData.isPaused)
        {
            rb.velocity = new Vector3(obstacleSpeed, 0f, 0f);
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }

        if (GameController.increaseSpeed && speedIncrease == true)
        {
            obstacleSpeed -= GameData.speedIncrease;
            speedIncrease = false;
            StartCoroutine("ResetSpeedIncreaseBool");
       }


    }

    IEnumerator ResetSpeedIncreaseBool()
    {
        yield return new WaitForSeconds(1f);
        speedIncrease = true;
    }




}
