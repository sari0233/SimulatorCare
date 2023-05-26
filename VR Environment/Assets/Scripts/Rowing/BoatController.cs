using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private float paddleForce = 10f;
    [SerializeField] private float resistanceForce = 5f;
    [SerializeField] private float deadZone = 0.1f;

    private Rigidbody boatRigidbody;
    private Vector3 currentDirection;

    private void Awake()
    {
        boatRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        bool rightButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        bool leftButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch);

        if (rightButtonPressed && leftButtonPressed)
        {
            Vector3 leftHandDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
            Vector3 rightHandDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            Vector3 localVelocity = leftHandDirection + rightHandDirection;
            localVelocity *= -1f;

            float forwardSpeed = Mathf.Max(localVelocity.z - deadZone, 0f); // Filter out backward movement

            if (forwardSpeed > 0f)
            {
                AddPaddleForce(localVelocity.normalized * forwardSpeed);
            }
        }
        ApplyResistanceForce();
    }

    private void ApplyResistanceForce()
    {
        if (boatRigidbody.velocity.sqrMagnitude > 0.01f && currentDirection != Vector3.zero)
        {
            boatRigidbody.AddForce(-boatRigidbody.velocity * resistanceForce, ForceMode.Acceleration);
        }
        else
        {
            currentDirection = Vector3.zero;
        }
    }

    private void AddPaddleForce(Vector3 localVelocity)
    {
        boatRigidbody.AddForce(localVelocity * paddleForce, ForceMode.Acceleration);
        currentDirection = localVelocity.normalized;
    }
}
