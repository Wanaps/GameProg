using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEdgeCollision : MonoBehaviour
{
    private void Awake()
    {
        //Debug.Log("CameraEdgeCollision Awake");
        AddColliderOnCamera();
    }

    public void AddColliderOnCamera()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Camera.main not found, failed to add 'CameraEdgeCollision' script");
            return;
        }
        
        Camera cam = Camera.main;
        
        if (!cam.orthographic)
        {
            Debug.LogError("Camera.main is not Orthographic, failed to add 'CameraEdgeCollision' script");
            return;
        }
        
        var edgeCollider = gameObject.GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : gameObject.GetComponent<EdgeCollider2D>();
        edgeCollider.isTrigger = true;
        
        var bottomLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var topLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        var topRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        var bottomRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));
        
        var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
        
        edgeCollider.points = edgePoints;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("ship"))
        {
            //Move back
            Debug.Log("Collided with Camera Edge.");
            other.gameObject.GetComponent<Rigidbody2D>().velocity = -other.gameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }
}