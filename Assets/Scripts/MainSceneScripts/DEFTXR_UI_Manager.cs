
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DEFTXR_UI_Manager : MonoBehaviour
{
    public static DEFTXR_UI_Manager Instance;
    public TextMeshPro content;
    public int clickCount;

    public GameObject touchInteraction;
    public bool isDisection;
    [SerializeField]
    GameObject welcomeUIPanel, humanAnatomyPanels, instructionPanel;

    [Header("")]
    [SerializeField]
    GameObject regionsPanel, contentPanel;
    [SerializeField] GameObject systemsPanel, grossAnatomyPanel, crossSectionsPanel, microanatomyPanel, muscleActionPanel;
    [SerializeField] GameObject infoPanel;

    [Header("Upper Body Content")]
    [SerializeField] GameObject upperBodybones;
    [SerializeField] GameObject upperBodyLigaments, upperBodyMuscles, upperBodyArteries, upperBodyNerves, upperBodySkin, upperBodyVains, upperBodylyphaticSystem;
    [SerializeField] public GameObject completeUpperBody;

    [Header("Lower Body Content")]
    [SerializeField] GameObject lowerBodybones;
    [SerializeField] GameObject lowerBodyLigaments, lowerBodyMuscles, lowerBodyArteries, lowerBodyNerves, lowerBodySkin, lowerBodyVains, lowerBodylyphaticSystem;
    [SerializeField] GameObject completelowerBody;

    [Header("Thorax Content")]
    [SerializeField] GameObject Thoraxbones;
    [SerializeField] GameObject ThoraxLigaments, ThoraxSkin, ThoraxlyphaticSystem, ThoraxMuscles, ThoraxArteries, ThoraxNerves, ThoraxVains, ThoraxOrgans;
    [SerializeField] GameObject completeThorax;

    [Header("Abdomen Content")]
    [SerializeField] GameObject Abdomenbones;
    [SerializeField] GameObject AbdomenLigaments, AbdomenSkin, AbdomenlyphaticSystem, AbdomenMuscles, AbdomenArteries, AbdomenNerves, AbdomenVains, AbdomenOrgans;
    [SerializeField] GameObject completeAbdomen;

    [Header("Head & Neck Content")]
    [SerializeField] GameObject HeadNeckbones;
    [SerializeField] GameObject HeadNeckLigaments, HeadNeckSkin, HeadNecklyphaticSystem, HeadNeckMuscles, HeadNeckArteries, HeadNeckNerves, HeadNeckVains, HeadNeckOrgans;
    [SerializeField] GameObject completeHeadNeck;

    [Header("Current Body Content")]
    [SerializeField] GameObject current_Bodybones;
    [SerializeField] GameObject current_BodyLigaments, current_BodyMuscles, current_BodyArteries, current_BodyNerves, current_BodySkin, current_BodyVains, current_BodylyphaticSystem, current_BodyOrgans;
    [SerializeField] GameObject completecurrent_Body;

    [SerializeField] GameObject SkeletonSystem_T_Pose;
    [SerializeField] GameObject MuscularSystem_FullBody, FpsShowText;
    public GameObject table;

    [Header("")]
    [SerializeField] string selectedEnglishName, selectedLatinName;
    [SerializeField] public TextMeshPro englishName, latinName;

    [Header("")]
    [SerializeField] public AudioSource audioSource;
    public AudioClip seletcedEnglishVO, selectedLatinVO;
    public GameObject VOButton;

    private bool isSkinOn, isMusclesOn, isLigamentsOn, isArteriesOn, isVainsOn, isNervesOn, isBonesOn, isLyphaticOn, isOrgansOn;

    public GameObject isolationPanel, mainSystemPanel, hideButton, undoButton, LeftSideMuscleIsolatePanel;
    public GameObject label;

    //[SerializeField] public GameObject deltoid_isolate, deltoid_isolate_parent;
    public GameObject currentSelectObject, currentIsolatedObject;
    public int currentSelectedAssetNo;

    public GameObject closeButton, closetoWelcomeBtn, closeButtonNew, isolateButton;

    public bool isIsolatedOn;

    public bool isBoneIsolated;

    public GameObject selectedBone;
    public bool isBoneGrab, isBoneGrabbed;

    public float speed = 0.3f;

    public GameObject skinBtn, ligamentBtn, veinsBtn, nervesBtn, musclesBtn, bonesBtn, arteriesBtn, lymphBtn, organsBtn;
    public GameObject skinBtnPressed, ligamentBtnPressed, veinsBtnPressed, nervesBtnPressed, musclesBtnPressed, bonesBtnPressed, arteriesBtnPressed, lymphBtnPressed, organsBtnPressed;

    public GameObject isolateMuscleBtn, isolateBoneBtn, isolateArteriesBtn, isolateNervesBtn;

    //public GameObject microanatomyFemur, Platform, NervousSystemModel;

    public enum State
    {
        bones,
        muscle,
        art,
        vains,
        nerves,
        lymph,
    }

    public enum btnState
    {
        skin,
        ligaments,
        vains,
        nerves,
        muscles,
        bones,
        arteries,
        lymphs,
        organs,

    }

    public btnState Btn_state;

    public State state;

    public enum Region
    {
        upperLimb,
        lowerLimb,
        thorax,
        abdomen,
        headNeck,
        skeletonSystem,
        muscularSystem,
    }

    public Region region;

    public enum CompleteBody
    {
        completeUpperBody,
        CompleteLowerBody,
        completeThorax,
        completeAbdomen,
        completeHeadNeck,
    }

    public CompleteBody completeBody;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        // Reset();
        FpsShowText.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X) == true || Input.GetKeyDown(KeyCode.A) == true)
        {
            isolateButtonClick();
            if (isBoneIsolated == true)
            {
                if (selectedBone != null)
                {
                    if (isBoneGrab == false)
                    {
                        selectedBone.GetComponent<Rigidbody>().isKinematic = true;
                        selectedBone.GetComponent<BoxCollider>().enabled = false;
                        selectedBone.GetComponent<Rigidbody>().useGravity = false;

                        isBoneGrabbed = true;
                        isBoneGrab = true;

                        IntractionManager.Instance.isDefaultHandGrabAllow = true;
                    }
                    else
                    {
                        isBoneGrabbed = false;
                        isBoneGrab = false;

                        selectedBone.GetComponent<Rigidbody>().isKinematic = false;
                        selectedBone.GetComponent<BoxCollider>().enabled = true;
                        selectedBone.GetComponent<Rigidbody>().useGravity = true;

                        IntractionManager.Instance.isDefaultHandGrabAllow = false;
                        clickCount = 0;
                    }
                }
            }
            else
            {
                
            }
        }

        if (OVRInput.GetDown(OVRInput.RawButton.Y) || Input.GetKeyDown(KeyCode.N))
        {
            isolatedMusclesManager.Instance.hideButtonClick();
      
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Y) || Input.GetKeyDown(KeyCode.M))
        {
            isolatedMusclesManager.Instance.undoButtonClick();
        }
    }

    private void Reset()
    {
        //Gameobjects need to active on start
        welcomeUIPanel.SetActive(true);
        instructionPanel.SetActive(false);

        //gameobjects that need to disableld on start
        completeUpperBody.SetActive(false);
        completelowerBody.SetActive(false);
        completeThorax.SetActive(false);
        completeAbdomen.SetActive(false);
        completeHeadNeck.SetActive(false);

        SkeletonSystem_T_Pose.SetActive(false);
        MuscularSystem_FullBody.SetActive(false);

        humanAnatomyPanels.SetActive(false);
        infoPanel.SetActive(false);
        closeButton.SetActive(false);
        closeButtonNew.SetActive(false);
        closetoWelcomeBtn.SetActive(false);

        //
        isSkinOn = isMusclesOn = isLigamentsOn = isArteriesOn = isVainsOn = isNervesOn = isBonesOn = isLyphaticOn = true;

        //
        upperBodySkin.SetActive(true);
        upperBodyMuscles.SetActive(false);
        upperBodyLigaments.SetActive(false);
        upperBodyArteries.SetActive(false);

        lowerBodySkin.SetActive(true);
        lowerBodyMuscles.SetActive(false);
        lowerBodyLigaments.SetActive(false);
        lowerBodyArteries.SetActive(false);

        ThoraxSkin.SetActive(true);
        ThoraxMuscles.SetActive(false);
        ThoraxLigaments.SetActive(false);
        ThoraxArteries.SetActive(false);

        AbdomenSkin.SetActive(true);
        AbdomenMuscles.SetActive(false);
        AbdomenLigaments.SetActive(false);
        AbdomenArteries.SetActive(false);

        HeadNeckSkin.SetActive(true);
        HeadNeckMuscles.SetActive(false);
        HeadNeckLigaments.SetActive(false);
        HeadNeckArteries.SetActive(false);

        isIsolatedOn = false;
        hideButton.SetActive(false);
        undoButton.SetActive(false);

        isolationPanel.SetActive(false);
        isolateButton.SetActive(false);

        contentPanel.SetActive(false);
        VOButton.SetActive(false);
    }

    public void resetUpperBody()
    {
        upperBodySkin.SetActive(true);
        upperBodyMuscles.SetActive(false);
        upperBodyLigaments.SetActive(false);
        upperBodyArteries.SetActive(false);
        upperBodybones.SetActive(false);
        upperBodyNerves.SetActive(false);
        upperBodyVains.SetActive(false);
        upperBodylyphaticSystem.SetActive(false);

        isSkinOn = true;

        humanAnatomyPanels.SetActive(false);
        infoPanel.SetActive(true);
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

    public void resetThorax()
    {
        ThoraxSkin.SetActive(true);
        ThoraxMuscles.SetActive(false);
        ThoraxLigaments.SetActive(false);
        ThoraxArteries.SetActive(false);
        Thoraxbones.SetActive(false);
        ThoraxNerves.SetActive(false);
        ThoraxVains.SetActive(false);
        ThoraxlyphaticSystem.SetActive(false);
        ThoraxOrgans.SetActive(false);
        isSkinOn = true;

        humanAnatomyPanels.SetActive(false);
        infoPanel.SetActive(true);
    }

    public void resetAbdomen()
    {
        AbdomenSkin.SetActive(true);
        AbdomenMuscles.SetActive(false);
        AbdomenLigaments.SetActive(false);
        AbdomenArteries.SetActive(false);
        Abdomenbones.SetActive(false);
        AbdomenNerves.SetActive(false);
        AbdomenVains.SetActive(false);
        AbdomenlyphaticSystem.SetActive(false);
        AbdomenOrgans.SetActive(false);
        isSkinOn = true;

        humanAnatomyPanels.SetActive(false);
        infoPanel.SetActive(true);
    }

    public void resetHeadNeck()
    {
        HeadNeckSkin.SetActive(true);
        HeadNeckMuscles.SetActive(false);
        HeadNeckLigaments.SetActive(false);
        HeadNeckArteries.SetActive(false);
        HeadNeckbones.SetActive(false);
        HeadNeckNerves.SetActive(false);
        HeadNeckVains.SetActive(false);
        HeadNecklyphaticSystem.SetActive(false);
        HeadNeckOrgans.SetActive(false);
        isSkinOn = true;

        humanAnatomyPanels.SetActive(false);
        infoPanel.SetActive(true);
    }

    public void CloseButtonNewClick()
    {
        ChangeSceneGameManager.Instance.loginscreen = false;
        ChangeSceneGameManager.Instance.grossanatomyscreen = true;
        SceneManager.LoadScene("DEFTXR_Main");
    }

    public void closeToWelcomebutton()
    {
        Reset();
        welcomeUIPanel.SetActive(true);
        closeButtonNew.SetActive(false);
        closetoWelcomeBtn.SetActive(false);
        humanAnatomyPanels.SetActive(false);
        isolationPanel.SetActive(false);
    }

    public void CloseButtonClick()
    {
        isBoneIsolated = false;

        if (region == Region.upperLimb)
        {
            if (state == State.bones)
            {
                isBoneGrabbed = false;
                isBoneGrab = true;
                IntractionManager.Instance.isDefaultHandGrabAllow = true;

                AssetManagementScript.Instance.resetData();

                completeUpperBody.SetActive(true);

                mainSystemPanel.SetActive(true);
                //  resetUpperBody();
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);

                hideButton.SetActive(true);
                undoButton.SetActive(true);

                if (selectedBone != null)
                {
                    selectedBone.GetComponent<FloorCollision>().resetToOrgpos();
                }
                selectedBone = null;

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }

            if (state == State.muscle)
            {
                AssetManagementScript.Instance.resetData();

                completeUpperBody.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                mainSystemPanel.SetActive(true);

                label.SetActive(false);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);;
                hideButton.SetActive(true);
                undoButton.SetActive(true);

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }
        }

        if (region == Region.lowerLimb)
        {
            if (state == State.bones)
            {
                isBoneGrabbed = false;
                isBoneGrab = true;
                IntractionManager.Instance.isDefaultHandGrabAllow = true;

                AssetManagementScript.Instance.resetData();

                completelowerBody.SetActive(true);
                mainSystemPanel.SetActive(true);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);

                hideButton.SetActive(true);
                undoButton.SetActive(true);

                selectedBone.GetComponent<FloorCollision>().resetToOrgpos();
                selectedBone = null;

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }

            if (state == State.muscle)
            {
                AssetManagementScript.Instance.resetData();

                completelowerBody.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                mainSystemPanel.SetActive(true);

                hideButton.SetActive(true);
                undoButton.SetActive(true);

                label.SetActive(false);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }
        }

        if (region == Region.thorax)
        {
            if (state == State.bones)
            {
                isBoneGrabbed = false;
                isBoneGrab = true;
                IntractionManager.Instance.isDefaultHandGrabAllow = true;

                AssetManagementScript.Instance.resetData();
                completeThorax.SetActive(true);
                mainSystemPanel.SetActive(true);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);
                hideButton.SetActive(true);
                undoButton.SetActive(true);

                if (selectedBone != null)
                {
                    selectedBone.GetComponent<FloorCollision>().resetToOrgpos();
                }
                selectedBone = null;

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }

            if (state == State.muscle)
            {
                AssetManagementScript.Instance.resetData();

                completeThorax.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                mainSystemPanel.SetActive(true);

                hideButton.SetActive(false);
                undoButton.SetActive(false);
                label.SetActive(false);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);

                hideButton.SetActive(true);
                undoButton.SetActive(true);

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }
        }

        if (region == Region.abdomen)
        {
            if (state == State.bones)
            {
                isBoneGrabbed = false;
                isBoneGrab = true;
                IntractionManager.Instance.isDefaultHandGrabAllow = true;

                AssetManagementScript.Instance.resetData();
                completeAbdomen.SetActive(true);
                mainSystemPanel.SetActive(true);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);

                hideButton.SetActive(true);
                undoButton.SetActive(true);

                if (selectedBone != null)
                {
                    selectedBone.GetComponent<FloorCollision>().resetToOrgpos();
                }
                selectedBone = null;

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }

            if (state == State.muscle)
            {
                AssetManagementScript.Instance.resetData();
                completeAbdomen.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                mainSystemPanel.SetActive(true);

                hideButton.SetActive(false);
                undoButton.SetActive(false);
                label.SetActive(false);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);
                hideButton.SetActive(true);
                undoButton.SetActive(true);

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }
        }

        if (region == Region.headNeck)
        {
            if (state == State.bones)
            {
                isBoneGrabbed = false;
                isBoneGrab = true;
                IntractionManager.Instance.isDefaultHandGrabAllow = true;

                AssetManagementScript.Instance.resetData();
                completeHeadNeck.SetActive(true);
                mainSystemPanel.SetActive(true);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);

                hideButton.SetActive(true);
                undoButton.SetActive(true);

                if (selectedBone != null)
                {
                    selectedBone.GetComponent<FloorCollision>().resetToOrgpos();
                }
                selectedBone = null;

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }

            if (state == State.muscle)
            {
                AssetManagementScript.Instance.resetData();

                completeHeadNeck.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                mainSystemPanel.SetActive(true);

                hideButton.SetActive(true);
                undoButton.SetActive(true);
                label.SetActive(false);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }
        }
        if (region == Region.skeletonSystem)
        {
            if (state == State.bones)
            {
                isBoneGrabbed = false;
                isBoneGrab = true;
                IntractionManager.Instance.isDefaultHandGrabAllow = true;
                AssetManagementScript.Instance.resetData();
                SkeletonSystem_T_Pose.SetActive(true);
                table.SetActive(false);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);
                contentPanel.SetActive(true);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);
                hideButton.SetActive(true);
                undoButton.SetActive(true);
                selectedBone.GetComponent<FloorCollision>().resetToOrgpos();
                selectedBone = null;

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }

        }
        if (region == Region.muscularSystem)
        {
            if (state == State.muscle)
            {
                AssetManagementScript.Instance.resetData();

                MuscularSystem_FullBody.SetActive(true);
                LeftSideMuscleIsolatePanel.SetActive(false);
                hideButton.SetActive(false);
                undoButton.SetActive(false);
                label.SetActive(false);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                contentPanel.SetActive(true);
                isolationPanel.SetActive(true);
                isolateButton.SetActive(true);
                hideButton.SetActive(true);
                undoButton.SetActive(true);

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }
        }
    }


    public void isolateButtonClick()
    {
        touchInteraction.GetComponent<BoxCollider>().enabled = true;

        if (currentIsolatedObject.GetComponent<myCollisionBehaviour>().publicLable != null)
        {
            currentIsolatedObject.GetComponent<myCollisionBehaviour>().publicLable.SetActive(false);
        }

        IntractionManager.Instance.selectObjName = "";
        isBoneIsolated = true;
        isBoneGrab = false;

        if (region == Region.upperLimb)
        {
            if (state == State.muscle)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedMuscleAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);

                Debug.Log(currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount);

                currentIsolatedObject.transform.GetChild(0).gameObject.SetActive(true);
                for (int i = 0; i < currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount; i++)
                {
                    GameObject chParent = currentIsolatedObject.transform.GetChild(0).transform.GetChild(i).gameObject;
                    chParent.SetActive(true);

                    Debug.Log(chParent.transform.childCount);

                    for (int j = 0; j < chParent.transform.childCount; j++)
                    {
                        chParent.transform.GetChild(j).gameObject.SetActive(true);
                    }
                }

                AssetManagementScript.Instance.setIsolatedMuscleData();

                completeUpperBody.SetActive(false);
                LeftSideMuscleIsolatePanel.SetActive(true);
                mainSystemPanel.SetActive(false);

                hideButton.SetActive(true);
                undoButton.SetActive(false);
                label.SetActive(true);
                closeButton.SetActive(true);
                isolateButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }

            if (state == State.bones)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;
                completeUpperBody.SetActive(false);
                isolationPanel.SetActive(false);
                mainSystemPanel.SetActive(false);

                closeButton.SetActive(true);
                isolateButton.SetActive(false);
                contentPanel.SetActive(false);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }
        }

        if (region == Region.lowerLimb)
        {
            if (state == State.muscle)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedLowerLimbMuscleAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedMuscleData();

                Debug.Log(currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount);

                currentIsolatedObject.transform.GetChild(0).gameObject.SetActive(true);
                for (int i = 0; i < currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount; i++)
                {
                    GameObject chParent = currentIsolatedObject.transform.GetChild(0).transform.GetChild(i).gameObject;
                    chParent.SetActive(true);

                    Debug.Log(chParent.transform.childCount);

                    for (int j = 0; j < chParent.transform.childCount; j++)
                    {
                        chParent.transform.GetChild(j).gameObject.SetActive(true);
                    }
                }

                completelowerBody.SetActive(false);
                LeftSideMuscleIsolatePanel.SetActive(true);
                mainSystemPanel.SetActive(false);

                hideButton.SetActive(true);
                undoButton.SetActive(false);
                label.SetActive(true);

                closeButton.SetActive(true);
                isolateButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }

            if (state == State.bones)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedLowerLimbBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;

                completelowerBody.SetActive(false);
                isolationPanel.SetActive(false);
                mainSystemPanel.SetActive(false);

                closeButton.SetActive(true);
                isolateButton.SetActive(false);
                contentPanel.SetActive(false);

                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }
        }

        if (region == Region.thorax)
        {
            if (state == State.muscle)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedThoraxMuscleAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedMuscleData();

                Debug.Log(currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount);

                currentIsolatedObject.transform.GetChild(0).gameObject.SetActive(true);
                for (int i = 0; i < currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount; i++)
                {
                    GameObject chParent = currentIsolatedObject.transform.GetChild(0).transform.GetChild(i).gameObject;
                    chParent.SetActive(true);

                    Debug.Log(chParent.transform.childCount);

                    for (int j = 0; j < chParent.transform.childCount; j++)
                    {
                        chParent.transform.GetChild(j).gameObject.SetActive(true);
                    }
                }

                completeThorax.SetActive(false);
                LeftSideMuscleIsolatePanel.SetActive(true);
                mainSystemPanel.SetActive(false);

                hideButton.SetActive(true);
                undoButton.SetActive(false);
                label.SetActive(true);

                closeButton.SetActive(true);
                isolateButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }

            if (state == State.bones)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedThoraxBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;
                completeThorax.SetActive(false);
                isolationPanel.SetActive(false);
                mainSystemPanel.SetActive(false);

                closeButton.SetActive(true);
                isolateButton.SetActive(false);
                contentPanel.SetActive(false);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }
        }

        if (region == Region.abdomen)
        {
            if (state == State.muscle)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedAbdomenMuscleAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedMuscleData();

                Debug.Log(currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount);

                currentIsolatedObject.transform.GetChild(0).gameObject.SetActive(true);
                for (int i = 0; i < currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount; i++)
                {
                    GameObject chParent = currentIsolatedObject.transform.GetChild(0).transform.GetChild(i).gameObject;
                    chParent.SetActive(true);

                    Debug.Log(chParent.transform.childCount);

                    for (int j = 0; j < chParent.transform.childCount; j++)
                    {
                        chParent.transform.GetChild(j).gameObject.SetActive(true);
                    }
                }

                completeAbdomen.SetActive(false);
                LeftSideMuscleIsolatePanel.SetActive(true);
                mainSystemPanel.SetActive(false);

                hideButton.SetActive(true);
                undoButton.SetActive(false);
                label.SetActive(true);

                closeButton.SetActive(true);
                isolateButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }

            if (state == State.bones)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedAbdomenBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;

                completeAbdomen.SetActive(false);
                isolationPanel.SetActive(false);
                mainSystemPanel.SetActive(false);

                closeButton.SetActive(true);
                isolateButton.SetActive(false);
                contentPanel.SetActive(false);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }
        }

        if (region == Region.headNeck)
        {
            if (state == State.muscle)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedHeadNeckMuscleAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedMuscleData();

                Debug.Log(currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount);

                currentIsolatedObject.transform.GetChild(0).gameObject.SetActive(true);
                for (int i = 0; i < currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount; i++)
                {
                    GameObject chParent = currentIsolatedObject.transform.GetChild(0).transform.GetChild(i).gameObject;
                    chParent.SetActive(true);

                    Debug.Log(chParent.transform.childCount);

                    for (int j = 0; j < chParent.transform.childCount; j++)
                    {
                        chParent.transform.GetChild(j).gameObject.SetActive(true);
                    }
                }

                completeHeadNeck.SetActive(false);
                LeftSideMuscleIsolatePanel.SetActive(true);
                mainSystemPanel.SetActive(false);

                hideButton.SetActive(true);
                undoButton.SetActive(false);
                label.SetActive(true);

                closeButton.SetActive(true);
                isolateButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }

            if (state == State.bones)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedHeadNeckBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;

                completeHeadNeck.SetActive(false);
                isolationPanel.SetActive(false);
                mainSystemPanel.SetActive(false);

                closeButton.SetActive(true);
                isolateButton.SetActive(false);
                contentPanel.SetActive(false);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }
        }

        if (region == Region.skeletonSystem)
        {
            if (state == State.bones)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedSkeletonBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;
                SkeletonSystem_T_Pose.SetActive(false);
                table.SetActive(true);

                isolationPanel.SetActive(false);
                closeButton.SetActive(true);
                isolateButton.SetActive(false);

                contentPanel.SetActive(false);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);
                hideButton.SetActive(false);
                undoButton.SetActive(false);

                isIsolatedOn = true;
            }
        }

        if (region == Region.muscularSystem)
        {
            if (state == State.muscle)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedMuscularSystemMuscleAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedMuscleData();

                Debug.Log(currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount);

                currentIsolatedObject.transform.GetChild(0).gameObject.SetActive(true);
                for (int i = 0; i < currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount; i++)
                {
                    GameObject chParent = currentIsolatedObject.transform.GetChild(0).transform.GetChild(i).gameObject;
                    chParent.SetActive(true);

                    Debug.Log(chParent.transform.childCount);

                    for (int j = 0; j < chParent.transform.childCount; j++)
                    {
                        chParent.transform.GetChild(j).gameObject.SetActive(true);
                    }
                }

                MuscularSystem_FullBody.SetActive(false);
                LeftSideMuscleIsolatePanel.SetActive(true);
                mainSystemPanel.SetActive(false);

                hideButton.SetActive(true);
                undoButton.SetActive(false);
                label.SetActive(true);

                closeButton.SetActive(true);
                isolateButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }
        }
    }
    public void loginButtonClick()
    {
        welcomeUIPanel.SetActive(false);
        humanAnatomyPanels.SetActive(true);
        grossAnatomyPanel.SetActive(false);
        closetoWelcomeBtn.SetActive(true);
        closeButton.SetActive(false);
        closeButtonNew.SetActive(false);
    }

    public void upperLimbButtonClick()
    {
        isDisection = false;
        completeUpperBody.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        region = Region.upperLimb;
        setContent();
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);

        mainSystemPanel.SetActive(true);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(true);

        hideButton.SetActive(true);
        undoButton.SetActive(true);
        isSkinOn = false;
        onSkinButtonClick();
    }

    public void UpperLimbsetDisection()
    {
        isDisection = true;
        completeUpperBody.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        mainSystemPanel.SetActive(false);;
        isolationPanel.SetActive(true);
        isolateButton.SetActive(false);
    }

    public void LowerLimbsetDisection()
    {
        isDisection = true;
        completelowerBody.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        mainSystemPanel.SetActive(false);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(false);
    }

    public void ThoraxsetDisection()
    {
        isDisection = true;
        completeThorax.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        mainSystemPanel.SetActive(false);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(false);
    }

    public void AbdomensetDisection()
    {
        isDisection = true;
        completeAbdomen.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        mainSystemPanel.SetActive(false);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(false);
    }
    public void HeadNecksetDisection()
    {
        isDisection = true;
        completeHeadNeck.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        mainSystemPanel.SetActive(false);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(false);
    }

    public void lowerLimbButtonClick()
    {
        isDisection = false;
        completelowerBody.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        region = Region.lowerLimb;
        setContent();
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(true);
        hideButton.SetActive(true);
        undoButton.SetActive(true);
        mainSystemPanel.SetActive(true);
        isSkinOn = false;
        onSkinButtonClick();
    }

    public void thoraxButtonClick()
    {
        isDisection = false;
        completeThorax.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        region = Region.thorax;
        setContent();
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(true);
        hideButton.SetActive(true);
        undoButton.SetActive(true);
        mainSystemPanel.SetActive(true);
        isSkinOn = false;
        onSkinButtonClick();
    }

    public void abdomenButtonClick()
    {
        isDisection = false;
        completeAbdomen.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        region = Region.abdomen;
        setContent();
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(true);
        hideButton.SetActive(true);
        undoButton.SetActive(true);
        mainSystemPanel.SetActive(true);
        isSkinOn = false;
        onSkinButtonClick();
    }

    public void headNeckButtonClick()
    {
        isDisection = false;
        completeHeadNeck.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        region = Region.headNeck;
        setContent();
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(true);
        hideButton.SetActive(true);
        undoButton.SetActive(true);
        mainSystemPanel.SetActive(true);
        isSkinOn = false;
        onSkinButtonClick();
    }
    public void skeletonButtonClick()
    {
        SkeletonSystem_T_Pose.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        region = Region.skeletonSystem;
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(true);
        hideButton.SetActive(true);
        undoButton.SetActive(true);
    }

    public void muscularButtonClick()
    {
        MuscularSystem_FullBody.SetActive(true);
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        mainSystemPanel.SetActive(false);
        region = Region.muscularSystem;
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
        isolationPanel.SetActive(true);
        isolateButton.SetActive(true);
        hideButton.SetActive(true);
        undoButton.SetActive(true);
    }

    public void microAnatomyButtonClick()
    {
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        closeButtonNew.SetActive(true);
        isolationPanel.SetActive(true);

        isBoneIsolated = true;
    }

    public void NervousSystemButtonClick()
    {
        infoPanel.SetActive(true);
        contentPanel.SetActive(true);
        closeButtonNew.SetActive(true);
    }

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
    public void onSkinButtonClick()
    {

        if (isSkinOn == false)
        {
            current_BodySkin.SetActive(true);
            skinBtn.SetActive(false);
            skinBtnPressed.SetActive(true);

            current_BodyMuscles.SetActive(false);
            musclesBtn.SetActive(false);
            musclesBtnPressed.SetActive(true);

            current_BodyLigaments.SetActive(false);
            ligamentBtn.SetActive(false);
            ligamentBtnPressed.SetActive(true);

            current_BodyArteries.SetActive(false);
            arteriesBtn.SetActive(false);
            arteriesBtnPressed.SetActive(true);

            current_Bodybones.SetActive(false);
            bonesBtn.SetActive(false);
            bonesBtnPressed.SetActive(true);

            current_BodyNerves.SetActive(false);
            nervesBtn.SetActive(false);
            nervesBtnPressed.SetActive(true);

            current_BodyVains.SetActive(false);
            veinsBtn.SetActive(false);
            veinsBtnPressed.SetActive(true);

            current_BodylyphaticSystem.SetActive(false);
            lymphBtn.SetActive(false);
            lymphBtnPressed.SetActive(true);

            if (current_BodyOrgans != null)
            {
                current_BodyOrgans.SetActive(false);
                organsBtn.SetActive(false);
                organsBtnPressed.SetActive(true);
            }

            isSkinOn = true;
            hideButton.SetActive(false);
            undoButton.SetActive(false);
        }
        else
        {
            current_BodySkin.SetActive(false);
            skinBtn.SetActive(true);
            skinBtnPressed.SetActive(false);

            current_BodyMuscles.SetActive(true);

            current_BodyLigaments.SetActive(true);

            current_BodyArteries.SetActive(true);

            current_Bodybones.SetActive(true);

            current_BodyNerves.SetActive(true);

            current_BodyVains.SetActive(true);

            current_BodylyphaticSystem.SetActive(true);

            if (current_BodyOrgans != null)
            {
                current_BodyOrgans.SetActive(true);
            }

            isSkinOn = false;
            hideButton.SetActive(true);
            undoButton.SetActive(true);
        }
    }

    public void onMusclesButtonClick()
    {
        if (isMusclesOn == true)
        {
            current_BodyMuscles.SetActive(true);
            musclesBtn.SetActive(false);
            musclesBtnPressed.SetActive(true);
            isMusclesOn = false;
        }
        else
        {
            current_BodyMuscles.SetActive(false);
            musclesBtn.SetActive(true);
            musclesBtnPressed.SetActive(false);
            isMusclesOn = true;
        }
    }
    public void onLigamentsButtonClick()
    {
        if (isLigamentsOn == true)
        {
            current_BodyLigaments.SetActive(true);
            ligamentBtn.SetActive(false);
            ligamentBtnPressed.SetActive(true);
            isLigamentsOn = false;
        }
        else
        {
            current_BodyLigaments.SetActive(false);
            ligamentBtn.SetActive(true);
            ligamentBtnPressed.SetActive(false);
            isLigamentsOn = true;
        }
    }
    public void onArtriesButtonClick()
    {
        if (isArteriesOn == true)
        {
            current_BodyArteries.SetActive(true);
            arteriesBtn.SetActive(false);
            arteriesBtnPressed.SetActive(true);
            isArteriesOn = false;
        }
        else
        {
            current_BodyArteries.SetActive(false);
            arteriesBtn.SetActive(true);
            arteriesBtnPressed.SetActive(false);
            isArteriesOn = true;
        }
    }

    public void onVainsButtonClick()
    {
        if (isVainsOn == true)
        {
            current_BodyVains.SetActive(true);
            veinsBtn.SetActive(false);
            veinsBtnPressed.SetActive(true);
            isVainsOn = false;
        }
        else
        {
            current_BodyVains.SetActive(false);
            veinsBtn.SetActive(true);
            veinsBtnPressed.SetActive(false);
            isVainsOn = true;
        }
    }

    public void onNervesButtonClick()
    {
        if (isNervesOn == true)
        {
            current_BodyNerves.SetActive(true);
            nervesBtn.SetActive(false);
            nervesBtnPressed.SetActive(true);
            isNervesOn = false;
        }
        else
        {
            current_BodyNerves.SetActive(false);
            nervesBtn.SetActive(true);
            nervesBtnPressed.SetActive(false);
            isNervesOn = true;
        }
    }
    public void onBonesButtonClick()
    {
        if (isBonesOn == true)
        {
            current_Bodybones.SetActive(true);
            bonesBtn.SetActive(false);
            bonesBtnPressed.SetActive(true);
            isBonesOn = false;
        }
        else
        {
            current_Bodybones.SetActive(false);
            bonesBtn.SetActive(true);
            bonesBtnPressed.SetActive(false);
            isBonesOn = true;
        }
    }

    public void onLymphaticButtonClick()
    {
        if (isLyphaticOn == true)
        {
            current_BodylyphaticSystem.SetActive(true);
            lymphBtn.SetActive(false);
            lymphBtnPressed.SetActive(true);
            isLyphaticOn = false;
        }
        else
        {
            current_BodylyphaticSystem.SetActive(false);
            lymphBtn.SetActive(true);
            lymphBtnPressed.SetActive(false);
            isLyphaticOn = true;
        }
    }

    public void onOrgansButtonClick()
    {
        if (isOrgansOn == true)
        {
            current_BodyOrgans.SetActive(true);
            organsBtn.SetActive(false);
            organsBtnPressed.SetActive(true);
            isOrgansOn = false;
        }
        else
        {
            current_BodyOrgans.SetActive(false);
            organsBtn.SetActive(true);
            organsBtnPressed.SetActive(false);
            isOrgansOn = true;
        }
    }

    public void playEnglishVO()
    {
        if (seletcedEnglishVO != null)
        {
            audioSource.PlayOneShot(seletcedEnglishVO);
            Debug.Log("caled");
        }
    }

    IEnumerator waitForSound()
    {
        audioSource.PlayOneShot(seletcedEnglishVO);
        VOButton.GetComponent<Button>().interactable = false;

        //Wait Until Sound has finished playing
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        VOButton.GetComponent<Button>().interactable = true;
    }

    public void playLatinVO()
    {
        if (selectedLatinVO != null)
        {
            audioSource.PlayOneShot(selectedLatinVO);
        }
    }

    public void setContent()
    {
        if (region == Region.upperLimb)
        {
            current_BodySkin = upperBodySkin;
            current_BodyMuscles = upperBodyMuscles;
            current_BodyLigaments = upperBodyLigaments;
            current_BodyArteries = upperBodyArteries;
            current_Bodybones = upperBodybones;
            current_BodyNerves = upperBodyNerves;
            current_BodyVains = upperBodyVains;
            current_BodylyphaticSystem = upperBodylyphaticSystem;
        }

        if (region == Region.lowerLimb)
        {
            current_BodySkin = lowerBodySkin;
            current_BodyMuscles = lowerBodyMuscles;
            current_BodyLigaments = lowerBodyLigaments;
            current_BodyArteries = lowerBodyArteries;
            current_Bodybones = lowerBodybones;
            current_BodyNerves = lowerBodyNerves;
            current_BodyVains = lowerBodyVains;
            current_BodylyphaticSystem = lowerBodylyphaticSystem;
        }

        if (region == Region.thorax)
        {
            current_BodySkin = ThoraxSkin;
            current_BodyMuscles = ThoraxMuscles;
            current_BodyLigaments = ThoraxLigaments;
            current_BodyArteries = ThoraxArteries;
            current_Bodybones = Thoraxbones;
            current_BodyNerves = ThoraxNerves;
            current_BodyVains = ThoraxVains;
            current_BodylyphaticSystem = ThoraxlyphaticSystem;
            current_BodyOrgans = ThoraxOrgans;
        }

        if (region == Region.abdomen)
        {
            current_BodySkin = AbdomenSkin;
            current_BodyMuscles = AbdomenMuscles;
            current_BodyLigaments = AbdomenLigaments;
            current_BodyArteries = AbdomenArteries;
            current_Bodybones = Abdomenbones;
            current_BodyNerves = AbdomenNerves;
            current_BodyVains = AbdomenVains;
            current_BodylyphaticSystem = AbdomenlyphaticSystem;
            current_BodyOrgans = AbdomenOrgans;
        }

        if (region == Region.headNeck)
        {
            current_BodySkin = HeadNeckSkin;
            current_BodyMuscles = HeadNeckMuscles;
            current_BodyLigaments = HeadNeckLigaments;
            current_BodyArteries = HeadNeckArteries;
            current_Bodybones = HeadNeckbones;
            current_BodyNerves = HeadNeckNerves;
            current_BodyVains = HeadNeckVains;
            current_BodylyphaticSystem = HeadNecklyphaticSystem;
            current_BodyOrgans = HeadNeckOrgans;
        }
    }
}
