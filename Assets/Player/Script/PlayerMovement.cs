using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public CharacterController controller;
    public Animator animator;

    [Header("Setting Running")]
    Vector3 direction;
    public float speed;

    [Header("Setting Jump")]
    public bool isJump = false;
    private float gravity;
    private float jumpHeight = 3;
    private float gravityScale = 1;

    private void Start()
    {
        if (instance == null) instance = this;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            direction = transform.forward;
            animator.SetBool("Run", true);
        }
        else
        {
            direction = Vector3.zero;
            animator.SetBool("Run", false);
        }
        if (controller.isGrounded)
        {
            gravity = -0.1f;
            if (isJump)
            {
                Jump();
            }
        }
        else
        {
            isJump = false;
            gravity += gravityScale * Physics.gravity.y * Time.deltaTime;
        }


        if (Input.mousePosition.x < Screen.width / 3)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -100, 0), Time.deltaTime);

        else if (Input.mousePosition.x > (Screen.width / 3) * 2)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 100, 0), Time.deltaTime);

        else
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 1.5f);


        direction.y = gravity;
        controller.Move(direction * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);

    }
    public void YouСaught()
    {
        SceneManager.LoadScene(0);
    }
    public void Jump()
    {
        gravity = jumpHeight;
        animator.SetTrigger("Jump");
    }

}



