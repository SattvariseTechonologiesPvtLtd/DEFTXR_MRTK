using UnityEngine;
using System.Collections.Generic;

public class MaterialChanger : MonoBehaviour
{
    public static MaterialChanger Instance;

    public void Awake()
    {
        Instance = this;
    }
    public Stack<Material> addedMaterials = new Stack<Material>(); // Stack to store added materials

    // Add a new material to the MeshRenderer
    public void AddNewMaterial(Material newMaterial)
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer != null && newMaterial != null)
        {
            Material[] currentMaterials = meshRenderer.materials;
            Material[] updatedMaterials = new Material[currentMaterials.Length + 1];

            for (int i = 0; i < currentMaterials.Length; i++)
            {
                updatedMaterials[i] = currentMaterials[i];
            }

            updatedMaterials[currentMaterials.Length] = newMaterial;

            meshRenderer.materials = updatedMaterials;

            // Push the newMaterial onto the addedMaterials stack
            addedMaterials.Push(newMaterial);

            Debug.Log("Material added successfully.");
        }
        else
        {
            Debug.LogError("MeshRenderer component or newMaterial is not set.");
        }
    }

    // Remove the last added material from the MeshRenderer
    public void RemoveLastAddedMaterial()
    {
        if (addedMaterials.Count > 0)
        {
            Material materialToRemove = addedMaterials.Pop(); // Pop the last added material from the stack

            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            Material[] currentMaterials = meshRenderer.materials;

            List<Material> updatedMaterialsList = new List<Material>(currentMaterials);
            updatedMaterialsList.Remove(materialToRemove);

            // Assign the updated materials list back to the MeshRenderer
            meshRenderer.materials = updatedMaterialsList.ToArray();

            Debug.Log("Last added material removed successfully.");
        }
        else
        {
            Debug.LogWarning("No materials have been added to remove.");
        }
    }
}
