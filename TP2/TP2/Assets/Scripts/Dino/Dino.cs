using UnityEngine;

namespace Dino
{
    public class Dino : MonoBehaviour
    {
        public float speed = 5f;
        internal Rigidbody2D Rb;
        
        void Start()
        {
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.AddComponent<PolygonCollider2D>();
            Rb = GetComponent<Rigidbody2D>();
            Rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Rb.freezeRotation = true;
            Rb.gravityScale = 5;
        }
    }
}