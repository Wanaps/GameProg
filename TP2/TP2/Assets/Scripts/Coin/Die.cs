using System;
using UnityEngine;

namespace Coin
{
    public class Die : Coin
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