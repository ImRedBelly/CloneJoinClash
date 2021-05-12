using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : CharacterMovement
{
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        InputController();
        Jump();


        controller.Move(direction * speed * Time.deltaTime);
    }
}







