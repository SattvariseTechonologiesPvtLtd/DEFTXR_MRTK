using UnityEngine;

public class PassthroughManager : MonoBehaviour
{
    public OVRPassthroughLayer passthroughLayer;

    [SerializeField]
    private LayerMask passthroughLayerMask; // Assign the layer containing objects to render in passthrough view

    public Material yourSkyboxMaterial;
    private void Awake()
    {
        passthroughLayer = GetComponent<OVRPassthroughLayer>();
        passthroughLayer.enabled = false; // Disable passthrough on start
    }

   /* public void TogglePassthrough()
    {
        isPassthroughEnabled = !isPassthroughEnabled;
        passthroughLayer.enabled = isPassthroughEnabled;

        // Disable the skybox
        if (isPassthroughEnabled)
        {
            RenderSettings.skybox = null; // Set the skybox material to null
            passthroughLayer.GetComponent<Camera>().cullingMask = passthroughLayerMask; // Set the culling mask to include objects in the passthrough view
        }
        else
        {
            // Enable the skybox again if passthrough is disabled
            RenderSettings.skybox = yourSkyboxMaterial; // Assign the appropriate skybox material
            passthroughLayer.GetComponent<Camera>().cullingMask = 0; // Set the culling mask to exclude objects in the passthrough view
        }
    }*/

    public void onPassthorughButtonClick()
    {
        RenderSettings.skybox = null;
        passthroughLayer.hidden = !passthroughLayer.hidden;
        passthroughLayer.GetComponent<Camera>().cullingMask = passthroughLayerMask;
    }
}
