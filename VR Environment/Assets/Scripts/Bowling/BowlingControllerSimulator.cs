using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingControllerSimulator : MonoBehaviour
{
    public Transform arm;
    public Transform ball;
    public float backwardThreshold = 0.1f;
    public float forwardThreshold = 0.1f;
    public float backwardX = 35.1f;
    public float forwardX = 22.7f;

    private Vector3 initialArmPosition;
    private Vector3 initialBallPosition;
    private bool isThrowing = false;

    // Start is called before the first frame update
    void Start()
    {
        initialArmPosition = arm.localPosition;
        initialBallPosition = ball.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isThrowing)
        {
            // Start the throw
            isThrowing = true;
            initialArmPosition = arm.localPosition;
            initialBallPosition = ball.localPosition;
        }

        if (isThrowing)
        {
            // Update the current positions
            Vector3 currentArmPosition = arm.localPosition;
            Vector3 currentBallPosition = ball.localPosition;

            // Calculate the distance
            float distanceArm = Mathf.Abs(initialArmPosition.x - currentArmPosition.x);
            float distanceBall = Mathf.Abs(initialBallPosition.x - currentBallPosition.x);

            // Check if the arm movement is within the thresholds
            if (distanceArm < backwardThreshold && currentArmPosition.x > backwardX)
            {
                // Show "Move back" instruction on the screen
                Debug.Log("Move back");
            }
            else if (distanceArm > forwardThreshold && distanceBall < backwardThreshold && currentArmPosition.x < forwardX)
            {
                // Show "Move forward" instruction on the screen
                Debug.Log("Move forward");
            }
            else if (distanceArm > forwardThreshold && distanceBall > backwardThreshold && currentArmPosition.x < forwardX)
            {
                // Perform the bowling action
                Debug.Log("Realease button to throw the ball");
                isThrowing = false;
            }
        }
    }

}
