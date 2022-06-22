using UnityEngine;

public class HalfDonut : MonoBehaviour
{
    public float start_Rot;
    public float end_Rot;
    private float random_Rot;
    private float random_Move;
    private Vector3 new_Pos;
    private bool lerp;
    private bool end;

    void Update()
    {
        if(!lerp)
        {
            end = !end;
            if (end)
            {
                random_Rot = end_Rot;
            }
            else
            {
               random_Rot = start_Rot;
            }

            random_Move = Random.Range(20, 40);
            new_Pos = new Vector3(random_Rot, transform.localPosition.y, transform.localPosition.z);
            lerp = true;
        }
        else if(lerp)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new_Pos, random_Move * Time.deltaTime);
        }
        if (Vector3.Distance(transform.localPosition, new_Pos) < 0.00005 || Vector3.Distance(transform.localPosition, new_Pos) < -0.00005)
        {
            lerp = false;
        }
    }
}

