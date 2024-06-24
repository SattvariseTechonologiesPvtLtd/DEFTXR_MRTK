using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class OutlineEffect : MonoBehaviour
{
    public Color outlineColor = Color.white;
    public float outlineThickness = 0.005f;

    private Renderer objectRenderer;
    private Material originalMaterial;
    private Material outlineMaterial;

    /*void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;

        CreateOutlineMaterial();
    }

    void OnEnable()
    {
        EnableOutline();
    }

    void OnDisable()
    {
        DisableOutline();
    }

    void CreateOutlineMaterial()
    {
        Shader outlineShader = Shader.Find("Custom/OutlineShader");
        if (outlineShader == null)
        {
            Debug.LogError("Outline shader not found");
            return;
        }

        outlineMaterial = new Material(outlineShader);
        outlineMaterial.SetColor("_OutlineColor", outlineColor);
        outlineMaterial.SetFloat("_OutlineThickness", outlineThickness);
    }

    void EnableOutline()
    {
        objectRenderer.materials = new Material[] { originalMaterial, outlineMaterial };
    }

    void DisableOutline()
    {
        objectRenderer.materials = new Material[] { originalMaterial };
    }

    void OnValidate()
    {
        if (outlineMaterial != null)
        {
            outlineMaterial.SetColor("_OutlineColor", outlineColor);
            outlineMaterial.SetFloat("_OutlineThickness", outlineThickness);
        }
    }*/
}
