using UnityEngine;

public class MaterialFadeController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private bool isFading = false;
    private Material[] originalMaterials;
    private Material[] transparentMaterials;

    private Color targetColor = new Color(1f, 1f, 1f, 0.2f); // White with 50% transparency

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterials = meshRenderer.materials;

        // Create an array of materials with the "Unlit/TransparentTexture" shader
        transparentMaterials = new Material[originalMaterials.Length];
        for (int i = 0; i < originalMaterials.Length; i++)
        {
            transparentMaterials[i] = new Material(originalMaterials[i]);
            transparentMaterials[i].shader = Shader.Find("Unlit/TransparentTexture");
        }
    }

    private void Update()
    {
        if (isFading)
        {
            float lerpSpeed = 0.1f;

            // Lerping the color for each material
            for (int i = 0; i < transparentMaterials.Length; i++)
            {
                Color currentColor = Color.Lerp(transparentMaterials[i].color, targetColor, lerpSpeed * Time.deltaTime);
                transparentMaterials[i].color = currentColor;
            }

            // Apply the modified materials to the renderer
            meshRenderer.materials = transparentMaterials;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFade();
        }
    }

    public void ToggleFade()
    {
        isFading = !isFading;

        // Reset to the original materials when the fade is turned off
        if (!isFading)
        {
            meshRenderer.materials = originalMaterials;
        }
    }
}
