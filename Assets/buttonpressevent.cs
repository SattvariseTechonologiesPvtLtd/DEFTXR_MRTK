using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class buttonpressevent : MonoBehaviour
{
    public static buttonpressevent Instance;

    public GameObject uiPanel,YPanel,layersPanel, skyboxPanel; // Reference to your UI panel object
    public GameObject MenuButtonHighLight, YButtonHighLight;
    private bool uiActive = false;
    private bool YActive = false;// Track the UI state

    public GameObject InfoPanel, defaultskyboxbutton;

    public GameObject layerbutton, skyboxButton,infobutton, layerPressed, InfoPressed, SkyboxPressed;

    [SerializeField]GameObject GrossAnatomy, BodySystems, MicroAnatomy,Dissection;
    [SerializeField] GameObject GrossAnatomyPressed, BodySystemsPressed, MicroAnatomyPressed, DissectionPressed;
    [SerializeField] GameObject GrossAnatomyMenu, BodySystemsMenu, MicroAnatomyMenu, DissectionMenu;
    [SerializeField] GameObject BackButton;

    // Start is called before the first frame update
    void Start()
    {
        GrossAnatomyMenu.SetActive(false);
        BodySystemsMenu.SetActive(false);
        MicroAnatomyMenu.SetActive(false);
        DissectionMenu.SetActive(false);

        GrossAnatomyPressed.SetActive(false);
        BodySystemsPressed.SetActive(false);
        MicroAnatomyPressed.SetActive(false);
        DissectionPressed.SetActive(false);

        MenuButtonHighLight.SetActive(true);
        YButtonHighLight.SetActive(true);

        InfoPanel.SetActive(false);
        layersPanel.SetActive(false);
        skyboxPanel.SetActive(false);
        SkyboxPressed.SetActive(false);
    }

    public void onSkyboxButtonClick()
    {
        skyboxPanel.SetActive(true);
        SkyboxPressed.SetActive(true);
        skyboxButton.SetActive(false);

        layerPressed.SetActive(false);
        layersPanel.SetActive(false);
        layerbutton.SetActive(true);
    }

    public void onSkyboxPressedButtonClick()
    {
        skyboxPanel.SetActive(false);
        SkyboxPressed.SetActive(false);
        skyboxButton.SetActive(true);
    }

    public void OnResetButtonClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void onLayersPanelButtonClick()
    {
        layerbutton.SetActive(false);
        layerPressed.SetActive(true);
        layersPanel.SetActive(true);
        YPanel.SetActive(false);

        skyboxPanel.SetActive(false);
        SkyboxPressed.SetActive(false);
        skyboxButton.SetActive(true);
    }

    public void onLayersPanelPressedButtonClick()
    {
        layerbutton.SetActive(true);
        layerPressed.SetActive(false);
        layersPanel.SetActive(false);
    }

    public void OnShowInfoButtonClick()
    {
        infobutton.SetActive(false);
        InfoPressed.SetActive(true);
        InfoPanel.SetActive(true);
    }

    public void OnShowInfoPressedButtonClick()
    {
        infobutton.SetActive(true);
        InfoPressed.SetActive(false);
        InfoPanel.SetActive(false);
    }

    public void Reset()
    {
        layersPanel.SetActive(false);
        skyboxPanel.SetActive(false);
        layerPressed.SetActive(false);
        SkyboxPressed.SetActive(false);
        skyboxButton.SetActive(true);
    }

    void Update()
    {
        // Check for controller input
        if (OVRInput.GetDown(OVRInput.Button.Start)) // Adjust the button to the desired input
        {
            // Toggle the UI panel
            MenuButtonHighLight.SetActive(!MenuButtonHighLight.activeSelf);
            uiPanel.SetActive(!uiPanel.activeSelf);
            skyboxButton.SetActive(true);
            Reset();
        }

        if (OVRInput.GetDown(OVRInput.RawButton.Y)) // Adjust the button to the desired input
        {
            // Toggle the UI panel
            YButtonHighLight.SetActive(!YButtonHighLight.activeSelf);
            YPanel.SetActive(!YPanel.activeSelf);
        }
    }

    public void onGrossAnatomyButtonClick()
    {       
        GrossAnatomyPressed.SetActive(true);
        GrossAnatomyMenu.SetActive(true);

        BodySystemsMenu.SetActive(false);
        MicroAnatomyMenu.SetActive(false);
        DissectionMenu.SetActive(false);

        BodySystemsPressed.SetActive(false);
        MicroAnatomyPressed.SetActive(false);
        DissectionPressed.SetActive(false);
    }

    public void onBodySystemsButtonClick()
    {
        BodySystemsPressed.SetActive(true);
        BodySystemsMenu.SetActive(true);

        GrossAnatomyMenu.SetActive(false);
        MicroAnatomyMenu.SetActive(false);
        DissectionMenu.SetActive(false);

        GrossAnatomyPressed.SetActive(false);
        MicroAnatomyPressed.SetActive(false);
        DissectionPressed.SetActive(false);
    }

    public void onMicroAnatomyButtonClick()
    {
        MicroAnatomyPressed.SetActive(true);
        MicroAnatomyMenu.SetActive(true);

        GrossAnatomyMenu.SetActive(false);
        BodySystemsMenu.SetActive(false);
        DissectionMenu.SetActive(false);

        GrossAnatomyPressed.SetActive(false);
        BodySystemsPressed.SetActive(false);
        DissectionPressed.SetActive(false);
    }

    public void onDissectionButtonClick()
    {
        DissectionPressed.SetActive(true);
        DissectionMenu.SetActive(true);

        GrossAnatomyMenu.SetActive(false);
        BodySystemsMenu.SetActive(false);
        MicroAnatomyMenu.SetActive(false);

        GrossAnatomyPressed.SetActive(false);
        BodySystemsPressed.SetActive(false);
        MicroAnatomyPressed.SetActive(false);
    }

    public void onBackButtonClick()
    {
        GrossAnatomyMenu.SetActive(false);
        BodySystemsMenu.SetActive(false);
        MicroAnatomyMenu.SetActive(false);
        DissectionMenu.SetActive(false);

        GrossAnatomyPressed.SetActive(false);
        BodySystemsPressed.SetActive(false);
        MicroAnatomyPressed.SetActive(false);
        DissectionPressed.SetActive(false);
    }
}
