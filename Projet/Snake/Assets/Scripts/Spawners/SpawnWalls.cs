using System;
using System.Collections.Generic;
using Serpent;
using UnityEngine;
using UnityEngine.Serialization;
using Walls;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class SpawnWalls : MonoBehaviour
    {
        [FormerlySerializedAs("maxWalls")] public int maxVerticalWalls = 5;
        public static List<VerticalWall> VerticalWalls = new List<VerticalWall>();

        public int maxHorizontalWalls = 5;
        public static List<HorizontalWall> HorizontalWalls = new List<HorizontalWall>();

        public GameObject toSpawnVertical;
        public GameObject toSpawnHorizontal;

        void Awake()
        {
            Debug.Log("SpawnWalls");
            VerticalWalls = new List<VerticalWall>();
            HorizontalWalls = new List<HorizontalWall>();
            Spawn();
        }

        private void Update()
        {
            foreach (var wall in VerticalWalls)
            {
                if (wall.Direction == 1)
                {
                    Movement.Move(Vector2.up * Time.deltaTime, wall.Rd);
                } else {
                    Movement.Move(Vector2.down * Time.deltaTime, wall.Rd);
                }
            }
            foreach (var wall in HorizontalWalls)
            {
                if (wall.Direction == 1)
                {
                    Movement.Move(Vector2.right * Time.deltaTime, wall.Rd);
                } else {
                    Movement.Move(Vector2.left * Time.deltaTime, wall.Rd);
                }
            }
        }

        void Spawn()
        {
            for (int i = 0; i < maxVerticalWalls; i++)
            {
                var x = Random.Range(-8, 8);
                var y = Random.Range(-4, 4);


                if (!IsPlayer(x, y))
                {
                    VerticalWalls.Add(
                        Instantiate(toSpawnVertical, new Vector3(x, y, 0),
                            Quaternion.identity).transform.GetComponent<VerticalWall>());
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < maxHorizontalWalls; i++)
            {
                var x = Random.Range(-8, 8);
                var y = Random.Range(-4, 4);

                if (x == 0 && y == 0)
                {
                    i--;
                    continue;
                }

                if (!IsPlayer(x, y))
                {
                    HorizontalWalls.Add(
                        Instantiate(toSpawnHorizontal, new Vector3(x, y, 0),
                            Quaternion.identity).transform.GetComponent<HorizontalWall>());
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
    }
}