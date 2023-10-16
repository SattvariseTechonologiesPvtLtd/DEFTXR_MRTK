using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeftXRMrtkMainMenuManager : MonoBehaviour
{
    public GameObject GrossAnatomyButton, GrossAnatomyButtonPressed, GrossAnatomyPanel;
    public GameObject BodySystemsButton, BodySystemsButtonPressed, BodySystemsPanel;
    public GameObject MicroAnatomyButton, MicroAnatomyButtonPressed, MicroAnatomyPanel;
    public GameObject DissectionButton, DissectionButtonPressed, DissectionPanel;

    public GameObject MenuButtonHighlight, SkyboxButton, SkyboxButtonPressed, SkyboxPanel, MainUiPanel;

    //Start is called before the first frame update
    void Start()
    {
        GrossAnatomyButton.SetActive(true);
        GrossAnatomyButtonPressed.SetActive(false);
        GrossAnatomyPanel.SetActive(false);
        BodySystemsButton.SetActive(true);
        BodySystemsButtonPressed.SetActive(false);
        BodySystemsPanel.SetActive(false);
        MicroAnatomyButton.SetActive(true);
        MicroAnatomyButtonPressed.SetActive(false);
        MicroAnatomyPanel.SetActive(false);
        DissectionButton.SetActive(true);
        DissectionButtonPressed.SetActive(false);
        DissectionPanel.SetActive(false);

        MenuButtonHighlight.SetActive(true);
        MainUiPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for controller input
        if (OVRInput.GetDown(OVRInput.Button.Start)) // Adjust the button to the desired input
        {
            // Toggle the UI panel
            MenuButtonHighlight.SetActive(!MenuButtonHighlight.activeSelf);
            MainUiPanel.SetActive(!MainUiPanel.activeSelf);
            SkyboxButton.SetActive(true);
            SkyboxButtonPressed.SetActive(false);
            SkyboxPanel.SetActive(false);
        }
    }

    public void OnSkyboxButtonClick()
    {
        SkyboxButton.SetActive(false);
        SkyboxButtonPressed.SetActive(true);
        SkyboxPanel.SetActive(true);
    }

    public void OnSkyboxPressedButtonClick()
    {
        SkyboxButton.SetActive(true);
        SkyboxButtonPressed.SetActive(false);
        SkyboxPanel.SetActive(false);
    }

    public void OnGrossAnatomyButtonClick()
    {
        GrossAnatomyButton.SetActive(false);
        GrossAnatomyButtonPressed.SetActive(true);
        GrossAnatomyPanel.SetActive(true);
        BodySystemsButton.SetActive(true);
        BodySystemsButtonPressed.SetActive(false);
        BodySystemsPanel.SetActive(false);
        MicroAnatomyButton.SetActive(true);
        MicroAnatomyButtonPressed.SetActive(false);
        MicroAnatomyPanel.SetActive(false);
        DissectionButton.SetActive(true);
        DissectionButtonPressed.SetActive(false);
        DissectionPanel.SetActive(false);
    }

    public void OnBodySystemsButtonClick()
    {
        GrossAnatomyButton.SetActive(true);
        GrossAnatomyButtonPressed.SetActive(false);
        GrossAnatomyPanel.SetActive(false);
        BodySystemsButton.SetActive(false);
        BodySystemsButtonPressed.SetActive(true);
        BodySystemsPanel.SetActive(true);
        MicroAnatomyButton.SetActive(true);
        MicroAnatomyButtonPressed.SetActive(false);
        MicroAnatomyPanel.SetActive(false);
        DissectionButton.SetActive(true);
        DissectionButtonPressed.SetActive(false);
        DissectionPanel.SetActive(false);
    }

    public void OnMicroAnatomyButtonClick()
    {
        GrossAnatomyButton.SetActive(true);
        GrossAnatomyButtonPressed.SetActive(false);
        GrossAnatomyPanel.SetActive(false);
        BodySystemsButton.SetActive(true);
        BodySystemsButtonPressed.SetActive(false);
        BodySystemsPanel.SetActive(false);
        MicroAnatomyButton.SetActive(false);
        MicroAnatomyButtonPressed.SetActive(true);
        MicroAnatomyPanel.SetActive(true);
        DissectionButton.SetActive(true);
        DissectionButtonPressed.SetActive(false);
        DissectionPanel.SetActive(false);
    }

    public void OnGrossAnatomyPressedButtonClick()
    {
        GrossAnatomyButton.SetActive(true);
        GrossAnatomyButtonPressed.SetActive(false);
        GrossAnatomyPanel.SetActive(false);
        BodySystemsButton.SetActive(true);
        BodySystemsButtonPressed.SetActive(false);
        BodySystemsPanel.SetActive(false);
        MicroAnatomyButton.SetActive(true);
        MicroAnatomyButtonPressed.SetActive(false);
        MicroAnatomyPanel.SetActive(false);
        DissectionButton.SetActive(true);
        DissectionButtonPressed.SetActive(false);
        DissectionPanel.SetActive(false);
    }

    public void OnBodySystemsPressedButtonClick()
    {
        GrossAnatomyButton.SetActive(true);
        GrossAnatomyButtonPressed.SetActive(false);
        GrossAnatomyPanel.SetActive(false);
        BodySystemsButton.SetActive(true);
        BodySystemsButtonPressed.SetActive(false);
        BodySystemsPanel.SetActive(false);
        MicroAnatomyButton.SetActive(true);
        MicroAnatomyButtonPressed.SetActive(false);
        MicroAnatomyPanel.SetActive(false);
        DissectionButton.SetActive(true);
        DissectionButtonPressed.SetActive(false);
        DissectionPanel.SetActive(false);
    }

    public void OnMicroAnatomyPressedButtonClick()
    {
        GrossAnatomyButton.SetActive(true);
        GrossAnatomyButtonPressed.SetActive(false);
        GrossAnatomyPanel.SetActive(false);
        BodySystemsButton.SetActive(true);
        BodySystemsButtonPressed.SetActive(false);
        BodySystemsPanel.SetActive(false);
        MicroAnatomyButton.SetActive(true);
        MicroAnatomyButtonPressed.SetActive(false);
        MicroAnatomyPanel.SetActive(false);
        DissectionButton.SetActive(true);
        DissectionButtonPressed.SetActive(false);
        DissectionPanel.SetActive(false);
    }
}
