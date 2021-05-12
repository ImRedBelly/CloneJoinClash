using UnityEngine;

public abstract class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    [Header("Setting Running")]
    public float speed = 70;

    public float deltaX;
    public Vector3 direction;

    [Header("Setting Jump")]
    public bool isJump = false;

    private float gravity;
    private float jumpHeight = 2;
    private float gravityScale = 1;

    

    public virtual void InputController()
    {
        if (Input.touchCount > 0)
        {
            direction = transform.forward;
            animator.SetBool("Run", true);

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.deltaPosition.x * Time.deltaTime;
                Rotate(deltaX);

                direction.x += deltaX;
                return;
            }
        }
        else
        {
            direction = Vector3.zero;
            animator.SetBool("Run", false);
        }

    }
    public virtual void Jump()
    {
        if (controller.isGrounded)
        {
            gravity = -0.1f;
            if (isJump)
            {
                animator.SetTrigger("Jump");
                gravity = jumpHeight;
            }
        }
        else
        {
            isJump = false;
            gravity += gravityScale * Physics.gravity.y * Time.deltaTime;
        }


        direction.y = gravity;
    }

    private void Rotate(float stepRotate)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 70 * stepRotate, 0), 7 * Time.deltaTime);
    }
}
