using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    void Update()
    {
        // Rotation every second
        transform.Rotate(xAngle, yAngle, zAngle, Space.Self);      
    }

    void OnCollisionEnter(Collision other) 
    {
        
    }
}
