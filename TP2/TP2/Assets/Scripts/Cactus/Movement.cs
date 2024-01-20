using UnityEngine;

namespace Cactus
{
    public class Movement : MonoBehaviour
    {
        
        public float speed = 5f;
        private Rigidbody2D _rb;
        private PolygonCollider2D _pc;
        
        void Start()
        {
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.AddComponent<PolygonCollider2D>();
            _rb = GetComponent<Rigidbody2D>();
            _pc = GetComponent<PolygonCollider2D>();
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        void Update()
        {
            Move();
        }
        
        private void Move()
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
        }
    }
}
