using System;
using UnityEngine;

namespace Dino
{
    public class Die : Dino
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Cactus") || other.gameObject.CompareTag("Oiseau"))
            {
                Destroy(gameObject);
                isAlive = false;
                
            }
        }
    }
}