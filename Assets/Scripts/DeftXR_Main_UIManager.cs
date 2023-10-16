using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeftXR_Main_UIManager : MonoBehaviour
{
    public static DeftXR_Main_UIManager Instance;
    public TMP_Text content;
    public GameObject emtryForTest;

    public AudioClip tickSound;
    public GameObject touchInteraction, loadingImage;


    [SerializeField]
    GameObject welcomeUIPanel, humanAnatomyPanels, instructionPanel, grossAnatomyPanel,disectionPanel, microanatomypanal, BodySystemsPanel, NervousSystemPanel;


    public float speed = 0.3f;
    public GameObject closeButton, NervousCloseButton;
    public GameObject toggleButton;
    public GameObject FpsShowText;

    public bool isFpson;

    // Use this for initialization
    void Start()
    {
        if(ChangeSceneGameManager.Instance.loginscreen == true)
        {
            welcomeUIPanel.SetActive(true);
            instructionPanel.SetActive(false);
            humanAnatomyPanels.SetActive(false);
            closeButton.SetActive(false);
            loadingImage.SetActive(false);
        }
        else
        {
            if(ChangeSceneGameManager.Instance.grossanatomyscreen == true)
            {
                welcomeUIPanel.SetActive(false);
                instructionPanel.SetActive(false);
                humanAnatomyPanels.SetActive(true);
                closeButton.SetActive(false);
                loadingImage.SetActive(false);
            }
        }
        FpsShowText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.Y) || Input.GetKeyDown(KeyCode.F))
        {
            if (isFpson == false)
            {
                FpsShowText.SetActive(true);
                isFpson = true;
                Debug.Log("fpsistrue");
            }
            else
            {
                FpsShowText.SetActive(false);
                isFpson = false;
            }
        }
    }

    public void InstructionBtnClick()
    {
        instructionPanel.SetActive(true);
        welcomeUIPanel.SetActive(false);
    }

    public void backFromInstruBtnClick()
    {
        instructionPanel.SetActive(false);
        welcomeUIPanel.SetActive(true);
    }

    public void CloseButtonClick()
    {
        welcomeUIPanel.SetActive(true);
        instructionPanel.SetActive(false);
        humanAnatomyPanels.SetActive(false);
        closeButton.SetActive(false);
    }

    public void loginButtonClick()
    {
        welcomeUIPanel.SetActive(false);
        humanAnatomyPanels.SetActive(true);
        grossAnatomyPanel.SetActive(false);
        closeButton.SetActive(true);
    }
    public void GrossAnatomyButtonCLick()
    {
        grossAnatomyPanel.SetActive(true);
        microanatomypanal.SetActive(false);
        disectionPanel.SetActive(false);
        BodySystemsPanel.SetActive(false);
        NervousSystemPanel.SetActive(false);
        closeButton.SetActive(true);
    }

    public void BodySystemsButtonCLick()
    {
        BodySystemsPanel.SetActive(true);
        grossAnatomyPanel.SetActive(false);
        microanatomypanal.SetActive(false);
        disectionPanel.SetActive(false);
        NervousSystemPanel.SetActive(false);
        closeButton.SetActive(true);
    }

    public void DisectionButtonCLick()
    {
        disectionPanel.SetActive(true);
        grossAnatomyPanel.SetActive(false);
        microanatomypanal.SetActive(false);
        BodySystemsPanel.SetActive(false);
        NervousSystemPanel.SetActive(false);
        closeButton.SetActive(true);
    }

    public void MicroAnatomyButtonCLick()
    {
        disectionPanel.SetActive(false);
        grossAnatomyPanel.SetActive(false);
        microanatomypanal.SetActive(true);
        BodySystemsPanel.SetActive(false);
        NervousSystemPanel.SetActive(false);
        closeButton.SetActive(true);
    }

    public void NervousButtonCLick()
    {
        NervousSystemPanel.SetActive(true);
        disectionPanel.SetActive(false);
        grossAnatomyPanel.SetActive(false);
        microanatomypanal.SetActive(false);
        BodySystemsPanel.SetActive(false);
        closeButton.SetActive(false);
        NervousCloseButton.SetActive(true);
    }

    public void NervousCloseButtonClick()
    {
        NervousSystemPanel.SetActive(false);
        BodySystemsPanel.SetActive(true);
        NervousCloseButton.SetActive(false);
        closeButton.SetActive(true);
    }

    public void upperLimbButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_UL");
        
    }

    public void lowerLimbButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_LL");
    }

    public void thoraxButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_Thorax");
    }

    public void abdomenButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_Abdomen");
    }

    public void headNeckButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_H&N");
    }

    public void upperLimbDissectionButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_UL_Dissection");

    }

    public void lowerLimbDissectionButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_LL_Dissection");
    }

    public void thoraxDissectionButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_Thorax_Dissection");
    }

    public void abdomenDissectionButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_Abdomen_Dissection");
    }

    public void headNeckDissectionButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_H&N_Dissection");
    }

    public void FullBodyDissectionButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_FullBodyDissection");
    }

    public void skeletonButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_Skeleton_T-Pose");
    }

    public void muscularSysButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MS");
    }

    public void microanatomyFemurButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_Femur");
    }

    public void microanatomyEarButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_Ear");
    }

    public void microanatomyOsteonButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_Osteon");
    }

    public void microanatomySOBVButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_SOBV");
    }

    public void microanatomyIVButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_IntestinalVilli");
    }

    public void microanatomySkinMicroButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_Skin");
    }

    public void microanatomyTRButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_TongueRegions");
    }

    public void microanatomyTSButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_TongueSections");
    }

    public void microanatomyASButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_AlveolarSacs");
    }

    public void microanatomyAlveolusButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_Alveolus");
    }

    public void microanatomyCochleaButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_MicroAnatomy_Cochlea");
    }

    public void NervousSystemHumanBrainAnatomyButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_HumanBrainAnatomy");
    }
    public void NervousSystemTheLimbicSystemButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_TheLimbicSystem");
    }
    public void NervousSystemTrigeminalNerveButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_TrigeminalNerve");
    }
    public void NervousSystemAuditoryAndCoclearPathwaysButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_AuditoryAndCoclearPathways");
    }
    public void NervousSystemCerebellarNucleiButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_CerebellarNuclei");
    }
    public void NervousSystemCN1FromSagittalViewButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_CN1 From Sagittal View");
    }
    public void NervousSystemCutaneousInnervationOfUpperLimbButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_CutaneousInnervationOfUpperLimb");
    }
    public void NervousSystemFunctionalAreasOfBrainAlongWithFunctionsIButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_Functional Areas Of Brain Along With Functions - I");
    }
    public void NervousSystemFunctionalAreasOfBrainAlongWithFunctionsIIButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_Functional Areas Of Brain Along With Functions - II");
    }
    public void NervousSystemOlfactoryEpitheliumButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_Olfactory Epithelium");
    }
    public void NervousSystemPartsOfCerebellumButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_Parts Of Cerebellum");
    }
    public void NervousSystemPostcentralGyrusButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_PostcentralGyrus");
    }
    public void NervousSystemSubdivisionsOfTheGreyMatterOfTheSpinalCordButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_SubdivisionsOfTheGreyMatterOfTheSpinalCord");
    }
    public void NervousSystemThalamusButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_Thalamus");
    }
    public void NervousSystemTractsOfCerebralWhiteMatterButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_Tracts Of Cerebral White Matter");
    }
    public void NervousSystemTransverseSectionThroughTheLowerPartOfTheMidBrainButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_Transverse Section Through The Lower Part Of The MidBrain");
    }
    public void NervousSystemTransverseSectionThroughTheMedullaAtTheLevelOfTheOliveButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_TransverseSectionThroughTheMedullaAtTheLevelOfTheOlive");
    }
    public void NervousSystemTransverseSectionThroughTheUpperPartOfPonsButtonClick()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadSceneAsync("DEFTXR_NervousSystem_TransverseSectionThroughTheUpperPartOfPons");
    }
}
