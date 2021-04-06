using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BadBoy : MonoBehaviour
{
    public CharacterController controller;
    public GameObject searchPoint;
    public LayerMask girlMask;
    public Animator animator;
    public float speed;

    GameObject emptyGirl;
    private void Update()
    {
        RaycastHit hit;
        if ((Physics.Raycast(searchPoint.transform.position, searchPoint.transform.forward, out hit, 50, girlMask)) && emptyGirl == null)
        {
            if (hit.collider.gameObject.CompareTag("ClonePlayer"))
            {
                emptyGirl = hit.collider.gameObject;
                emptyGirl.SendMessage("You—aught", gameObject);
            }
        }

        if (emptyGirl)
        {
            var heading = emptyGirl.transform.position - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;

            transform.forward = heading;

            if (distance < 7)
            {
                animator.SetTrigger("Dance");
                controller.Move(Vector3.zero);
                return;
            }

            animator.SetBool("Run", true);
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
