using System.Collections;
using System.Collections.Generic;
using Serpent;
using UnityEngine;

public class Border : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.Die(Player.AllCorps);
        }
    }
}
