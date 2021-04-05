using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trampoline : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement.instance.isJump = true;
        }
        if (other.gameObject.CompareTag("ClonePlayer"))
        {
            other.GetComponent<Friend>().isJump = true;
        }
    }
}
