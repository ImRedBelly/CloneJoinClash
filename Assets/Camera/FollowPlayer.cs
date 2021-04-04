using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.transform.position.y + 35, target.transform.position.z - 25);
    }
}
