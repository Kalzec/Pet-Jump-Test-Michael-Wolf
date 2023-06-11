using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control the Animations for the main character
/// </summary>
public class AnimationController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Idle to running
        if(GameData.isPaused == true)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        //running to jumping
        if(PlayerController.isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        //getting hit
        if(PlayerController.hitSomething == true)
        {
            animator.SetBool("isHit", true);
        }
        else
        {
            animator.SetBool("isHit", false);
        }
    }
}
