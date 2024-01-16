using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Spawn_apple : MonoBehaviour
{
    
    public int max_apples = 10;
    public List<Apple> apples = new List<Apple>();

    public GameObject toSpawn;
    void Start()
    {
        Coroutine spawn = StartCoroutine(Check_apple());
    }

    IEnumerator Check_apple()
    {
        yield return new WaitForSeconds(1);
        if (apples.Count <= 0)
        {
            Spawn();
        }
    }
    
    void Spawn()
    {
        for(int i = 0; i < max_apples; i++)
        {
            apples.Add(
            Instantiate(toSpawn, new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0),
                Quaternion.identity).transform.GetComponent<Apple>());
        }
    }
}
