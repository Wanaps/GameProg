using UnityEngine;

namespace Coin
{
    public class Score : Coin
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                Spawner.Score += 5;
            } else if (transform.position.x > 9 && (other.CompareTag("Cactus") || other.CompareTag("Oiseau")))
            {
                Destroy(gameObject);
            }
        }
    }
}