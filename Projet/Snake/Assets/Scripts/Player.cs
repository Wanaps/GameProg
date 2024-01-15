using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int score = 0;
    private Rigidbody2D _rb;
    private string _dir = "down";
    public float speed = 10.0f;
    public GameObject corps;
    List<corps> all_corps = new List<corps>();
    Queue<Vector2> positions = new Queue<Vector2>();
    void Start()
    {
        Vector3 pos = transform.position;
        pos.x = 0;
        pos.y = 0;  
        _rb = gameObject.GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : gameObject.GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    
    
        
    void Update()
    {
        checkPressed();
        move();
        move_corps();
    }

    private void move_corps()
    {
        positions.Enqueue(transform.position);

        if (positions.Count > all_corps.Count) {
            positions.Dequeue();
        }
        for (int i = 0; i < ((ICollection)all_corps).Count; i++) {
            all_corps[i].Move(positions.ElementAt(all_corps.Count - i - 1));
        }
    }

    private void move()
    {
        if (_dir == "down")
        {
            _rb.velocity = new Vector2(0, -speed);
        } else if (_dir == "up")
        {
            _rb.velocity = new Vector2(0, speed);
        } else if (_dir == "left")
        {
            _rb.velocity = new Vector2(-speed, 0);
        } else if (_dir == "right")
        {
            _rb.velocity = new Vector2(speed, 0);
        }
    }

    private void checkPressed()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _dir = "down";
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _dir = "up";
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _dir = "left";
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _dir = "right";
        }
    }

    public void Eat()
    {
        speed += 0.5f;
        all_corps.Add(Instantiate(corps, transform.position, Quaternion.identity).transform.GetComponent<corps>());
        score++;
    }

    public void Die()
    {
        SceneManager.LoadScene("Lose");
        Destroy(this);
    }
}
