using UnityEngine;

namespace Serpent
{
    public class Corps : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Player _player;

        public Corps(float x, float y)
        {
            transform.position = new Vector3(x, y, 0);
        }

        void Start()
        {
            _rb = gameObject.GetComponent<Rigidbody2D>() == null
                ? gameObject.AddComponent<Rigidbody2D>()
                : gameObject.GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0;
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public void Move(Vector3 pos)
        {
            transform.position = pos;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && !gameObject.CompareTag("Player") && Player.AllCorps.Count > 4)
            {
                if (other.gameObject.GetComponent<Corps>() == Player.AllCorps[^1].gameObject.GetComponent<Corps>() &&
                    this != Player.AllCorps[^2].gameObject.GetComponent<Corps>() &&
                    this != Player.AllCorps[0].gameObject.GetComponent<Corps>())
                {
                    Debug.Log("Player Die by collision");
                    Player.Die(Player.AllCorps);
                }
            }
        }
    }
}