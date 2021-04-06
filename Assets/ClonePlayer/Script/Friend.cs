using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Friend : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    [Header("Setting LayerMask")]
    public LayerMask playerMask;
    string collisionLayer = "Player";
    public float serachRadiusPlayer = 10;

    [Header("Setting Running")]
    public float speed;
    GameObject badBoy;
    Vector3 direction;
    bool isPlayerNearby;
    bool isBadBoyNearby;

    [Header("Setting Jump")]
    bool isJump = false;
    private float gravity;
    private float jumpHeight = 3;
    private float gravityScale = 1;

    FriendState friendState;
    enum FriendState
    {
        Idle,
        Run,
        Parting
    }
    private void Start()
    {
        GameManager.instance.AddFriend(gameObject);
        friendState = FriendState.Idle;
    }
    private void Update()
    {
        direction = PlayerMovement.instance.transform.forward;

        switch (friendState)
        {
            case FriendState.Idle:
                isPlayerNearby = Physics.CheckSphere(transform.position, serachRadiusPlayer, playerMask);
                if (isPlayerNearby)
                {
                    friendState = FriendState.Run;
                    gameObject.layer = LayerMask.NameToLayer(collisionLayer);
                }
                break;

            case FriendState.Run:
                Jump();
                direction.y = gravity;
                Run();

                if (isBadBoyNearby)
                    friendState = FriendState.Parting;

                break;

            case FriendState.Parting:
                Parting();
                break;
        }
    }
    void Run()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Run", true);
        }
        else
        {
            direction = Vector3.zero;
            animator.SetBool("Run", false);
        }

        transform.rotation = PlayerMovement.instance.transform.rotation;
        controller.Move(direction * speed * Time.deltaTime);
    }
    public void InvokeJump()
    {
        isJump = true;
    }
    void Jump()
    {
        if (controller.isGrounded)
        {
            gravity = -0.1f;
            if (isJump)
            {
                gravity = jumpHeight;
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            isJump = false;
            gravity += gravityScale * Physics.gravity.y * Time.deltaTime;
        }
    }
    void Parting()
    {
        var looAt = badBoy.transform.position - transform.position;
        transform.forward = looAt;
        direction = Vector3.zero;
        animator.SetTrigger("Dance");
    }
    public void You—aught(GameObject badBoyObject)
    {
        isBadBoyNearby = true;
        badBoy = badBoyObject;
    }

}
