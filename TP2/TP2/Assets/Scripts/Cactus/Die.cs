using System;
using UnityEngine;

namespace Cactus
{
    public class Die : Cactus
    {
        private void Update()
        {
            if (transform.position.x < -10)
            {
                Destroy(gameObject);
            }
        }
    }
}
