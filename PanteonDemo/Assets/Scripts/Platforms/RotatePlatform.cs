using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float Speed;
    public float AngularSpeed;
    public int rotationDirection;

    private Rigidbody platformRigidBody;
    
    void Start()
    {
        platformRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0.0f, 1f);
    }
}
