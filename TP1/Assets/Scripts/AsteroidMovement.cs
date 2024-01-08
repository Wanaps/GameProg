using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    void Update()
    {
        //movement event
        transform.Translate(Vector3.down * Time.deltaTime * 5);

        //destroy event
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }
}
