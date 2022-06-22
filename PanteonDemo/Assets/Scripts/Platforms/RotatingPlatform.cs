using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{

    public Vector3 rotateVector = new Vector3(0, 10, 0);
    public float speed = 50;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.Rotate(rotateVector * speed * 10f);
    }

}
