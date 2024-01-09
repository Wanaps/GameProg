using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidMovement : MonoBehaviour
{

    public float speed = 1.0f;
    void Start()
    {
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
        //movement event, force the rotation to be 0
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        transform.rotation = Quaternion.identity;
        if (gameObject == null)
        {
            Debug.Log("Asteroid Destroyed.");
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("FenceKiller")){
            // teleport to top and random x and reset orientation
            transform.position = new Vector3(UnityEngine.Random.Range(-11.5f, 11.5f), 5.0f, 0.0f);
            transform.rotation = Quaternion.identity;
        }
    }

    public void stop()
    {
        if (gameObject.name.Contains("Huge"))
        {
            speed = 0.0f;
        }
        else if (gameObject.name.Contains("Big"))
        {
            speed = 0.0f;
        }
        else if (gameObject.name.Contains("Med"))
        {
            speed = 0.0f;
        }
        else if (gameObject.name.Contains("Small"))
        {
            speed = 0.0f;
        }
    }
}
