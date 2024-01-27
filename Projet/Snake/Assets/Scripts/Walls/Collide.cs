using Serpent;
using Spawners;
using UnityEngine;

namespace Walls
{
    public class Collide : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
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