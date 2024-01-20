using UnityEngine;

namespace Cactus
{
    public class Cactus : MonoBehaviour
    {
        internal Rigidbody2D Rb;
        internal const float Speed = 5f;

        void Awake()
        {   
            Rb = gameObject.GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : gameObject.GetComponent<Rigidbody2D>();
            if (gameObject.GetComponent<PolygonCollider2D>() == null)
            {
                gameObject.AddComponent<PolygonCollider2D>();
            }
            Rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}