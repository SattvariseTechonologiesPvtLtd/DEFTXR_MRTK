using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nova;
using NovaSamples;
using UnityEngine.SceneManagement;

public class MainHUB_UIManager : MonoBehaviour
{
    public GameObject HandMenuBar, SystemsMenuBar, GrossAnatomyPanel, BodySystemsPanel, SkyboxPanel;
    public GameObject SystemsButton, SkyboxButton, SystemsButtonPressed, SkyboxButtonPressed, GrossAnatomyButton, GrossAnatomyButtonPressed, BodySystemsButton, BodySystemsButtonPressed;

    private void Start()
    {
        HandMenuBar.SetActive(true);
        SystemsMenuBar.SetActive(false);
        GrossAnatomyPanel.SetActive(false);
        BodySystemsPanel.SetActive(false);
        SkyboxPanel.SetActive(false);
        GrossAnatomyButtonPressed.SetActive(false);
        BodySystemsButtonPressed.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void OnSystemsButtonClick()
    {
        SystemsButton.SetActive(false);
        SystemsButtonPressed.SetActive(true);

        SkyboxButton.SetActive(true);
        SkyboxButtonPressed.SetActive(false);

        SystemsMenuBar.SetActive(true);
        SkyboxPanel.SetActive(false);
    }
    public void OnSystemsButtonPressedClick()
    {
        SystemsButton.SetActive(true);
        SystemsButtonPressed.SetActive(false);

        SkyboxButton.SetActive(true);
        SkyboxButtonPressed.SetActive(false);

        SystemsMenuBar.SetActive(false);
        SkyboxPanel.SetActive(false);

        GrossAnatomyButtonPressed.SetActive(false);
        BodySystemsButtonPressed.SetActive(false);
        SystemsMenuBar.SetActive(false);
    }
    public void OnSkyboxButtonClick()
    {
        SkyboxButton.SetActive(false);
        SkyboxButtonPressed.SetActive(true);

        SystemsButton.SetActive(true);
        SystemsButtonPressed.SetActive(false);

        SystemsMenuBar.SetActive(false);
        SkyboxPanel.SetActive(true);

        GrossAnatomyButtonPressed.SetActive(false);
        BodySystemsButtonPressed.SetActive(false);
        GrossAnatomyPanel.SetActive(false);
        BodySystemsPanel.SetActive(false);
    }
    public void OnSkyboxButtonPressedClick()
    {
        SkyboxButton.SetActive(true);
        SkyboxButtonPressed.SetActive(false);

        SystemsButton.SetActive(true);
        SystemsButtonPressed.SetActive(false);

        SystemsMenuBar.SetActive(false);
        SkyboxPanel.SetActive(false);

        GrossAnatomyButtonPressed.SetActive(false);
        BodySystemsButtonPressed.SetActive(false);
        SystemsMenuBar.SetActive(false);
        GrossAnatomyPanel.SetActive(false);
        BodySystemsPanel.SetActive(false);
    }

    public void OnGrossAnatomyButtonClick()
    {
        GrossAnatomyPanel.SetActive(true);
        BodySystemsPanel.SetActive(false);

        GrossAnatomyButtonPressed.SetActive(true);
        BodySystemsButtonPressed.SetActive(false);
    }
    public void OnBodySystemsButtonClick()
    {
        GrossAnatomyPanel.SetActive(false);
        BodySystemsPanel.SetActive(true);

        GrossAnatomyButtonPressed.SetActive(false);
        BodySystemsButtonPressed.SetActive(true);
    }

    public void OnLowerLimbButtonClick()
    {
        //loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_LowerLimb");
    }
    public void OnUpperLimbButtonClick()
    {
        //loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_UpperLimb");
    }
    public void OnThoraxButtonClick()
    {
        //loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_Thorax");
    }
    public void OnAbdomenButtonClick()
    {
        //loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_Abdomen");
    }

    public void OnHeadNeckButtonClick()
    {
        //loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_Head&Neck");
    }

    public void OnRespiratorySystemButtonClick()
    {
        //loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_WholeBody_RespiratorySystem");
    }
    public void OnLymphaticSystemButtonClick()
    {
        //loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_WholeBody_LymphaticSystem");
    }
    public void OnCirculatorySystemButtonClick()
    {
        //loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_WholeBody_CirculatorySystem");
    }
}
