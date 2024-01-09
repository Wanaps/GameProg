using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisions : MonoBehaviour
{
    private Text lostText;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided.");
        Destroy(gameObject);
        lostText = GameObject.Find("LostText").GetComponent<Text>();
        lostText.text = "You Lost!";
    }
}
