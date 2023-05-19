using UnityEngine;

public class GolfBallController : MonoBehaviour
{
    public float hitForce = 10f;
    public Transform club;
    public Transform hole;

    private bool isMoving = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            // Calculate the direction from the club to the hole
            Vector3 direction = hole.position - club.position;
            direction.y = 0f;
            direction.Normalize();

            // Apply the force to the ball in the calculated direction
            rb.AddForce(direction * hitForce, ForceMode.Impulse);

            isMoving = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball has collided with an object other than the ground
        if (collision.gameObject.tag != "Ground")
        {
            isMoving = false;
        }
    }
}
