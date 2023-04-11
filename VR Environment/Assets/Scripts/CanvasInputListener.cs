using UnityEngine;

public class CanvasInputListener : MonoBehaviour
{
    public GameObject currentCanvas;
    public GameObject firstExerciseCanvas;

    void Start()
    {
        currentCanvas.SetActive(true);
        firstExerciseCanvas.SetActive(false);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            currentCanvas.SetActive(false);
            firstExerciseCanvas.SetActive(true);
        }
    }
}
