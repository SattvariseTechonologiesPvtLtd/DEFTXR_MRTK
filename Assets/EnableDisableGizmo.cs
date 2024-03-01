using UnityEngine;
using MixedReality.Toolkit.SpatialManipulation;

public class EnableDisableGizmo : MonoBehaviour
{
    public MonoBehaviour BoundsControl,ObjectManipulator;
    public BoxCollider WholeBodyObject;

    // Assuming you have a reference to your BoundsControl component
    public BoundsControl boundsControl;
    public GameObject GizmoBorder;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the targetScript at the start of the scene
        if (BoundsControl != null)
        {
            BoundsControl.enabled = false;
        }
        if (ObjectManipulator != null)
        {
            ObjectManipulator.enabled = false;
        }
        if (WholeBodyObject != null)
        {
            WholeBodyObject.enabled = false;
        }
        if (GizmoBorder != null)
        {
            GizmoBorder.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for button click, e.g., the space key
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Toggle the enabled state of the targetScript
            if (GizmoBorder != null)
            {
                GizmoBorder.SetActive(!GizmoBorder.activeSelf);
            }
            if (BoundsControl != null)
            {
                BoundsControl.enabled = !BoundsControl.enabled;
            }
            if (ObjectManipulator != null)
            {
                ObjectManipulator.enabled = !ObjectManipulator.enabled;
            }
            if (WholeBodyObject != null)
            {
                WholeBodyObject.enabled = !WholeBodyObject.enabled;
            }
        }
    }
    public void OnGizmoButtonClick()
    {
        if (GizmoBorder != null)
        {
            GizmoBorder.SetActive(!GizmoBorder.activeSelf);
        }
        if (BoundsControl != null)
        {
            BoundsControl.enabled = !BoundsControl.enabled;
            boundsControl.HandlesActive = !boundsControl.HandlesActive;
        }
        if (ObjectManipulator != null)
        {
            ObjectManipulator.enabled = !ObjectManipulator.enabled;
        }
        if (WholeBodyObject != null)
        {
            WholeBodyObject.enabled = !WholeBodyObject.enabled;
        }
    }
}
