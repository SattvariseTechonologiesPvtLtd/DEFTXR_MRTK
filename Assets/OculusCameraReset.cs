using UnityEngine;
using UnityEngine.InputSystem;
using Oculus;

public class OculusCameraReset : MonoBehaviour
{
    // Adjust this value based on your desired reset position
    public Vector3 resetPosition = new Vector3(0f, 1.5f, 0f); // Example reset position

    private OVRInput.Controller controller = OVRInput.Controller.RTouch; // Example: Right Oculus Touch controller

    void Update()
    {
        // Example: Listen for Oculus button press to trigger reset
        if (OVRInput.GetDown(OVRInput.Button.One, controller))
        {
            ResetCameraPosition();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCameraPosition();
        }
    }

    void ResetCameraPosition()
    {
        // Reset camera position to the specified reset position
        transform.position = resetPosition;

        // Optionally, you can also reset rotation
        transform.rotation = Quaternion.identity;
    }
}
