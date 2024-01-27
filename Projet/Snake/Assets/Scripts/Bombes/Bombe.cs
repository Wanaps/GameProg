using Serpent;
using UnityEngine;

namespace Bombes
{
    public class Bombe : MonoBehaviour
    {
        internal Rigidbody2D Rd;
        internal PolygonCollider2D Pc;

        private void Awake()
        {
            Rd = gameObject.GetComponent<Rigidbody2D>() == null
                ? gameObject.AddComponent<Rigidbody2D>()
                : gameObject.GetComponent<Rigidbody2D>();
            Pc = gameObject.GetComponent<PolygonCollider2D>() == null
                ? gameObject.AddComponent<PolygonCollider2D>()
                : gameObject.GetComponent<PolygonCollider2D>();

            Rd.gravityScale = 0;
            Rd.constraints = RigidbodyConstraints2D.FreezeRotation;

            Pc.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Player.Die(Player.AllCorps);
                Die.AllDie(Spawners.SpawnBombes.Bombes);
            }
        }
    }
}