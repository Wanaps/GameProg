using System;
using UnityEngine;

namespace Oiseaux
{
    public class Oiseau : MonoBehaviour
    {
        internal Rigidbody2D Rb;
        internal float Speed;
        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : GetComponent<Rigidbody2D>();
            if (GetComponent<PolygonCollider2D>() == null)
            {
                gameObject.AddComponent<PolygonCollider2D>();
            }
            Rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Rb.freezeRotation = true;
        }
    }
}