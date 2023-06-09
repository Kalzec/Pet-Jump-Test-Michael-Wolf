using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RaycastHit groundRay;

    private Vector3? startPos = null;

    private float jumpVelocity = 0;
    private const float maxJumpVelocity = 3;

    private bool isOnGround = false;
    private bool hitSomething = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.isPaused)
        {
            return;
        }

        isOnGround = Physics.Raycast(transform.position + new Vector3(0, 0.05f, 0), Vector3.down, out groundRay, 0.06f);

        if (isOnGround)
        {
            jumpVelocity = 0;

            transform.position = new Vector3(transform.position.x, groundRay.point.y, transform.position.z);

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                jumpVelocity = maxJumpVelocity;
            }
        }
        else if (jumpVelocity == 0)
        {
            jumpVelocity -= Time.deltaTime * maxJumpVelocity * 2;
        }

        if (jumpVelocity != 0)
        {
            jumpVelocity -= Time.deltaTime * maxJumpVelocity * 2;
            transform.Translate(jumpVelocity * Time.deltaTime * Vector3.up);
        }



    }

    public void ResetPlayer()
    {
        if (!startPos.HasValue)
        {
            startPos = transform.position;
        }

        jumpVelocity = 0;
        transform.position = startPos.Value;
        hitSomething = false;
    }
}
