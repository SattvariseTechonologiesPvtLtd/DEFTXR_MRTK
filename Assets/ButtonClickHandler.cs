using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public GameObject targetObject; // The object with the bounding box to enable/disable
    public BoundingBox targetBoundingBox; // The MRTK BoundingBox component on the object
    public GameObject xbuttonhighlight;

    private bool boundingBoxEnabled = true; // The initial state of the bounding box (enabled)

    public void Start()
    {
        xbuttonhighlight.SetActive(true);
    }
    public void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X) == true || Input.GetKeyDown(KeyCode.B) == true)
        {
            boundingBoxEnabled = !boundingBoxEnabled; // Toggle the state of the bounding box
            xbuttonhighlight.SetActive(!xbuttonhighlight.activeSelf);
            // Enable/disable the visibility of the bounding box based on the boundingBoxEnabled state
            targetBoundingBox.enabled = boundingBoxEnabled;
        }
            
            
    }
}
