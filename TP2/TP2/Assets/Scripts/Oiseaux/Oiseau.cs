using System;
using UnityEngine;

namespace Oiseaux
{
    public class Oiseau : MonoBehaviour
    {
        internal Rigidbody2D Rb;
        internal float Speed;
        private void Start()
        {
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.AddComponent<PolygonCollider2D>();
            Rb = GetComponent<Rigidbody2D>();
            Rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Rb.freezeRotation = true;
        }
    }
}