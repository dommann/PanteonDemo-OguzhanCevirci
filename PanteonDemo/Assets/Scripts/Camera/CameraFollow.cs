using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject playerRef;
	private bool trackPlayer;
	[SerializeField]
	private Transform target;
    [SerializeField]
	private float distance = 5.0f;
    void LateUpdate()
	{
		
		if (!target)
			return;

		var currentRotationAngle = transform.eulerAngles.y;
		var currentHeight = transform.position.y;
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        
		
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        
		transform.LookAt(target);

		if (trackPlayer)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, playerRef.transform.position.z - 3), 2.0f * Time.deltaTime);
		}
	}

	
}
