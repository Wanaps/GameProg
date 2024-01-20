using System;
using UnityEngine;

namespace Cactus
{
    public class Die : MonoBehaviour
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
