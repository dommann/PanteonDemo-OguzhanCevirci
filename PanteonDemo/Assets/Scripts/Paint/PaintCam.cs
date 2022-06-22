using System.Collections;
using UnityEngine;

public class PaintCam : MonoBehaviour
{
        private IEnumerator MoveCam()
    {
        
        float elapsedTime = 0;
        float waitTime = 3f;

        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
            yield return null;


    }
}
