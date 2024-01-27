using System;
using System.Collections;
using System.Collections.Generic;
using Serpent;
using UnityEngine;
using Verger;
using Bombes;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class SpawnBombes : MonoBehaviour
    {
        public int maxBombes = 10;
        public static List<Bombe> Bombes = new List<Bombe>();

        public GameObject toSpawn;

        void Awake()
        {
            Debug.Log("SpawnBombes");
            Bombes = new List<Bombe>();
            Coroutine spawn = StartCoroutine(CheckBomes());
        }

        IEnumerator CheckBomes()
        {
            while (true)
            {
                yield return new WaitForSeconds(.1f);
                if (SpawnApple.Apples.Count <= 0)
                {
                    if (Bombes.Count > 0)
                    {
                        Die.AllDie(Bombes);
                    }

                    Spawn();
                }
            }
        }

        void Spawn()
        {
            for (int i = 0; i < maxBombes; i++)
            {
                var x = Random.Range(-8, 8);
                var y = Random.Range(-4, 4);

                if (!IsApple(x, y) || !IsPlayer(x, y))
                {
                    Bombes.Add(
                        Instantiate(toSpawn, new Vector3(x, y, 0),
                            Quaternion.identity).transform.GetComponent<Bombe>());
                }
                else
                {
                    i--;
                }
            }
        }

        private bool IsPlayer(int i, int i1)
        {
            if (Player.AllCorps.Count > 0)
            {
                foreach (var corps in Player.AllCorps)
                {
                    if (Math.Abs(corps.transform.position.x - i) < 1f && Math.Abs(corps.transform.position.y - i1) < 1f)
                    {
                        return true;
                    }

                    if (Player.Direction.x > 0)
                    {
                        if (Math.Abs(Player.AllCorps[^1].transform.position.x - i - Player.Speed * Player.FPS) < 5f &&
                            Math.Abs(Player.AllCorps[^1].transform.position.y - i1) < 1f)
                        {
                            return true;
                        }
                    }
                    else if (Player.Direction.x < 0)
                    {
                        if (Math.Abs(Player.AllCorps[^1].transform.position.x - i + Player.Speed * Player.FPS) < 5f &&
                            Math.Abs(Player.AllCorps[^1].transform.position.y - i1) < 1f)
                        {
                            return true;
                        }
                    }
                    else if (Player.Direction.y > 0)
                    {
                        if (Math.Abs(Player.AllCorps[^1].transform.position.x - i) < 1f &&
                            Math.Abs(Player.AllCorps[^1].transform.position.y - i1 - Player.Speed * Player.FPS) < 5f)
                        {
                            return true;
                        }
                    }
                    else if (Player.Direction.y < 0)
                    {
                        if (Math.Abs(Player.AllCorps[^1].transform.position.x - i) < 1f &&
                            Math.Abs(Player.AllCorps[^1].transform.position.y - i1 + Player.Speed * Player.FPS) < 5f)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool IsApple(float f, float f1)
        {
            if (SpawnApple.Apples.Count > 0)
            {
                foreach (var apple in SpawnApple.Apples)
                {
                    if (Math.Abs(apple.transform.position.x - f) < 0.5f &&
                        Math.Abs(apple.transform.position.y - f1) < 0.5f)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}