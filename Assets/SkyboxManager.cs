using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public Material BeachskyboxMaterial;
    public GameObject BeachButton, BeachPressedButton;
    public Material BarrenLandskyboxMaterial;
    public GameObject BarrenLandButton, BarrenLandPressedButton;
    public Material BlockskyboxMaterial;
    public GameObject BlockButton, BlockPressedButton;
    public Material CyberpunkskyboxMaterial;
    public GameObject CyberpunkButton, CyberpunkPressedButton;
    public Material ScifiskyboxMaterial;
    public GameObject ScifiButton, ScifiPressedButton;

    public GameObject PassThroughButtonPressed;
    public GameObject PassThroughObj, MainCamera, PassThroughCamera;

    public void Start()
    {
        BeachButton.SetActive(true);
        BeachPressedButton.SetActive(false);
        BarrenLandButton.SetActive(true);
        BarrenLandPressedButton.SetActive(false);
        BlockButton.SetActive(true);
        BlockPressedButton.SetActive(false);
        CyberpunkButton.SetActive(true);
        CyberpunkPressedButton.SetActive(false);
        ScifiButton.SetActive(true);
        ScifiPressedButton.SetActive(false);

        PassThroughButtonPressed.SetActive(true);
        PassThroughObj.SetActive(true);
        MainCamera.SetActive(false);
        PassThroughCamera.SetActive(true);
    }

    public void OnBeachSkyboxButtonClick()
    {
        PassThroughObj.SetActive(false);
        MainCamera.SetActive(true);
        PassThroughCamera.SetActive(false);

        RenderSettings.skybox = BeachskyboxMaterial;

        BeachButton.SetActive(true);
        BarrenLandButton.SetActive(true);
        BlockButton.SetActive(true);
        CyberpunkButton.SetActive(true);
        ScifiButton.SetActive(true);

        BeachPressedButton.SetActive(true);
        BarrenLandPressedButton.SetActive(false);
        BlockPressedButton.SetActive(false);
        CyberpunkPressedButton.SetActive(false);
        ScifiPressedButton.SetActive(false);
        PassThroughButtonPressed.SetActive(false);
    }
    public void OnBarrenLandskyboxButtonClick()
    {
        PassThroughObj.SetActive(false);
        MainCamera.SetActive(true);
        PassThroughCamera.SetActive(false);

        RenderSettings.skybox = BarrenLandskyboxMaterial;

        BarrenLandButton.SetActive(true);
        BeachButton.SetActive(true);
        BlockButton.SetActive(true);
        CyberpunkButton.SetActive(true);
        ScifiButton.SetActive(true);

        BeachPressedButton.SetActive(false);
        BarrenLandPressedButton.SetActive(true);
        BlockPressedButton.SetActive(false);
        CyberpunkPressedButton.SetActive(false);
        ScifiPressedButton.SetActive(false);
        PassThroughButtonPressed.SetActive(false);
    }
    public void OnBlockskyboxButtonClick()
    {
        PassThroughObj.SetActive(false);
        MainCamera.SetActive(true);
        PassThroughCamera.SetActive(false);

        RenderSettings.skybox = BlockskyboxMaterial;

        BlockButton.SetActive(true);
        BeachButton.SetActive(true);
        BarrenLandButton.SetActive(true);
        CyberpunkButton.SetActive(true);
        ScifiButton.SetActive(true);

        BeachPressedButton.SetActive(false);
        BarrenLandPressedButton.SetActive(false);
        BlockPressedButton.SetActive(true);
        CyberpunkPressedButton.SetActive(false);
        ScifiPressedButton.SetActive(false);
        PassThroughButtonPressed.SetActive(false);
    }
    public void OnCyberpunkskyboxButtonClick()
    {
        PassThroughObj.SetActive(false);
        MainCamera.SetActive(true);
        PassThroughCamera.SetActive(false);

        RenderSettings.skybox = CyberpunkskyboxMaterial;

        CyberpunkButton.SetActive(true);
        BeachButton.SetActive(true);
        BarrenLandButton.SetActive(true);
        BlockButton.SetActive(true);
        ScifiButton.SetActive(true);

        BeachPressedButton.SetActive(false);
        BarrenLandPressedButton.SetActive(false);
        BlockPressedButton.SetActive(false);
        CyberpunkPressedButton.SetActive(true);
        ScifiPressedButton.SetActive(false);
        PassThroughButtonPressed.SetActive(false);
    }
    public void OnScifiskyboxButtonClick()
    {
        PassThroughObj.SetActive(false);
        MainCamera.SetActive(true);
        PassThroughCamera.SetActive(false);

        RenderSettings.skybox = ScifiskyboxMaterial;

        ScifiButton.SetActive(true);
        BeachButton.SetActive(true);
        BarrenLandButton.SetActive(true);
        BlockButton.SetActive(true);
        CyberpunkButton.SetActive(true);

        BeachPressedButton.SetActive(false);
        BarrenLandPressedButton.SetActive(false);
        BlockPressedButton.SetActive(false);
        CyberpunkPressedButton.SetActive(false);
        ScifiPressedButton.SetActive(true);
        PassThroughButtonPressed.SetActive(false);
    }

    public void OnPassthroughButtonClick()
    {
        if (PassThroughObj.activeSelf)
        {
            PassThroughObj.SetActive(false);
            MainCamera.SetActive(true);
            PassThroughCamera.SetActive(false);
            PassThroughButtonPressed.SetActive(false);
        }
        else
        {
            PassThroughObj.SetActive(true);
            MainCamera.SetActive(false);
            PassThroughCamera.SetActive(true);
            PassThroughButtonPressed.SetActive(true);
        }

        BeachPressedButton.SetActive(false);
        BarrenLandPressedButton.SetActive(false);
        BlockPressedButton.SetActive(false);
        CyberpunkPressedButton.SetActive(false);
        ScifiPressedButton.SetActive(false);
    }
}
