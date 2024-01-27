using Serpent;
using Spawners;
using UnityEngine;

namespace GoldApple
{
    public class GoldApple : MonoBehaviour
    {
        internal Rigidbody2D Rd = new Rigidbody2D();
        internal PolygonCollider2D Pc = new PolygonCollider2D();
        internal int Direction = 1;
        public Player player;

        void Start()
        {
            Rd = gameObject.GetComponent<Rigidbody2D>() == null
                ? gameObject.AddComponent<Rigidbody2D>()
                : gameObject.GetComponent<Rigidbody2D>();
            Rd.gravityScale = 0;
            Rd.constraints = RigidbodyConstraints2D.FreezeRotation;
            Pc = gameObject.GetComponent<PolygonCollider2D>() == null
                ? gameObject.AddComponent<PolygonCollider2D>()
                : gameObject.GetComponent<PolygonCollider2D>();
            Pc.isTrigger = true;
            tag = "GoldApple";
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                SpawnGoldApples.GoldApples.Remove(this);
                Destroy(gameObject);
                player.Eat();
                Player.Score += 4;
            }
        }
    }
}