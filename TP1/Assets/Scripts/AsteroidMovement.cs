using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidMovement : MonoBehaviour
{

    public float speed = 1.0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (gameObject.name.Contains("Huge"))
        {
            speed = 2.0f;
        }
        else if (gameObject.name.Contains("Big"))
        {
            speed = 4.0f;
        }
        else if (gameObject.name.Contains("Med"))
        {
            speed = 5.0f;
        }
        else if (gameObject.name.Contains("Small"))
        {
            speed = 7.0f;
        }
        Debug.Log(gameObject.name + "Asteroid Spawned With Speed: " + speed + ".");
    }

    void Update()
    {
        rb.velocity = -transform.up * speed;
        
        if (gameObject == null)
        {
            Debug.Log("Asteroid Destroyed.");
        }

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("FenceKiller")){
            // teleport to top and random x and reset orientation
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0.0f;
            transform.position = new Vector3(UnityEngine.Random.Range(-8.0f, 8.0f), 8.0f, 0.0f);
            transform.rotation = Quaternion.identity;
        }
    }
}
