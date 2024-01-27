using UnityEngine;

namespace Walls
{
    public class VerticalWall : MonoBehaviour
    {
        internal Rigidbody2D Rd;
        internal BoxCollider2D Bc;
        internal int Direction;

        void Awake()
        {
            Rd = gameObject.GetComponent<Rigidbody2D>() == null
                ? gameObject.AddComponent<Rigidbody2D>()
                : gameObject.GetComponent<Rigidbody2D>();
            Rd.gravityScale = 0;
            Rd.freezeRotation = true;
            Rd.constraints = RigidbodyConstraints2D.FreezeAll;
            Bc = gameObject.GetComponent<BoxCollider2D>() == null
                ? gameObject.AddComponent<BoxCollider2D>()
                : gameObject.GetComponent<BoxCollider2D>();
            Direction = 1;
            tag = "Wall";
        }
    }
}