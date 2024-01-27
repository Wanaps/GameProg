using Serpent;
using Spawners;
using UnityEngine;

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

            if (other.gameObject.CompareTag("GoldApple"))
            {
                foreach (var ga in SpawnGoldApples.GoldApples)
                {
                    if (ga.gameObject == other.gameObject)
                    {
                        ga.Direction *= -1;
                        return;
                    }
                }
            }
        }
    }
}