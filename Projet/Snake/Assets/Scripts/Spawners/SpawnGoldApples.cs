using System;
using System.Collections;
using System.Collections.Generic;
using GoldApple;
using Serpent;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class SpawnGoldApples : MonoBehaviour
    {
        public int maxApples = 1;
        public static List<GoldApple.GoldApple> GoldApples = new List<GoldApple.GoldApple>();

        public GameObject toSpawn;

        void Awake()
        {
            Debug.Log("Spawn gold apple");
            GoldApples = new List<GoldApple.GoldApple>();
            StartCoroutine(Check_apple());
        }

        IEnumerator Check_apple()
        {
            while (true)
            {
                yield return new WaitForSeconds(.1f);
                if (Player.Score % 20 == 0 && Player.Score != 0 && GoldApples.Count <= maxApples)
                {
                    Spawn();
                }
            }
        }
        private void Update()
        {
            foreach (var ga in GoldApples)
            {
                if (ga.Direction == 1)
                {
                    Movement.Move(Vector2.up * (Time.deltaTime * 5), ga.Rd);
                } else if (ga.Direction == -1) {
                    Movement.Move(Vector2.down * (Time.deltaTime * 5), ga.Rd);
                }
                else if (ga.Direction == 2)
                {
                    Movement.Move(Vector2.right * (Time.deltaTime * 5), ga.Rd);
                } else
                {
                    Movement.Move(Vector2.left * (Time.deltaTime * 5), ga.Rd);
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
                    GoldApples.Add(
                        Instantiate(toSpawn, new Vector3(x, y, 0),
                            Quaternion.identity).transform.GetComponent<GoldApple.GoldApple>());
                    GoldApples[^1].Direction = Random.Range(1, 2);
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