using UnityEngine;

namespace Cactus
{
    public class Movement : Cactus
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
