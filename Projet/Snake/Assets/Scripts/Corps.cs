using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serpent
{
    public class Corps : MonoBehaviour
    {
        private Rigidbody2D _rb;
        
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
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public void Move(Vector3 pos)
        {
            transform.position = pos;
        }
    }
}
