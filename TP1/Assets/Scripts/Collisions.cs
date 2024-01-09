using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collisions : MonoBehaviour
{
    private Text lostText;
    public float moveBackSpeed = 1.0f; // Vitesse de recul
    private Rigidbody2D rb;
    public float maxDistance = 0.001f; // Distance maximale entre le vaisseau et le bord de l'écran

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided !");
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}