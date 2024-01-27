using System.Collections;
using System.Collections.Generic;
using Serpent;
using Spawners;
using UnityEngine;
using Walls;

namespace Map
{
    public class Border : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Player.Die(Player.AllCorps);
            }
            if (other.gameObject.CompareTag("Wall"))
            {
                foreach (var wall in SpawnWalls.VerticalWalls)
                {
                    if (wall.gameObject == other.gameObject)
                    {
                        wall.Direction *= -1;
                        return;
                    }
                }

                foreach (var wall in SpawnWalls.HorizontalWalls)
                {
                    if (wall.gameObject == other.gameObject)
                    {
                        wall.Direction *= -1;
                        return;
                    }
                }
            }
        }
    }
}