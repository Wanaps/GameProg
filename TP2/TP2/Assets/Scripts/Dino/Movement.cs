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
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _pc.IsTouchingLayers(LayerMask.GetMask("Floor")))
            {
                Jump();
            }
        }

        private void Jump()
        {
            _rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
        
        
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                Debug.Log("Game Over");
            } else if (collision.gameObject.tag == "Floor")
            {
                Debug.Log("Floor");
            }
        }
    }
}