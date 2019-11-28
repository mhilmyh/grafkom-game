using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float speed = 3;
    public Transform target;
    public Camera cam;
    private Vector3 direction;
    private Quaternion look;

    void LateUpdate()
    {
        direction = (target.position - cam.transform.position).normalized;
        look = Quaternion.LookRotation(direction);
        look.x = transform.rotation.x;
        look.z = transform.rotation.z;
        transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * 100);
        transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * speed);
    }
}
