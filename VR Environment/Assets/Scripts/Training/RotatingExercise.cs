using System.Collections;
using TMPro;
using UnityEngine;

public class RotatingExercise : MonoBehaviour
{
    public GameObject nextCanvas;
    public TextMeshProUGUI feedbackText;
    public AudioSource exerciseCompleteAudio;

    private bool exerciseStarted;
    private float timer;
    private const float exerciseDuration = 10.0f;
    private const float rotationThreshold = 30.0f; // angle threshold in degrees for hand rotation

    // Update is called once per frame
    void Update()
    {
        // Check for A button press to start the exercise
        if (OVRInput.GetDown(OVRInput.Button.One) && !exerciseStarted)
        {
            exerciseStarted = true;
            feedbackText.SetText("Rotate your hands in circles");
            StartCoroutine(CheckHandRotation());
        }
    }

    IEnumerator CheckHandRotation()
    {
        // Wait a moment for the player to start rotating their hands
        yield return new WaitForSeconds(0.5f);

        Vector3 hand1Position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        Vector3 hand2Position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Vector3 headPosition = Camera.main.transform.position;
        float handAngle = Vector3.Angle(hand1Position - headPosition, hand2Position - headPosition);

        // Check if player is rotating hands in a circle for exerciseDuration seconds
        while (timer < exerciseDuration)
        {

            if (handAngle < rotationThreshold)
            {
                feedbackText.SetText("Rotate your hands more");
            }
            else
            {
                feedbackText.SetText("Good job! Keep going");
            }

            timer += Time.deltaTime;
            yield return null;
        }

        // Check if exercise was successful and display appropriate message
        if (timer >= exerciseDuration && handAngle >= rotationThreshold)
        {
            feedbackText.SetText("Exercise complete");
            exerciseCompleteAudio.Play();
            yield return new WaitForSeconds(2.0f);
            nextCanvas.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            feedbackText.SetText("You need to rotate your hands more");
            yield return new WaitForSeconds(2.0f);
            feedbackText.SetText("Press A to try again");
            exerciseStarted = false;
            timer = 0.0f;
        }
    }
}
