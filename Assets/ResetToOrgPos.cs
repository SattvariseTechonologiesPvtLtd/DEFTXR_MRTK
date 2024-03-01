using UnityEngine;

public class ResetToOrgPos : MonoBehaviour
{
    // A class to store transform properties
    private class TransformProperties
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        //public bool hasBoxCollider;  // Flag to indicate if BoxCollider is attached

        public TransformProperties(Transform transform)
        {
            position = transform.localPosition;
            rotation = transform.localRotation;
            scale = transform.localScale;
            //hasBoxCollider = transform.GetComponent<BoxCollider>() != null;
        }
    }

    private void Start()
    {
        // Store the original properties of all child and subchild objects
        StoreOriginalProperties(transform);
    }

    private void StoreOriginalProperties(Transform parent)
    {
        foreach (Transform child in parent)
        {
            // Store the original properties in the dictionary
            TransformProperties originalProperties = new TransformProperties(child);
            child.gameObject.AddComponent<Resettable>().originalProperties = originalProperties;

            // Recursively store properties of subchild objects
            StoreOriginalProperties(child);
        }
    }

    public void OnResetButtonClick()
    {
        // Reset the properties of all child and subchild objects
        ResetObjectProperties(transform);
    }

    private void ResetObjectProperties(Transform parent)
    {
        foreach (Transform child in parent)
        {
            // Retrieve the Resettable component from the child
            Resettable resettable = child.GetComponent<Resettable>();

            // Check if the Resettable component is attached
            if (resettable != null)
            {
                // Reset the transform properties
                child.localPosition = resettable.originalProperties.position;
                child.localRotation = resettable.originalProperties.rotation;
                child.localScale = resettable.originalProperties.scale;

                // Disable the BoxCollider if it is attached
                /*BoxCollider boxCollider = child.GetComponent<BoxCollider>();
                if (boxCollider != null && resettable.originalProperties.hasBoxCollider)
                {
                    boxCollider.enabled = false;
                }*/
            }

            // Recursively reset properties of subchild objects
            ResetObjectProperties(child);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetObjectProperties(transform);
        }
    }

    // A component to attach to each object with original properties
    private class Resettable : MonoBehaviour
    {
        public TransformProperties originalProperties;
    }
}
