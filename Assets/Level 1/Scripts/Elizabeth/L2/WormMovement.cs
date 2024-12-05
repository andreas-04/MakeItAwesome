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

        // Move the worm up/down based on the tilt in the y-axis (up/down tilt)
        float moveVertical = tilt.y; // Tilt on the Y-axis (up and down)
        // Move the worm left/right based on the tilt in the x-axis (left/right tilt)
        float moveHorizontal = tilt.x; // Tilt on the X-axis (left and right)

        // Move the worm in both the horizontal and vertical directions
        transform.Translate(moveHorizontal * movementSpeed * tiltSensitivity * Time.deltaTime,
                            moveVertical * movementSpeed * tiltSensitivity * Time.deltaTime,
                            0);

        
        float turnAmount = tilt.x; // Use tilt.x to determine the turning direction
        transform.Rotate(0, 0, -turnAmount * turnSpeed * Time.deltaTime); // Rotate around Z-axis for turning
    }
}
