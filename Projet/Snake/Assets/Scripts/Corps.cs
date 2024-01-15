using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serpent
{
    public class corps : MonoBehaviour
    {
        private Rigidbody2D _rb;

        void Start()
        {
            _rb = gameObject.GetComponent<Rigidbody2D>() == null
                ? gameObject.AddComponent<Rigidbody2D>()
                : gameObject.GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public void Move(Vector3 pos, Player.Direction direction)
        {
            switch (direction)
            {
                case Player.Direction.Up:
                    pos.y += Player.speed;
                    break;
                case Player.Direction.Down:
                    pos.y -= Player.speed;
                    break;
                case Player.Direction.Right:
                    pos.x += Player.speed;
                    break;
                case Player.Direction.Left:
                    pos.x -= Player.speed;
                    break;
            }

            transform.position = pos;
        }
    }
}
