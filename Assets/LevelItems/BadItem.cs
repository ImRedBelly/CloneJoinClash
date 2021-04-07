using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
        if (other.gameObject.CompareTag("ClonePlayer"))
        {
            StartCoroutine(other.GetComponent<Friend>().Dead(0.1f));
        }
    }
}
