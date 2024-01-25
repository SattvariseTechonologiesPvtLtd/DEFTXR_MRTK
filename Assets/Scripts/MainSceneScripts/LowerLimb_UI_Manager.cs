using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LowerLimb_UI_Manager : MonoBehaviour
{
    public static LowerLimb_UI_Manager Instance;

    public TMP_Text content;


    public AudioClip tickSound;

    [SerializeField]
    GameObject welcomeUIPanel, humanAnatomyPanels;

    [Header("")]
    [SerializeField]
    GameObject regionsPanel, contentPanel;
    [SerializeField] GameObject systemsPanel, grossAnatomyPanel, crossSectionsPanel, microanatomyPanel, muscleActionPanel;
    [SerializeField] GameObject infoPanel;

    [Header("")]
    [SerializeField] GameObject lowerBodybones;
    [SerializeField] GameObject lowerBodyLigaments, lowerBodyMuscles, lowerBodyArteries, lowerBodyNerves, lowerBodySkin, lowerBodyVains, lowerBodylyphaticSystem;
    [SerializeField] GameObject completeLowerBody;

    [Header("")]
    [SerializeField] string selectedEnglishName, selectedLatinName;
    [SerializeField] public TextMeshProUGUI englishName, latinName;

    [Header("")]
    [SerializeField] public AudioSource audioSource;
    public AudioClip seletcedEnglishVO, selectedLatinVO;


    private bool isSkinOn, isMusclesOn, isLigamentsOn, isArteriesOn, isVainsOn, isNervesOn, isBonesOn, isLyphaticOn;

    public GameObject isolationPanel, mainSystemPanel, hideButton, undoButton, LeftSideMuscleIsolatePanel;
    public GameObject verticalRotationButton, horozontalRotationButton, label, slider;

    [SerializeField] //public GameObject deltoid_isolate, deltoid_isolate_parent;
    public GameObject currentSelectObject, currentIsolatedObject;
    public int currentSelectedAssetNo;

    public Material orgVains, orgArt, orgLymph, orgNervs;
    public Material _hVains, _hArt, _hLymph, _hNervs;

    public GameObject closeButton, isolateButton;

    public bool isIsolatedOn;

    public enum State
    {
        bones,
        muscle,
        art,
        vains,
        nerves,
        lymph,
    }

    public State state;

    public enum Region
    {
        upperLimb,
        lowerLimb,
        Thorax,
    }

    public Region region;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Reset();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void Reset()
    {
        //Gameobjects need to active on start
        welcomeUIPanel.SetActive(true);

        //gameobjects that need to disableld on start
        completeLowerBody.SetActive(false);
        humanAnatomyPanels.SetActive(false);
        infoPanel.SetActive(false);
        closeButton.SetActive(false);

        //
        isSkinOn = isMusclesOn = isLigamentsOn = isArteriesOn = isVainsOn = isNervesOn = isBonesOn = isLyphaticOn = true;

        //
        lowerBodySkin.SetActive(true);
        lowerBodyMuscles.SetActive(false);
        lowerBodyLigaments.SetActive(false);
        lowerBodyArteries.SetActive(false);

        isIsolatedOn = false;
        closeButton.SetActive(false);
        isolateButton.SetActive(false);
        contentPanel.SetActive(false);
        isolationPanel.SetActive(false);
    }

    public void resetLowerBody()
    {
        lowerBodySkin.SetActive(true);
        lowerBodyMuscles.SetActive(false);
        lowerBodyLigaments.SetActive(false);
        lowerBodyArteries.SetActive(false);
        lowerBodybones.SetActive(false);
        lowerBodyNerves.SetActive(false);
        lowerBodyVains.SetActive(false);
        lowerBodylyphaticSystem.SetActive(false);
        isSkinOn = true;

        humanAnatomyPanels.SetActive(false);
        infoPanel.SetActive(true);

    }


    /// <summary>
    /// 
    /// </summary>
    public void CloseButtonClick()
    {
        if (state == State.bones)
        {
            currentIsolatedObject.SetActive(false);
            currentIsolatedObject = null;
            AssetManagementScript.Instance.resetData();

            completeLowerBody.SetActive(true);

            mainSystemPanel.SetActive(true);
            resetLowerBody();
            isIsolatedOn = false;
            closeButton.SetActive(false);
            contentPanel.SetActive(true);
            LeftSideMuscleIsolatePanel.SetActive(false);
            isolationPanel.SetActive(false);

            englishName.text = "";
            latinName.text = "";
            content.text = "";


        }

        if (state == State.muscle)
        {
            currentIsolatedObject.SetActive(false);
            currentIsolatedObject = null;
            AssetManagementScript.Instance.resetData();

            completeLowerBody.SetActive(true);
            LeftSideMuscleIsolatePanel.SetActive(false);
            mainSystemPanel.SetActive(true);

            hideButton.SetActive(false);
            undoButton.SetActive(false);
            verticalRotationButton.SetActive(false);
            horozontalRotationButton.SetActive(false);
            label.SetActive(false);
            slider.SetActive(false);
            resetLowerBody();
            isIsolatedOn = false;
            closeButton.SetActive(false);
            contentPanel.SetActive(true);
            isolationPanel.SetActive(false);
            englishName.text = "";
            latinName.text = "";
            content.text = "";

        }
    }


    public void isolateButtonClick()
    {
        if (state == State.muscle)
        {
            currentIsolatedObject = AssetManagementScript.Instance.isolatedMuscleAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
            currentIsolatedObject.SetActive(true);
            AssetManagementScript.Instance.setIsolatedMuscleData();

            completeLowerBody.SetActive(false);
            LeftSideMuscleIsolatePanel.SetActive(true);
            mainSystemPanel.SetActive(false);

            hideButton.SetActive(true);
            undoButton.SetActive(false);
            verticalRotationButton.SetActive(true);
            horozontalRotationButton.SetActive(true);
            label.SetActive(true);
            slider.SetActive(true);

            isIsolatedOn = true;
            closeButton.SetActive(true);
            isolateButton.SetActive(false);
        }

        if (state == State.bones)
        {
            currentIsolatedObject = AssetManagementScript.Instance.isolatedBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
            currentIsolatedObject.SetActive(true);
            AssetManagementScript.Instance.setIsolatedBonesData();

            completeLowerBody.SetActive(false);
            isolationPanel.SetActive(false);
            mainSystemPanel.SetActive(false);
            isIsolatedOn = true;
            closeButton.SetActive(true);
            isolateButton.SetActive(false);
            contentPanel.SetActive(false);
        }

    }
    public void loginButtonClick()
    {
        welcomeUIPanel.SetActive(false);
        humanAnatomyPanels.SetActive(true);

    }

    public void lowerLimbButtonClick()
    {
        completeLowerBody.SetActive(true);

        humanAnatomyPanels.SetActive(false);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);

        //closeButton.SetActive(true);

    }

    /// <summary>
    /// Below methods consist of Panel Button click calls 
    /// ------------------------------------------------ Start --------------------------------
    /// </summary>
    public void regionsPanelButtonClick()
    {
        activatePanels(0);
    }
    public void systemsPanelButtonClick()
    {
        activatePanels(1);
    }
    public void grossAnatomyPanelButtonClick()
    {
        activatePanels(2);
    }
    public void crossSectionsPanelButtonClick()
    {
        activatePanels(3);
    }
    public void microanatomyPanelButtonClick()
    {
        activatePanels(4);
    }
    public void muscleActionPanelButtonClick()
    {
        activatePanels(5);
    }

    void activatePanels(int index)
    {
        switch (index)
        {
            case 0:
                regionsPanel.SetActive(true);
                systemsPanel.SetActive(false);
                grossAnatomyPanel.SetActive(false);
                crossSectionsPanel.SetActive(false);
                microanatomyPanel.SetActive(false);
                muscleActionPanel.SetActive(false);
                break;

            case 1:
                regionsPanel.SetActive(false);
                systemsPanel.SetActive(true);
                grossAnatomyPanel.SetActive(false);
                crossSectionsPanel.SetActive(false);
                microanatomyPanel.SetActive(false);
                muscleActionPanel.SetActive(false);
                break;

            case 2:

                regionsPanel.SetActive(false);
                systemsPanel.SetActive(false);
                grossAnatomyPanel.SetActive(true);
                crossSectionsPanel.SetActive(false);
                microanatomyPanel.SetActive(false);
                muscleActionPanel.SetActive(false);
                break;

            case 3:

                regionsPanel.SetActive(false);
                systemsPanel.SetActive(false);
                grossAnatomyPanel.SetActive(false);
                crossSectionsPanel.SetActive(true);
                microanatomyPanel.SetActive(false);
                muscleActionPanel.SetActive(false);
                break;

            case 4:
                regionsPanel.SetActive(false);
                systemsPanel.SetActive(false);
                grossAnatomyPanel.SetActive(false);
                crossSectionsPanel.SetActive(false);
                microanatomyPanel.SetActive(true);
                muscleActionPanel.SetActive(false);
                break;

            case 5:
                regionsPanel.SetActive(false);
                systemsPanel.SetActive(false);
                grossAnatomyPanel.SetActive(false);
                crossSectionsPanel.SetActive(false);
                microanatomyPanel.SetActive(false);
                muscleActionPanel.SetActive(true);
                break;
        }

    }

    /// <summary>
    /// ------------------------------------------------ End --------------------------------
    /// </summary>
    /// 


    /// <summary>
    /// Below methods consist of physical Button click calls 
    /// ------------------------------------------------ Start --------------------------------
    /// </summary>
    public void onSkinButtonClick()
    {
        if (isSkinOn == false)
        {
            lowerBodySkin.SetActive(true);
            lowerBodyMuscles.SetActive(false);
            lowerBodyLigaments.SetActive(false);
            lowerBodyArteries.SetActive(false);
            lowerBodybones.SetActive(false);
            lowerBodyNerves.SetActive(false);
            lowerBodyVains.SetActive(false);
            lowerBodylyphaticSystem.SetActive(false);
            isSkinOn = true;
        }
        else
        {
            lowerBodySkin.SetActive(false);
            lowerBodyMuscles.SetActive(true);
            lowerBodyLigaments.SetActive(true);
            lowerBodyArteries.SetActive(true);
            lowerBodybones.SetActive(true);
            lowerBodyNerves.SetActive(true);
            lowerBodyVains.SetActive(true);
            lowerBodylyphaticSystem.SetActive(true);



            isSkinOn = false;
        }
    }
    public void onMusclesButtonClick()
    {
        if (isMusclesOn == false)
        {
            lowerBodyMuscles.SetActive(true);
            isMusclesOn = true;
        }
        else
        {
            lowerBodyMuscles.SetActive(false);
            isMusclesOn = false;
        }
    }
    public void onLigamentsButtonClick()
    {
        if (isLigamentsOn == false)
        {
            lowerBodyLigaments.SetActive(true);
            isLigamentsOn = true;
        }
        else
        {
            lowerBodyLigaments.SetActive(false);
            isLigamentsOn = false;
        }
    }
    public void onArtriesButtonClick()
    {
        if (isArteriesOn == false)
        {
            lowerBodyArteries.SetActive(true);
            isArteriesOn = true;
        }
        else
        {
            lowerBodyArteries.SetActive(false);
            isArteriesOn = false;
        }
    }

    public void onVainsButtonClick()
    {
        if (isVainsOn == false)
        {
            lowerBodyVains.SetActive(true);
            isVainsOn = true;
        }
        else
        {
            lowerBodyVains.SetActive(false);
            isVainsOn = false;
        }
    }

    public void onNervesButtonClick()
    {
        if (isNervesOn == false)
        {
            lowerBodyNerves.SetActive(true);
            isNervesOn = true;
        }
        else
        {
            lowerBodyNerves.SetActive(false);
            isNervesOn = false;
        }
    }
    public void onBonesButtonClick()
    {
        if (isBonesOn == false)
        {
            lowerBodybones.SetActive(true);
            isBonesOn = true;
        }
        else
        {
            lowerBodybones.SetActive(false);
            isBonesOn = false;
        }
    }

    public void onLymphaticButtonClick()
    {
        if (isLyphaticOn == false)
        {
            lowerBodylyphaticSystem.SetActive(true);
            isLyphaticOn = true;
        }
        else
        {
            lowerBodylyphaticSystem.SetActive(false);
            isLyphaticOn = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void playEnglishVO()
    {
        if (seletcedEnglishVO != null)
        {
            audioSource.PlayOneShot(seletcedEnglishVO);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void playLatinVO()
    {
        if (selectedLatinVO != null)
        {
            audioSource.PlayOneShot(selectedLatinVO);
        }
    }
}
