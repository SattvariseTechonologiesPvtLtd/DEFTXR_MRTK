using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class mainUIManager: MonoBehaviour
{
    public static mainUIManager Instance;


    bool isInMainMenu;

    // UI component references
    public GameObject mainMenu, subsystemMenu;

    // UI Button references
 


    void Awake()
    {
        
            Instance = this;
       
       
    }

    // Use this for initialization
    void Start()
    {
        isInMainMenu = true;
        mainMenu.SetActive(true);
        subsystemMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()   {
        // Show the laser from hand to interact with the UI

      


    }

    public void onHumenAnatomyButtonClick()
    {
        mainMenu.SetActive(false);
        subsystemMenu.SetActive(true);
    }

    public void onSkeletonSystemButtonClick()
    {
        SceneManager.LoadSceneAsync("DeftXR_SkeletalSystem");
    }

    public void onNervousSystemButtonClick()
    {
        SceneManager.LoadSceneAsync("DeftXR_NervousSystem");
    }

    public void onCirculatorySystemButtonClick()
    {
        SceneManager.LoadSceneAsync("DeftXR_Circulatory_System");
    }

    public void onLymphaticSystemButtonClick()
    {
        SceneManager.LoadSceneAsync("DeftXR_Lymphatic_System");
    }

    public void onMuscularSystemButtonClick()
    {
        SceneManager.LoadSceneAsync("DeftXR_Muscular_System");
    }
    

        public void onAllSystemButtonClick()
    {
        SceneManager.LoadSceneAsync("All_System");
    }
}
