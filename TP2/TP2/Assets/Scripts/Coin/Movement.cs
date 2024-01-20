using UnityEngine;

namespace Coin
{
    public class Movement : Coin
    {
        void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position += Vector3.left * (Speed * Time.deltaTime);
        }
    }
}