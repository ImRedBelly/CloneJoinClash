using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendMovement : CharacterMovement
{
    public LayerMask player;
    public string playerMask;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

    }
    private void Update()
    {
        bool isPlayerNearby = Physics.CheckSphere(transform.position, 10, player);
        if (isPlayerNearby)
        {
            InputController();
            Jump();

            gameObject.layer = LayerMask.NameToLayer(playerMask);
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
