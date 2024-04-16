using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    public Material outlineMaterial; // Assign the outline material in the Unity Editor

    private Material originalMaterial;
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalMaterial = cubeRenderer.material;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Change "Player" to the tag of the object that triggers the outline effect
        {
            // Change the material to the outline material
            cubeRenderer.material = outlineMaterial;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Change "Player" to the tag of the object that triggers the outline effect
        {
            // Change the material back to the original material
            cubeRenderer.material = originalMaterial;
        }
    }
}
