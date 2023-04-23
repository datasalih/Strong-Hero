using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public float yDistance;
    public float zDistance; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button is clicked
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + yDistance, transform.position.z + zDistance); // Move the camera up and forward
        }
    }
}
