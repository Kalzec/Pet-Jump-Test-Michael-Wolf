using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control everything related the player character
/// </summary>
public class PlayerController : MonoBehaviour
{
    private Vector3? startPos = null;

    public float jumpForce = 2f;
    public static bool isGrounded;

    private Rigidbody rb;

    public LayerMask groundLayer;
    public float raycastDistance = 0.6f;

    private RaycastHit colliderRay;
    public static bool hitSomething = false;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.isPaused)
        {
            return;
        }

        //Ground Check
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //Jumping
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(Input.touchCount > 0 && isGrounded )
        {
            Touch touch = Input.GetTouch(0);
            
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    break;
            }
        }

        //hitSomething = Physics.Raycast(transform.position + new Vector3(0, 0.05f, 0), Vector3.right, out colliderRay, 0.4f);

        if (hitSomething)
        {
            GameController.Instance.LevelComplete();
            GameController.restartGame = true;
        }
    }

    public void ResetPlayer()
    {
        if (!startPos.HasValue)
        {
            startPos = transform.position;
        }

        transform.position = startPos.Value;
        hitSomething = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                hitSomething = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.down) * 0.6f;
        Gizmos.DrawRay(transform.position, direction);
    }
}

