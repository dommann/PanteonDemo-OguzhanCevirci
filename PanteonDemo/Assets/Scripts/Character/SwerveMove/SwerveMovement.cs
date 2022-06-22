using UnityEngine;


public class SwerveMovement : MonoBehaviour
{
    
    private SwerveInput _swerveInput;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 5f;
    
    public GameObject platform;
    
    private Vector3 platformBoundMin, platformBoundMax;
    Animator anim;
    Rigidbody rb;

    public bool isFinished;
    
    public Transform SpawnPos;
    public Transform PaintablePlatform;
    
    private Vector3 initialPosition;


    private void FixedUpdate()
    {


        if (Input.GetButton("Fire1") && isFinished == false)
        {
            
            anim.SetBool("isRunning", true);

        }
        else
        {
            anim.SetBool("isRunning", false);
        }
 
    }

    private void Awake()
    {
        _swerveInput = GetComponent<SwerveInput>();
        GetPlatformBounds();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {

        transform.position += Vector3.forward * swerveSpeed * Time.fixedDeltaTime;

        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInput.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount,-maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
    }

    private void GetPlatformBounds()
    {
        var rend = platform.GetComponent<Renderer>();
        var bounds = rend.bounds;
        platformBoundMin = bounds.min;
        platformBoundMax = bounds.max;
        Debug.Log("Platform min = " + platformBoundMin.x + " \n Platform max=" + platformBoundMax.x);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FinishLine")
        {

            transform.position = PaintablePlatform.transform.position;
            isFinished = true;
            anim.Play("HappyDance");

        }

        else if (collision.gameObject.tag == "StaticObstacles")
        {

            transform.position = SpawnPos.transform.position;

        }

        else if (collision.gameObject.tag == "HorizontalObstacles")
        {
            transform.position = SpawnPos.transform.position;
        }
        else if (collision.gameObject.tag == "Rotator")
        {
            transform.position = SpawnPos.transform.position;
        }
        else if (collision.gameObject.tag == "HalfDonut")
        {
            transform.position = SpawnPos.transform.position;

        }
        else if (collision.gameObject.tag == "Rotator")
        {
            transform.position = SpawnPos.transform.position;

        }
        else if (collision.gameObject.tag == "PaintCube")
        {
            gameObject.GetComponent<SwerveMovement>().enabled = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "RotatingPlatform")
        {

            rb = GetComponent<Rigidbody>();

            rb.AddForce(100f, 0f, 0f, ForceMode.Impulse);

        }

        else if (other.gameObject.tag == "RotatingPlatformArea")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(initialPosition.x, initialPosition.y, transform.position.z), 100f);

        }

    }

}


