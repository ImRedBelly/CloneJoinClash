using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float speed;

    Vector3 direction;
    private float gravity;
    private float jumpHeight = 3;
    private float gravityScale = 1;
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
            if (Input.GetButtonDown("Jump"))
            {
                gravity = jumpHeight;
                animator.SetTrigger("Jump");
            }
        }
        else
        {
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
        {
            SceneManager.LoadScene(0);
        }
    }
}
