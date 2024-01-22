using UnityEngine;

public class Spawn_Player : MonoBehaviour
{
    public GameObject player;
    public GameObject corps;

    void Awake()
    {
        Instantiate(player);
    }
}