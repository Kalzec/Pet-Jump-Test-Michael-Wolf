using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to control the scrolling Texture of background objects
/// </summary>
public class ScrollingTexture : MonoBehaviour
{
    public float startingSpeed;
    public float targetScrollSpeed = 0.2f;
    public float transitionSpeed = 2f;
    private Vector2 offset;

    public float currentScrollSpeed;

    MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        currentScrollSpeed = targetScrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameData.isPaused)
        {
            //rend.material.mainTextureOffset = new Vector2(Time.realtimeSinceStartup * scrollSpeed, 0);
            // Smoothly transition the current scroll speed towards the target scroll speed
            currentScrollSpeed = Mathf.Lerp(currentScrollSpeed, targetScrollSpeed, transitionSpeed * Time.deltaTime);

            // Calculate the new offset based on the current time and scroll speed
            offset.x += currentScrollSpeed * Time.deltaTime;

            // Apply the offset to the material of the renderer
            rend.material.SetTextureOffset("_MainTex", offset);
        }
    }

    public void SetScrollSpeed(float speed)
    {
        targetScrollSpeed = speed;
    }

    public void resetSpeed()
    {
        targetScrollSpeed = startingSpeed;
        currentScrollSpeed = startingSpeed;
    }
}
