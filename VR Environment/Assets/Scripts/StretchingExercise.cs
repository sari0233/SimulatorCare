using UnityEngine;
using TMPro;

public class StretchingExercise : MonoBehaviour
{
    public GameObject stretchingCanvas;
    public GameObject secondExerciseCanvas;
    public GameObject thirdExerciseCanvas;
    public TMP_Text feedbackText;

    private bool exerciseInProgress = false;
    private float exerciseTimer = 0f;

    void Start()
    {
        stretchingCanvas.SetActive(true);
        secondExerciseCanvas.SetActive(false);
        thirdExerciseCanvas.SetActive(false);
        feedbackText.text = "Stretch your arms above your head, and press the A button to start the exercise";
    }

    void Update()
    {
        if (exerciseInProgress)
        {
            exerciseTimer += Time.deltaTime;

            if (exerciseTimer >= 5f)
            {
                CheckExerciseCompletion();
            }
        }
        else if (OVRInput.GetDown(OVRInput.Button.One))
        {
            StartExercise();
        }
    }

    private void StartExercise()
    {
        exerciseInProgress = true;
        feedbackText.text = "Keep stretching your arms above your head!";
    }

    private void CheckExerciseCompletion()
    {
        exerciseInProgress = false;
        exerciseTimer = 0f;

        float armHeight = GetArmHeight();

        if (armHeight >= 0.8f)
        {
            feedbackText.text = "Exercise completed, well done!";;
            Invoke("SwitchToSecondExerciseCanvas", 2.0f);
        }
        else
        {
            feedbackText.text = "Stretch your arms a bit higher!";
        }
    }

    private float GetArmHeight()
    {
        Vector3 headPosition = Camera.main.transform.position;
        Vector3 handPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

        Vector3 direction = handPosition - headPosition;

        float armHeight = Vector3.Dot(direction.normalized, Vector3.up);

        return armHeight;

    }
    void SwitchToSecondExerciseCanvas()
    {
        stretchingCanvas.SetActive(false);
        secondExerciseCanvas.SetActive(true);
    }
}
