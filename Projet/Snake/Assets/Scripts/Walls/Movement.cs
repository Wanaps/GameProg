using UnityEngine;

namespace Walls
{
    public class Movement : MonoBehaviour
    {
        internal static void Move(Vector2 direction, Rigidbody2D Rigid)
        {
            Rigid.transform.Translate(direction);
        }
    }
}