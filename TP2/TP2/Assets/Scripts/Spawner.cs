using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<GameObject> _obstacles;
    public GameObject cactus;
    public GameObject dino;
    private float _timer = 0f;
    private float _spawnTime = 1f;
    
    void Start()
    {
        _obstacles = new List<GameObject>();
        Instantiate(dino, new Vector3(-5, 1, 0), Quaternion.identity);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _spawnTime)
        {
            Spawn();
            _timer = 0f;
        }
    }
    
    private void Spawn()
    {
        var random = Random.Range(0, 2);
        if (random == 0)
        {
            _obstacles.Add(Instantiate(cactus, new Vector3(10, 0, 0), Quaternion.identity));
        }
    }
}
