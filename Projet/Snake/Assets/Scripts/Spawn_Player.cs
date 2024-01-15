using System.Collections;
using System.Collections.Generic;
using Serpent;
using UnityEngine;

public class Spawn_Player : MonoBehaviour
{
    public GameObject player;
    public GameObject corps;

    void Start()
    {
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        for (int i = 0; i < 3; i++)
        {
            Player.all_corps.Add(Instantiate(corps, new Vector3(0.4f * i + 0.01f, 0, 0), Quaternion.identity).transform.GetComponent<corps>());
        }
    }
}