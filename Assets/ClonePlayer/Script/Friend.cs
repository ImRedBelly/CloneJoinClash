using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Friend : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    
    public float speed;

    [Header("Setting LayerMask")]
    public LayerMask playerMask;
    string startLayer = "Default";
    string collisionLayer = "Player";

    [Header("Setting Running")]
    public Vector3 difference;

    Vector3 direction;
    bool isRunning;
    bool isPlayerNearby;
    public float serachRadius = 5;

    public bool isJump = false;
    private float gravity;
    private float jumpHeight = 3;
    private float gravityScale = 1;
    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer(startLayer);
    }
    private void Update()
    {
        isPlayerNearby = Physics.CheckSphere(transform.position, serachRadius, playerMask);

        direction = PlayerMovement.instance.transform.forward;

        if (controller.isGrounded)
        {
            gravity = -0.1f;
            if (Input.GetButtonDown("Jump") || isJump)
            {
                Jump();
            }
        }
        else
        {
            isJump = false;
            gravity += gravityScale * Physics.gravity.y * Time.deltaTime;
        }
        if (!isRunning && isPlayerNearby)
        {
            isRunning = true;

            gameObject.layer = LayerMask.NameToLayer(collisionLayer);
        }

        direction.y = gravity;

        if (isRunning && Input.GetMouseButton(0))
        {
            animator.SetBool("Run", true);
            transform.rotation = PlayerMovement.instance.transform.rotation;
            controller.Move(direction * speed * Time.deltaTime);
        }
        else if (isRunning && !Input.GetMouseButton(0))
        {
            direction = Vector3.zero;
            controller.Move(direction * speed * Time.deltaTime);
            animator.SetBool("Run", false);
        }
    }
    public void Jump()
    {
        gravity = jumpHeight;
        animator.SetTrigger("Jump");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, serachRadius);
    }
}
