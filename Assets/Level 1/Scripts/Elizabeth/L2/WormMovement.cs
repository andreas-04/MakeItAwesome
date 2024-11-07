using UnityEngine;

public class WormMovement : MonoBehaviour
{
    // Speed at which the worm moves based on tilt
    public float movementSpeed = 5f;
    public float tiltSensitivity = 1f; // Sensitivity for up/down movement
    public float turnSpeed = 10f; // Speed of worm turning

    void Update()
    {
        // Get the tilt of the device (acceleration in 3D space)
        Vector3 tilt = Input.acceleration;

        // Move the worm up/down based on the tilt in the x-axis (left/right tilt)
        float moveVertical = tilt.x; // Tilt on the X-axis (left and right)

        // You can scale this movement for more or less sensitivity
        transform.Translate(0, moveVertical * movementSpeed * tiltSensitivity * Time.deltaTime, 0);

        // Rotate the worm around the z-axis based on the tilt (left/right tilt = turning)
        float turnAmount = tilt.x; // Use tilt.x to determine the turning direction
        transform.Rotate(0, 0, -turnAmount * turnSpeed * Time.deltaTime); // Rotate around Z-axis for turning
    }
}
