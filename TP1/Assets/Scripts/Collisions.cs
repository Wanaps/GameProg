using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisions : MonoBehaviour
{
    private Text lostText;
    public float moveBackSpeed = 1.0f; // Vitesse de recul
    private Rigidbody2D rb;
    public float maxDistance = 0.001f; // Distance maximale entre le vaisseau et le bord de l'écran

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided.");
        Destroy(gameObject);
        lostText = GameObject.Find("LostText").GetComponent<Text>();
        lostText.text = "You Lost!";
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Physics.Raycast(transform.position, transform.up, maxDistance))
        {
            // nothing in front, move forward
            rb.velocity = -transform.up * moveBackSpeed;
        } 
        if (Physics.Raycast( transform.position, -transform.up, maxDistance))
        {
            // something behind, move forward
            rb.velocity = transform.up * moveBackSpeed;
        } 
        if (Physics.Raycast( transform.position, transform.right, maxDistance))
        {
            // something on the right, move left
            rb.velocity = -transform.right * moveBackSpeed;
        } 
        if (Physics.Raycast( transform.position, -transform.right, maxDistance))
        {
            // something on the left, move right
            rb.velocity = transform.right * moveBackSpeed;
        }
        if (Physics.Raycast( transform.position, transform.up + transform.right, maxDistance))
        {
            // something on the right, move left
            rb.velocity = -(transform.up + transform.right) * moveBackSpeed;
        }
        if (Physics.Raycast( transform.position, transform.up - transform.right, maxDistance))
        {
            // something on the left, move right
            rb.velocity = -(transform.up - transform.right) * moveBackSpeed;
        }
        if (Physics.Raycast( transform.position, -transform.up + transform.right, maxDistance))
        {
            // something on the right, move left
            rb.velocity = -(-transform.up + transform.right) * moveBackSpeed;
        }
        if (Physics.Raycast( transform.position, -transform.up - transform.right, maxDistance))
        {
            // something on the left, move right
            rb.velocity = -(-transform.up - transform.right) * moveBackSpeed;
        }
    }
}