using UnityEngine;

namespace Dino
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
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            _rb.freezeRotation = true;
            _rb.gravityScale = 5;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _rb.velocity.y == 0)
            {
                Jump();
            }
        }

        private void Jump()
        {
            _rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
        }
    }
}