using System.Collections;
using System.Collections.Generic;
using System.IO;
using Serpent;
using UnityEngine;

namespace Verger
{

    public class Spawn_apple : MonoBehaviour
    {

        public int max_apples = 10;
        public static List<Apple> apples = new List<Apple>();

        public GameObject toSpawn;

        void Awake()
        {
            Debug.Log("Spawn_apple");
            apples = new List<Apple>();
            Coroutine spawn = StartCoroutine(Check_apple());
        }

        IEnumerator Check_apple()
        {
            while (true)
            {
                yield return new WaitForSeconds(.1f);
                if (apples.Count <= 0)
                {
                    Spawn();
                }
            }
        }

        void Spawn()
        {
            for (int i = 0; i < max_apples; i++)
            {
                apples.Add(
                    Instantiate(toSpawn, new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0),
                        Quaternion.identity).transform.GetComponent<Apple>());
            }
            Player.FPS += 2;
            Debug.Log(Player.FPS);
        }
    }
}