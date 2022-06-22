using UnityEngine;
using UnityEngine.AI;


public class OpponentAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private float turnSpeed = 2f;
    NavMeshAgent navMesh;
    
    public Transform finish;
    public Transform spawnPos;
    Animator anim;
    void Start()
    {
        Animator anim = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.destination = finish.position;
     }


    void Update()
    {
        Vector3 addedPos = new Vector3(0 * speed * Time.deltaTime, 0, 1 * speed * Time.deltaTime);

        transform.position += addedPos;

        Vector3 direction = Vector3.forward * 1 + Vector3.right * 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);

        navMesh.destination = finish.transform.position;


        var ray = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2))
        {
            navMesh.destination += finish.transform.position * 1f;
        }
        else
        {
            navMesh.destination = finish.transform.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine"))
        {
            gameObject.GetComponent<Animator>().enabled = false;
            
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Static Obstacles")
        {
            transform.position = spawnPos.transform.position;
        }

        else if (collision.gameObject.tag == "Half Donut")
        {
            transform.position = spawnPos.transform.position;
        }

        else if (collision.gameObject.tag == "HorizontalObstacles")
        {
            transform.position = spawnPos.transform.position;
        }
        else if (collision.gameObject.tag == "Rotator")
        {
            transform.position = spawnPos.transform.position;
        }
    }
}
