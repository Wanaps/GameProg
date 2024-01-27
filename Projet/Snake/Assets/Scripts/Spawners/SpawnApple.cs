using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Serpent;
using UnityEngine;
using UnityEngine.Serialization;
using Verger;
using Random = UnityEngine.Random;

namespace Spawners
{

    public class SpawnApple : MonoBehaviour
    {

        [FormerlySerializedAs("max_apples")] public int maxApples = 10;
        public static List<Apple> Apples = new List<Apple>();

        public GameObject toSpawn;

        void Awake()
        {
            Debug.Log("Spawn_apple");
            Apples = new List<Apple>();
            Coroutine spawn = StartCoroutine(Check_apple());
        }

        IEnumerator Check_apple()
        {
            while (true)
            {
                yield return new WaitForSeconds(.1f);
                if (Apples.Count <= 0)
                {
                    Spawn();
                }
            }
        }

        void Spawn()
        {
            for (int i = 0; i < maxApples; i++)
            {
                var x = Random.Range(-8, 8);
                var y = Random.Range(-4, 4);
                if (!IsBombe(x, y))
                {
                    Apples.Add(
                        Instantiate(toSpawn, new Vector3(x, y, 0),
                            Quaternion.identity).transform.GetComponent<Apple>());
                }
                else
                {
                    i--;
                }
            }
            Player.FPS += 2;
            Debug.Log(Player.FPS);
        }

        private bool IsBombe(int i, int i1)
        {
            foreach (var bombe in SpawnBombes.Bombes)
            {
                if (Math.Abs(bombe.transform.position.x - i) < 1f && Math.Abs(bombe.transform.position.y - i1) < 1f)
                {
                    return true;
                }
            }
            return false;
        }
    }
}