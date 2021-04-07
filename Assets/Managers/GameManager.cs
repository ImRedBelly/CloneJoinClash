using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [Header("Poeple")]
    public List<GameObject> friends;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void AddFriend(GameObject friend)
    {
        friends.Add(friend);
    }
    public void RemoveFriend(GameObject friend)
    {
        friends.Remove(friend);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (friends.Count == 0)
            {
                print("You Lose");
            }
            else
            {
                print("You Win");
            }
        }
    }
}
