using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene(MenuScene);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Oiseau"))
            {
                Destroy(gameObject);
                isAlive = false;
                SceneManager.LoadScene(MenuScene);
            }
        }
    }
}