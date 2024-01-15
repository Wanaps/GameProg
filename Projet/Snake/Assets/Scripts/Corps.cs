using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corps : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : gameObject.GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    
    public void Move(Vector3 pos)
    {
        transform.position = pos;
    }
}
