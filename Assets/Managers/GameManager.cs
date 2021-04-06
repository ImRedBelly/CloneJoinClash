using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [Header("Poeple")]
    public List<GameObject> friends;
    public List<GameObject> badBoys;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void AddFriend(GameObject friend)
    {
        friends.Add(friend);
    }
    public void AddBadBoy(GameObject badBoy)
    {
        badBoys.Add(badBoy);
    }
}
