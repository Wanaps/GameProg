﻿using System;
using UnityEngine;

namespace Dino
{
    public class Die : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Cactus"))
            {
                Destroy(gameObject);
                // Game Over load scene
                
            }
        }
    }
}