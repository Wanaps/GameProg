using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<GameObject> _obstacles;
    public GameObject cactus;
    public GameObject dino;
    public GameObject oiseau;
    public GameObject coin;
    private float _timer = 0f;
    private float _spawnTime = 1f;
    internal static int Score = 0;
    
    void Start()
    {
        _obstacles = new List<GameObject>();
        Instantiate(dino, new Vector3(-5, 1, 0), Quaternion.identity);
        Score = 0;
    }

    void Update()
    {
        setSpawnTime();
        _timer += Time.deltaTime;
        if (_timer > _spawnTime)
        {
            SpawnCoin();
            SpawnCactus();
            if (Score > 50)
            {
                SpawnOiseau();
            }
            _timer = 0f;
        }
        if (_timer % 2 == 0)
        {
            Score++;
        }
    }

    private void SpawnCoin()
    {
        var random = Random.Range(0, 4);
        if (random == 0)
        {
            _obstacles.Add(Instantiate(coin, new Vector3(10, Random.Range(0.5f, 2), 0), Quaternion.identity));
        }
    }

    private void SpawnOiseau()
    {
        var random = Random.Range(0, 4);
        if (random == 0)
        {
            _obstacles.Add(Instantiate(oiseau, new Vector3(10, Random.Range(0.5f, 2), 0), Quaternion.identity));
        }
    }

    private void SpawnCactus()
    {
        var random = Random.Range(0, 2);
        if (random == 0)
        {
            _obstacles.Add(Instantiate(cactus, new Vector3(10, 0, 0), Quaternion.identity));
        }
    }
    
    private void setSpawnTime()
    {
        _spawnTime = Random.Range(0.7f, 2f);
    }
}
