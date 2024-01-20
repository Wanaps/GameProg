using UnityEngine;

namespace Cactus
{
    public class Cactus : MonoBehaviour
    {
        internal Rigidbody2D Rb;
        internal const float Speed = 5f;

        void Start()
        {
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.AddComponent<PolygonCollider2D>();
            Rb = GetComponent<Rigidbody2D>();
            Rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}