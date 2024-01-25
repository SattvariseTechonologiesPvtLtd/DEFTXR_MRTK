
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
    public AudioClip tickSound;
    public bool isDisection;

    public GameObject HomeButton, LayersButton, ResetButton, ResetAllButton, EnviromentButton, LayersButtonPressed, EnviromentButtonPressed, ExploreButtonPressed;
    public GameObject MainUiPanel, YPanel,LayersUI, SkyboxUI, layerbutton, layerPressed;
    public GameObject MenuButtonHighLight, YButtonHighLight, BButtonHighLight, AButtonHighLight, XButtonHighLight;

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

    [Header("")]
    [SerializeField] string selectedEnglishName, selectedLatinName;
    [SerializeField] public TextMeshPro englishName, latinName;

    [Header("")]
    [SerializeField] public AudioSource audioSource;
    public AudioClip seletcedEnglishVO, selectedLatinVO;
    public GameObject VOButton;

    private bool isSkinOn, isMusclesOn, isLigamentsOn, isArteriesOn, isVainsOn, isNervesOn, isBonesOn, isLyphaticOn, isOrgansOn;

    public GameObject currentSelectObject, currentIsolatedObject;
    public int currentSelectedAssetNo;

    public Material orgVains, orgArt, orgLymph, orgNervs;
    public Material _hVains, _hArt, _hLymph, _hNervs;

    public GameObject closeButton, closetoWelcomeBtn, closeButtonNew;

    public bool isIsolatedOn;
    public bool isBoneIsolated;

    public GameObject selectedBone;
    public GameObject boneGrabRef;
    public bool isBoneGrab, isBoneGrabbed;

    public GameObject skinBtn, ligamentBtn, veinsBtn, nervesBtn, musclesBtn, bonesBtn, arteriesBtn, lymphBtn, organsBtn;
    public GameObject skinBtnPressed, ligamentBtnPressed, veinsBtnPressed, nervesBtnPressed, musclesBtnPressed, bonesBtnPressed, arteriesBtnPressed, lymphBtnPressed, organsBtnPressed;

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

        MenuButtonHighLight.SetActive(true);
        YButtonHighLight.SetActive(false);
        BButtonHighLight.SetActive(false);
        AButtonHighLight.SetActive(false);
        XButtonHighLight.SetActive(false);
        MainUiPanel.SetActive(false);
        YPanel.SetActive(false);
        LayersUI.SetActive(false);
        SkyboxUI.SetActive(false);
    }

    public void InstructionBtnClick()
    {

    }

    public void backFromInstruBtnClick()
    {

    }

    public void onLayersPanelButtonClick()
    {
        layerbutton.SetActive(false);
        layerPressed.SetActive(true);
        LayersUI.SetActive(true);
        YPanel.SetActive(false);
    }

    public void onLayersPanelPressedButtonClick()
    {
        layerbutton.SetActive(true);
        layerPressed.SetActive(false);
        LayersUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for controller input
        if (OVRInput.GetDown(OVRInput.Button.Start)) // Adjust the button to the desired input
        {
            // Toggle the UI panel
            MenuButtonHighLight.SetActive(!MenuButtonHighLight.activeSelf);
            MainUiPanel.SetActive(!MainUiPanel.activeSelf);
        }

        if (OVRInput.GetDown(OVRInput.RawButton.Y)) // Adjust the button to the desired input
        {
            // Toggle the UI panel
            YButtonHighLight.SetActive(!YButtonHighLight.activeSelf);
            YPanel.SetActive(!YPanel.activeSelf);
        }
    }

    private void Reset()
    {
        //gameobjects that need to disable on start

        completeUpperBody.SetActive(false);
        completelowerBody.SetActive(false);
        completeThorax.SetActive(false);
        completeAbdomen.SetActive(false);
        completeHeadNeck.SetActive(false);

        SkeletonSystem_T_Pose.SetActive(false);
        MuscularSystem_FullBody.SetActive(false);

        closeButton.SetActive(false);
        closeButtonNew.SetActive(false);
        closetoWelcomeBtn.SetActive(false);

        isSkinOn = isMusclesOn = isLigamentsOn = isArteriesOn = isVainsOn = isNervesOn = isBonesOn = isLyphaticOn = true;

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
    }

    //Temp
    /*public void CloseButtonNewClick()
    {
        if (currentIsolatedObject != null)
        {
             Material myOriginalMat = currentIsolatedObject.gameObject.GetComponent<Renderer>().material;

             myOriginalMat.color = Color.white;
             myOriginalMat.SetFloat("_Glossiness", 1f);
             if (currentIsolatedObject.GetComponent<myCollisionBehaviour>().publicLable != null)
             {
                 currentIsolatedObject.GetComponent<myCollisionBehaviour>().publicLable.SetActive(false);
             }
        }

        IntractionManager.Instance.selectObjName = "";
        closetoWelcomeBtn.SetActive(true);

        //gameobjects that need to disableld on start
        completeUpperBody.SetActive(false);
        completelowerBody.SetActive(false);
        completeThorax.SetActive(false);

        closeButton.SetActive(false);
        closeButtonNew.SetActive(false);

        upperBodySkin.SetActive(true);
        upperBodyMuscles.SetActive(false);
        upperBodyLigaments.SetActive(false);
        upperBodyArteries.SetActive(false);

        lowerBodySkin.SetActive(true);
        lowerBodyMuscles.SetActive(false);
        lowerBodyLigaments.SetActive(false);
        lowerBodyArteries.SetActive(false);

        isIsolatedOn = false;
        VOButton.SetActive(false);

        ChangeSceneGameManager.Instance.loginscreen = false;
        ChangeSceneGameManager.Instance.grossanatomyscreen = true;
        SceneManager.LoadScene("DEFTXR_Main");
    }*/

    public void closeToWelcomebutton()
    {
        Reset();
        closeButtonNew.SetActive(false);
        closetoWelcomeBtn.SetActive(false);
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

                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                completeUpperBody.SetActive(true);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //New Changes.

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

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
                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //New Changes.

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

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

                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                completelowerBody.SetActive(true);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //New Changes.

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

                selectedBone.GetComponent<FloorCollision>().resetToOrgpos();
                selectedBone = null;

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }

            if (state == State.muscle)
            {
                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                completelowerBody.SetActive(true);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //New Changes.

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

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

                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                completeThorax.SetActive(true);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //New Changes.

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

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
                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                completeThorax.SetActive(true);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //New Changes.

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

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

                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                completeAbdomen.SetActive(true);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //New Changes

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

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
                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                completeAbdomen.SetActive(true);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //New Chnages

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

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

                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                completeHeadNeck.SetActive(true);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //New Changes.

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

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
                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                completeHeadNeck.SetActive(true);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //New Changes.

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

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
                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();
                SkeletonSystem_T_Pose.SetActive(true);
                isIsolatedOn = false;

                //New Changes

                //Controller Buttons Highlights ON/OFF
                XButtonHighLight.SetActive(false);
                YButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);
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
                currentIsolatedObject.SetActive(false);
                currentIsolatedObject = null;
                AssetManagementScript.Instance.resetData();

                MuscularSystem_FullBody.SetActive(true);

                //New Changes

                //Controller Buttons Highlights ON/OFF
                XButtonHighLight.SetActive(false);
                YButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }
        }
    }


    public void isolateButtonClick()
    {
        Material myOriginalMat = currentIsolatedObject.gameObject.GetComponent<Renderer>().material;
        myOriginalMat.color = Color.white;
        myOriginalMat.SetFloat("_Glossiness", 1f);

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

                //New Changes
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

                //New Changes.
                YPanel.SetActive(true);
                LayersUI.SetActive(true);

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                YButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);

                closeButton.SetActive(true);
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

                //New Changes.

                //Controller Buttons Highlights ON/OFF
                YButtonHighLight.SetActive(true);
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(true);
                MenuButtonHighLight.SetActive(false);

                LayersUI.SetActive(false);
                closeButton.SetActive(true);
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

                //New Changes.
                YPanel.SetActive(false);
                LayersUI.SetActive(false);

                //Controller Buttons Highlights ON/OFF
                YButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);

                closeButton.SetActive(true);
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

                //New Changes.
                YPanel.SetActive(false);
                MainUiPanel.SetActive(false);

                //Controller Buttons Highlights ON/OFF
                MenuButtonHighLight.SetActive(false);
                YButtonHighLight.SetActive(false);
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);

                closeButtonNew.SetActive(true);
                LayersUI.SetActive(false);
                layerPressed.SetActive(false);
                layerbutton.SetActive(true);
                XButtonHighLight.SetActive(true);
                closeButton.SetActive(true);

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

                //New Changes.
                YPanel.SetActive(true);
                LayersUI.SetActive(true);

                //Controller Buttons Highlights ON/OFF
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                XButtonHighLight.SetActive(false);
                YButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);

                closeButton.SetActive(true);
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

                //New Changes.
                //Controller Buttons Highlights ON/OFF
                YButtonHighLight.SetActive(true);
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                closeButtonNew.SetActive(true);
                LayersUI.SetActive(false);
                XButtonHighLight.SetActive(true);

                closeButton.SetActive(true);
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

                //New Changes.
                YPanel.SetActive(true);
                LayersUI.SetActive(true);
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);

                closeButton.SetActive(true);
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

                //New Changes.
                YButtonHighLight.SetActive(true);
                BButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                closeButtonNew.SetActive(true);
                LayersUI.SetActive(false);
                XButtonHighLight.SetActive(true);

                closeButton.SetActive(true);
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

                 //New Changes.
                 YPanel.SetActive(true);
                 LayersUI.SetActive(true);
                 BButtonHighLight.SetActive(false);
                 AButtonHighLight.SetActive(false);

                 closeButton.SetActive(true);
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

                 //New Changes.
                 YButtonHighLight.SetActive(true);
                 BButtonHighLight.SetActive(false);
                 AButtonHighLight.SetActive(false);
                 closeButtonNew.SetActive(true);
                 LayersUI.SetActive(false);
                 XButtonHighLight.SetActive(true);
 
                 closeButton.SetActive(true);
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

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

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

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                isIsolatedOn = true;
            }
        }
    }
    public void loginButtonClick()
    {
        closetoWelcomeBtn.SetActive(true);
        closeButton.SetActive(false);
        closeButtonNew.SetActive(false);
    }

    public void upperLimbButtonClick()
    {
        isDisection = false;
        completeUpperBody.SetActive(true);
        region = Region.upperLimb;
        setContent();
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);

        isSkinOn = false;
        onSkinButtonClick();
    }

    public void UpperLimbsetDisection()
    {
        isDisection = true;
        completeUpperBody.SetActive(true);
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
    }

    public void LowerLimbsetDisection()
    {
        isDisection = true;
        completelowerBody.SetActive(true);
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
    }

    public void ThoraxsetDisection()
    {
        isDisection = true;
        completeThorax.SetActive(true);
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);

    }

    public void AbdomensetDisection()
    {
        isDisection = true;
        completeAbdomen.SetActive(true);
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
    }
    public void HeadNecksetDisection()
    {
        isDisection = true;
        completeHeadNeck.SetActive(true);
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
    }


    public void lowerLimbButtonClick()
    {
        isDisection = false;
        completelowerBody.SetActive(true);

        //New Changes.
        MenuButtonHighLight.SetActive(true);
        XButtonHighLight.SetActive(true);

        region = Region.lowerLimb;
        setContent();

        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);

        isSkinOn = false;
        onSkinButtonClick();
    }

    public void thoraxButtonClick()
    {
        isDisection = false;
        completeThorax.SetActive(true);

        //New Changes.
        MenuButtonHighLight.SetActive(true);
        XButtonHighLight.SetActive(true);

        region = Region.thorax;
        setContent();

        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);

        isSkinOn = false;
        onSkinButtonClick();
    }

    public void abdomenButtonClick()
    {
        isDisection = false;
        completeAbdomen.SetActive(true);

        //New Changes.
        MenuButtonHighLight.SetActive(true);
        XButtonHighLight.SetActive(true);

        region = Region.abdomen;
        setContent();

        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);

        isSkinOn = false;
        onSkinButtonClick();
    }

    public void headNeckButtonClick()
    {
        isDisection = false;
        completeHeadNeck.SetActive(true);

        //New Changes.
        MenuButtonHighLight.SetActive(true);
        XButtonHighLight.SetActive(true);

        region = Region.headNeck;
        setContent();

        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);

        isSkinOn = false;
        onSkinButtonClick();
    }

    public void skeletonButtonClick()
    {
        SkeletonSystem_T_Pose.SetActive(true);
        region = Region.skeletonSystem;
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
    }

    public void muscularButtonClick()
    {
        MuscularSystem_FullBody.SetActive(true);
        region = Region.muscularSystem;
        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
    }

    public void microAnatomyButtonClick()
    {

        closeButtonNew.SetActive(true);

        isBoneIsolated = true;
    }

    public void NervousSystemButtonClick()
    {
        closeButtonNew.SetActive(true);
    }



    /// <summary>
    /// Below methods consist of Panel Button click calls 
    /// ------------------------------------------------ Start --------------------------------
    /// </summary>
    /*public void regionsPanelButtonClick()
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

    }*/

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
            current_BodySkin.SetActive(true);
            //skinBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            skinBtn.SetActive(false);
            skinBtnPressed.SetActive(true);

            current_BodyMuscles.SetActive(false);
           // musclesBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            musclesBtn.SetActive(true);
            musclesBtnPressed.SetActive(false);

            current_BodyLigaments.SetActive(false);
            //ligamentBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            ligamentBtn.SetActive(true);
            ligamentBtnPressed.SetActive(false);

            current_BodyArteries.SetActive(false);
           // arteriesBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            arteriesBtn.SetActive(true);
            arteriesBtnPressed.SetActive(false);

            current_Bodybones.SetActive(false);
           // bonesBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            bonesBtn.SetActive(true);
            bonesBtnPressed.SetActive(false);

            current_BodyNerves.SetActive(false);
           // nervesBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            nervesBtn.SetActive(true);
            nervesBtnPressed.SetActive(false);

            current_BodyVains.SetActive(false);
           // veinsBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            veinsBtn.SetActive(true);
            veinsBtnPressed.SetActive(false);

            current_BodylyphaticSystem.SetActive(false);
           // lymphBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            lymphBtn.SetActive(true);
            lymphBtnPressed.SetActive(false);

            if (current_BodyOrgans != null)
            {
                current_BodyOrgans.SetActive(false);
                //organsBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
                organsBtn.SetActive(true);
                organsBtnPressed.SetActive(false);
            }

            isSkinOn = true;

        }
        else
        {
            current_BodySkin.SetActive(false);
            //skinBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            skinBtn.SetActive(true);
            skinBtnPressed.SetActive(false);

            current_BodyMuscles.SetActive(true);
           // musclesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            musclesBtn.SetActive(false);
            musclesBtnPressed.SetActive(true);

            current_BodyLigaments.SetActive(true);
           // ligamentBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            ligamentBtn.SetActive(false);
            ligamentBtnPressed.SetActive(true);

            current_BodyArteries.SetActive(true);
           // arteriesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            arteriesBtn.SetActive(false);
            arteriesBtnPressed.SetActive(true);

            current_Bodybones.SetActive(true);
           // bonesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            bonesBtn.SetActive(false);
            bonesBtnPressed.SetActive(true);

            current_BodyNerves.SetActive(true);
           // nervesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            nervesBtn.SetActive(false);
            nervesBtnPressed.SetActive(true);

            current_BodyVains.SetActive(true);
          //  veinsBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            veinsBtn.SetActive(false);
            veinsBtnPressed.SetActive(true);

            current_BodylyphaticSystem.SetActive(true);
           // lymphBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            lymphBtn.SetActive(false);
            lymphBtnPressed.SetActive(true);

            if (current_BodyOrgans != null)
            {
                current_BodyOrgans.SetActive(true);
             //   organsBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
                organsBtn.SetActive(false);
                organsBtnPressed.SetActive(true);
            }

            isSkinOn = false;
        }
    }

    public void onMusclesButtonClick()
    {
        if (isMusclesOn == true)
        {
            current_BodyMuscles.SetActive(true);
           // musclesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            musclesBtn.SetActive(false);
            musclesBtnPressed.SetActive(true);
            isMusclesOn = false;
        }
        else
        {
            current_BodyMuscles.SetActive(false);
            //musclesBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
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
           // ligamentBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            ligamentBtn.SetActive(false);
            ligamentBtnPressed.SetActive(true);
            isLigamentsOn = false;
        }
        else
        {
            current_BodyLigaments.SetActive(false);
           // ligamentBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
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
           // arteriesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            arteriesBtn.SetActive(false);
            arteriesBtnPressed.SetActive(true);
            isArteriesOn = false;
        }
        else
        {
            current_BodyArteries.SetActive(false);
           // arteriesBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
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
           // veinsBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            veinsBtn.SetActive(false);
            veinsBtnPressed.SetActive(true);
            isVainsOn = false;
        }
        else
        {
            current_BodyVains.SetActive(false);
           // veinsBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
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
           // nervesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            nervesBtn.SetActive(false);
            nervesBtnPressed.SetActive(true);
            isNervesOn = false;
        }
        else
        {
            current_BodyNerves.SetActive(false);
           // nervesBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
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
           // bonesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            bonesBtn.SetActive(false);
            bonesBtnPressed.SetActive(true);
            isBonesOn = false;
        }
        else
        {
            current_Bodybones.SetActive(false);
           // bonesBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
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
           // lymphBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            lymphBtn.SetActive(false);
            lymphBtnPressed.SetActive(true);
            isLyphaticOn = false;
        }
        else
        {
            current_BodylyphaticSystem.SetActive(false);
           // lymphBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
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
           // organsBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            organsBtn.SetActive(false);
            organsBtnPressed.SetActive(true);
            isOrgansOn = false;
        }
        else
        {
            current_BodyOrgans.SetActive(false);
           // organsBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            organsBtn.SetActive(true);
            organsBtnPressed.SetActive(false);
            isOrgansOn = true;
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
            Debug.Log("caled");
          //  StartCoroutine(waitForSound());
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

        //Auidio has finished playing, disable GameObject
        //  other.gameObject.SetActive(false);
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

    /// if region == Uperlimb/lowerlimb/thorax
     //       current_Bodybones  = upperlimbbones,
    /// currentbone =  selectedBones
    ///

}
