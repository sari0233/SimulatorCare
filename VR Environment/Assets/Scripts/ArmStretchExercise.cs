using UnityEngine;
using UnityEngine.UI;

public class ArmStretchExercise : MonoBehaviour
{
    public float requiredDuration = 5f;
    public float requiredAngle = 60f;
    public float requiredHandHeight = 1.5f;
    public GameObject congratulationsCanvas;
    private bool exerciseInProgress = false;
    private float timeElapsed = 0f;
    private float delayTime = 2f;
    private float delayElapsed = 0f;

    void Start()
    {
        congratulationsCanvas.SetActive(false);
    }

    void Update()
    {
        if (!exerciseInProgress && delayElapsed < delayTime)
        {
            delayElapsed += Time.deltaTime;
            return;
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            StartStretching();
        }

        if (exerciseInProgress)
        {
            Vector3 handPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            Vector3 headPosition = Camera.main.transform.position;
            Vector3 headDirection = Camera.main.transform.forward;

            float handAngle = Vector3.Angle(handPosition - headPosition, headDirection);
            float handHeight = handPosition.y;

            if (handAngle < requiredAngle && handHeight > requiredHandHeight)
            {
                timeElapsed += Time.deltaTime;
            }
            else
            {
                ResetExercise();
            }

            CheckExerciseCompletion();
        }
    }

    public void StartStretching()
    {
        exerciseInProgress = true;
        timeElapsed = 0f;
        delayElapsed = 0f;
        Debug.Log("Exercise started");
    }

    private void CheckExerciseCompletion()
    {
        if (timeElapsed >= requiredDuration)
        {
            congratulationsCanvas.SetActive(true);
            exerciseInProgress = false;
            Debug.Log("Exercise completed");
        }
    }

    public void ResetExercise()
    {
        exerciseInProgress = false;
        timeElapsed = 0f;
        congratulationsCanvas.SetActive(false);
        Debug.Log("Exercise reset");
    }
}
