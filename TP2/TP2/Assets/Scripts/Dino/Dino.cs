using UnityEngine;

namespace Dino
{
    public class Dino : MonoBehaviour
    {
        public float speed = 5f;
        internal Rigidbody2D Rb;
        
        void Awake()
        {
            Rb = GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : gameObject.GetComponent<Rigidbody2D>();
            
            if (GetComponent<PolygonCollider2D>() == null)
            {
                gameObject.AddComponent<PolygonCollider2D>();
            }
            Rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Rb.freezeRotation = true;
            Rb.gravityScale = 5;
        }
    }
}