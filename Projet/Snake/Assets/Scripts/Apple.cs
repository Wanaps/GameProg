using System;
using System.Collections;
using System.Collections.Generic;
using Serpent;
using UnityEngine;

public class Apple : MonoBehaviour
{
    
    Rigidbody2D rd = new Rigidbody2D();
    PolygonCollider2D pc = new PolygonCollider2D();
    public Player player;
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : gameObject.GetComponent<Rigidbody2D>();
        rd.gravityScale = 0;
        rd.constraints = RigidbodyConstraints2D.FreezeRotation;
        pc = gameObject.GetComponent<PolygonCollider2D>() == null ? gameObject.AddComponent<PolygonCollider2D>() : gameObject.GetComponent<PolygonCollider2D>();
        pc.isTrigger = true;
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            player.Eat();
        }
    }
}
