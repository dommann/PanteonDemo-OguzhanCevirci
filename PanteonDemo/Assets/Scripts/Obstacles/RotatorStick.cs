using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorStick : MonoBehaviour
{
    Rigidbody rb;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
     rb.angularVelocity = new Vector3(0, Time.deltaTime * 80f , 0f);
    }
}