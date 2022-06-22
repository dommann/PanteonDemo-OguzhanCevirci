using UnityEngine;
using UnityEngine.UI;

public class PaintText : MonoBehaviour
{
    public Text progressText;
    void Start()
    {
       progressText = GetComponentInChildren<Text>();
    }


    public void UpdateProgress(float value)
    {
      progressText.text = value * 100 + "%";
    }
}
