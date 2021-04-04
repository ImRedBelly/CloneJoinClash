using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Transform endPoint;
    public float speed;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float positionMouseX = Input.mousePosition.x;


        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -100, 0), Time.deltaTime * 1.5f);
        //    StopAllCoroutines();
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 100, 0), Time.deltaTime * 1.5f);
        //    StopAllCoroutines();
        //}

        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.A)))
        {

        }


        if (Input.GetMouseButton(0))
        {
            rb.velocity = transform.forward * speed;
            animator.SetBool("Run", true);

            if (positionMouseX < Screen.width / 3)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -100, 0), Time.deltaTime * 1.5f);
                StartCoroutine(RunStraight());
            }
            else if (positionMouseX > (Screen.width / 3) * 2)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 100, 0), Time.deltaTime * 1.5f);
                StartCoroutine(RunStraight());
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Run", false);
            rb.velocity = Vector3.zero;
        }
    }
    IEnumerator RunStraight()
    {
        yield return new WaitForSeconds(1);

        while (transform.rotation.y != 0)
        {
            yield return new WaitForSeconds(0.01f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 2);
        }
    }
}
