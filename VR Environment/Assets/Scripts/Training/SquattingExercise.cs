using System.Collections;
using TMPro;
using UnityEngine;

public class SquattingExercise : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public AudioSource exerciseCompleteAudio;

    private float exerciseDuration = 5.0f;
    private float timer;
    private bool exerciseStarted;
    public Animator chestAnimator;
    public GameObject key;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && !exerciseStarted)
        {
            exerciseStarted = true;
            messageText.SetText("Squat for 5 seconds");
            StartCoroutine(CheckSquatting());
        }
    }

    IEnumerator CheckSquatting()
    {
        yield return new WaitForSeconds(0.5f);

        float leftHand = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).y;
        float rightHand = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch).y;


        while (timer < exerciseDuration)
        {

            if (leftHand < 5f && rightHand < 5f)
            {
                messageText.SetText("Good job! Keep going");
            }
            else
            {
                messageText.SetText("Squat more!");
            }

            timer += Time.deltaTime;
            yield return null;
        }

        // Check if exercise was successful and display appropriate message
        if (timer >= exerciseDuration && (leftHand < 5f && rightHand < 5f))
        {
            messageText.SetText("Exercise complete");
            exerciseCompleteAudio.Play();
            chestAnimator.SetBool("Open", true);
            key.SetActive(true);
            yield return new WaitForSeconds(2.0f);
        }
        else
        {
            messageText.SetText("You need to rotate your hands more");
            yield return new WaitForSeconds(2.0f);
            messageText.SetText("Press A to try again");
            exerciseStarted = false;
            timer = 0.0f;
        }
    }
}
