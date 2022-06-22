using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    enum Directions
    {
      Left,
      Right,
    };

    public GameObject platform;

    [SerializeField] 
    private Directions direction;
    
    [SerializeField] 
    private float speed;
    
    private float platformX;
    private void Start()
    {
        platformX = platform.GetComponent<MeshRenderer>().bounds.size.x;
    }
    void Update()
    {
        switch (direction)
        {
            case Directions.Right:
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                if (transform.position.x > platform.transform.position.x + platformX / 2)
                {
                    direction = Directions.Left;
                }
                break;
            case Directions.Left:
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
                if (transform.position.x < platform.transform.position.x - platformX / 2)
                {
                    direction = Directions.Right;
                }
               break;
               default:
               break;
        }
    }
}