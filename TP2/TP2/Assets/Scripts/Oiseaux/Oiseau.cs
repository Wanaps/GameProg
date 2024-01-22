using System;
using UnityEngine;

namespace Oiseaux
{
    public class Oiseau : MonoBehaviour
    {
        internal Rigidbody2D Rb;
        internal const float Speed = 8f;
        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : GetComponent<Rigidbody2D>();
            if (GetComponent<PolygonCollider2D>() == null)
            {
                PolygonCollider2D col = gameObject.AddComponent<PolygonCollider2D>();
                col.isTrigger = true;
            }
            Rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Rb.freezeRotation = true;
        }
    }
}