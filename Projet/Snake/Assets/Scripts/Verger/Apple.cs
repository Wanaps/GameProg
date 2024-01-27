using System;
using System.Collections;
using System.Collections.Generic;
using Serpent;
using Spawners;
using UnityEngine;

namespace Verger
{

    public class Apple : MonoBehaviour
    {

        Rigidbody2D _rd = new Rigidbody2D();
        PolygonCollider2D _pc = new PolygonCollider2D();
        public Player player;

        void Start()
        {
            _rd = gameObject.GetComponent<Rigidbody2D>() == null
                ? gameObject.AddComponent<Rigidbody2D>()
                : gameObject.GetComponent<Rigidbody2D>();
            _rd.gravityScale = 0;
            _rd.constraints = RigidbodyConstraints2D.FreezeRotation;
            _pc = gameObject.GetComponent<PolygonCollider2D>() == null
                ? gameObject.AddComponent<PolygonCollider2D>()
                : gameObject.GetComponent<PolygonCollider2D>();
            _pc.isTrigger = true;

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                player.Eat();
                SpawnApple.Apples.Remove(this);
            }
        }
    }
}
