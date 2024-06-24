using UnityEngine;
using MixedReality.Toolkit.SpatialManipulation;

public class ResetToOrgPos : MonoBehaviour
{
    // A class to store transform properties
    private class TransformProperties
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public TransformProperties(Transform transform)
        {
            position = transform.localPosition;
            rotation = transform.localRotation;
            scale = transform.localScale;
        }
    }

    private void Start()
    {
        // Store the original properties of the parent object
        StoreOriginalProperties(transform);
    }

    private void StoreOriginalProperties(Transform obj)
    {
        // Store the original properties in the dictionary
        TransformProperties originalProperties = new TransformProperties(obj);
        Resettable resettable = obj.gameObject.AddComponent<Resettable>();
        resettable.originalProperties = originalProperties;

        // If BoundsControl is attached, get and store its handles
        BoundsControl boundsControl = obj.GetComponent<BoundsControl>();
        if (boundsControl != null)
        {
            resettable.boundsControlHandles = boundsControl.HandlesActive;
        }

        // Recursively store properties of child objects
        foreach (Transform child in obj)
        {
            StoreOriginalProperties(child);
        }
    }

    public void OnResetButtonClick()
    {
        // Reset the properties of the parent object and its children
        ResetObjectProperties(transform);
    }

    private void ResetObjectProperties(Transform obj)
    {
        // Retrieve the Resettable component from the object
        Resettable resettable = obj.GetComponent<Resettable>();

        // Check if the Resettable component is attached
        if (resettable != null)
        {
            // Reset the transform properties
            obj.localPosition = resettable.originalProperties.position;
            obj.localRotation = resettable.originalProperties.rotation;
            obj.localScale = resettable.originalProperties.scale;

            // If BoundsControl is attached, disable its handles
            BoundsControl boundsControl = obj.GetComponent<BoundsControl>();
            if (boundsControl != null)
            {
                boundsControl.HandlesActive = true;
                boundsControl.HandlesActive = false;
            }
        }

        // Check for child objects named "BoundingBoxWithHandles(Clone)"
        foreach (Transform child in obj)
        {
            /*if (child.name == "BoundingBoxWithHandles(Clone)")
            {
                // Destroy or remove the child object
                child.gameObject.SetActive(false);
                //Destroy(child.gameObject); // Use DestroyImmediate(child.gameObject) if you need to remove it immediately
            }
            else
            {
                // Recursively reset properties of other child objects
                ResetObjectProperties(child);
            }*/
            // Recursively reset properties of other child objects
            ResetObjectProperties(child);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset the properties of the parent object and its children
            ResetObjectProperties(transform);
        }
    }

    // A component to attach to each object with original properties
    private class Resettable : MonoBehaviour
    {
        public TransformProperties originalProperties;
        public bool boundsControlHandles;
    }
}
