using System;
using UnityEngine;

namespace Coin
{
    public class Coin : MonoBehaviour
    {
        internal Rigidbody2D Rb;
        internal const float Speed = 5f;
        internal CircleCollider2D Collider;
        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : GetComponent<Rigidbody2D>();
            Rb.freezeRotation = true;
            Rb.gravityScale = 0;
            Collider = GetComponent<CircleCollider2D>() == null ? gameObject.AddComponent<CircleCollider2D>() : GetComponent<CircleCollider2D>();
            Collider.isTrigger = true;
        }
    }
}