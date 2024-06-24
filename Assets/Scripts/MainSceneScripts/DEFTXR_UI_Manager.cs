
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MixedReality.Toolkit.SpatialManipulation;
using Nova;
using MixedReality.Toolkit.Input;



public class DEFTXR_UI_Manager : MonoBehaviour
{
    public ArticulatedHandController handref;
    public static DEFTXR_UI_Manager Instance;
    public TextMeshPro content;
    public int clickCount;

    public GameObject touchInteraction;
    public bool isDisection, isPinched;

    public GameObject MenuParentObject, MainUIPanel, HandMenuBar, LayersUIPanel, SkyboxUIPanel, FeaturesUIPanel;
    public GameObject MenuButton, LayerButton, SkyboxButton, GizmoButton, IsolateButton, HideButton, UndoButton;
    public GameObject MenuButtonPressed, LayerButtonPressed, SkyboxButtonPressed, GizmoButtonPressed, IsolateButtonPressed;
    //public GameObject XButtonHighLight, YButtonHighLight, AButtonHighLight, BButtonHighLight, MenuButtonHighLight;

    [Header("")]
    [Header("Upper Body Content")]
    [SerializeField] GameObject upperBodybones;
    [SerializeField] GameObject upperBodyLigaments, upperBodyMuscles, upperBodyArteries, upperBodyNerves, upperBodySkin, upperBodyVains, upperBodylyphaticSystem;
    [SerializeField] GameObject completeUpperBody;

    [Header("Lower Body Content")]
    [SerializeField] GameObject lowerBodybones;
    [SerializeField] GameObject lowerBodyLigaments, lowerBodyMuscles, lowerBodyArteries, lowerBodyNerves, lowerBodySkin, lowerBodyVains, lowerBodylyphaticSystem;
    //[SerializeField] GameObject lowerBodybonesLeft, lowerBodyLigamentsLeft, lowerBodyMusclesLeft, lowerBodyArteriesLeft, lowerBodyNervesLeft, lowerBodySkinLeft, lowerBodyVainsLeft, lowerBodylyphaticSystemLeft;       
    [SerializeField] public GameObject completelowerBody;

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

    [Header("")]
    [SerializeField] string selectedEnglishName, selectedLatinName;
    [SerializeField] public TextMeshPro englishName, latinName;

    [Header("")]
    [SerializeField] public AudioSource audioSource;
    public AudioClip seletcedEnglishVO, selectedLatinVO;
    public GameObject VOButton, completeSkeletalSystem;

    private bool isSkinOn, isMusclesOn, isLigamentsOn, isArteriesOn, isVainsOn, isNervesOn, isBonesOn, isLyphaticOn, isOrgansOn;

    public GameObject label;

    public GameObject currentSelectObject, currentIsolatedObject;
    public int currentSelectedAssetNo;

    public GameObject closeButton, closetoWelcomeBtn, closeButtonNew;

    public bool isIsolatedOn;

    public bool isBoneIsolated;

    public GameObject selectedBone;
    public bool isBoneGrab, isBoneGrabbed;

    public float speed = 0.3f;

    public GameObject skinBtn, ligamentBtn, veinsBtn, nervesBtn, musclesBtn, bonesBtn, arteriesBtn, lymphBtn;
    public GameObject skinBtnPressed, ligamentBtnPressed, veinsBtnPressed, nervesBtnPressed, musclesBtnPressed, bonesBtnPressed, arteriesBtnPressed, lymphBtnPressed;

    public GameObject isolateMuscleBtn, isolateBoneBtn, isolateArteriesBtn, isolateNervesBtn;

    public GameObject[] HeadNeckRightSideArray; // Array for the right side objects
    public GameObject[] HeadNeckLeftSideArray;  // Array for the left side objects
    public GameObject RightSideButton; // Button for the right side
    public GameObject LeftSideButton;  // Button for the left side

    private bool isRightSideActive = true; // Flag to track the active state


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

    public void ToggleHeadNeck()
    {
        // Toggle the active state of the right and left side arrays
        ToggleGameObjectArray(HeadNeckRightSideArray, isRightSideActive);
        ToggleGameObjectArray(HeadNeckLeftSideArray, !isRightSideActive);

        // Toggle the active state of the right and left side buttons
        RightSideButton.SetActive(isRightSideActive);
        LeftSideButton.SetActive(!isRightSideActive);

        // Update the active state flag
        isRightSideActive = !isRightSideActive;
    }

    // Function to toggle the active state of a GameObject array
    private void ToggleGameObjectArray(GameObject[] array, bool setActive)
    {
        foreach (GameObject obj in array)
        {
            obj.SetActive(setActive);
        }
    }

    // Use this for initialization
    public void Start()
    {
        MenuButton.SetActive(false);
        MenuButtonPressed.SetActive(true);

        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(true);
        SkyboxUIPanel.SetActive(false);
        FeaturesUIPanel.SetActive(true);

        LayerButton.SetActive(false);
        SkyboxButton.SetActive(true);
        LayerButtonPressed.SetActive(true);
        SkyboxButtonPressed.SetActive(false);

        GizmoButton.SetActive(true);
        IsolateButton.SetActive(false);
        HideButton.SetActive(false);
        UndoButton.SetActive(false);

        GizmoButtonPressed.SetActive(false);
        IsolateButtonPressed.SetActive(false);

        //completelowerBody.GetComponent<BoundsControl>().HandlesActive = false;

        //XButtonHighLight.SetActive(false);
        //YButtonHighLight.SetActive(false);
        //AButtonHighLight.SetActive(false);
        //BButtonHighLight.SetActive(false);
        //MenuButtonHighLight.SetActive(true);
    }

    public void OnMenuButtonClick()
    {
        MenuParentObject.SetActive(true);
        MenuButton.SetActive(false);
        MenuButtonPressed.SetActive(true);
        FeaturesUIPanel.SetActive(true);
    }
    public void OnMenuButtonPressedClick()
    {
        MenuParentObject.SetActive(false);
        MenuButton.SetActive(true);
        MenuButtonPressed.SetActive(false);
        FeaturesUIPanel.SetActive(false);
    }
    public void InstructionBtnClick()
    {

    }

    public void backFromInstruBtnClick()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.N))
        {
            isolatedMusclesManager.Instance.hideButtonClick();
        }

        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.M))
        {
            isolatedMusclesManager.Instance.undoButtonClick();
        }

        if (OVRInput.GetDown(OVRInput.Button.Three) || Input.GetKeyDown(KeyCode.K))
        {
            isolateButtonClick();
        }
    }

    public void OnLayersButtonClick()
    {
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(true);
        SkyboxUIPanel.SetActive(false);

        LayerButton.SetActive(true);
        SkyboxButton.SetActive(true);
        LayerButtonPressed.SetActive(true);
        SkyboxButtonPressed.SetActive(false);

        //XButtonHighLight.SetActive(false);
        //YButtonHighLight.SetActive(false);
        //AButtonHighLight.SetActive(false);
        //BButtonHighLight.SetActive(false);
        //MenuButtonHighLight.SetActive(false);
    }
    public void OnLayersPressedButtonClick()
    {
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(false);

        LayerButton.SetActive(true);
        SkyboxButton.SetActive(true);
        LayerButtonPressed.SetActive(false);
        SkyboxButtonPressed.SetActive(false);

        //XButtonHighLight.SetActive(false);
        //YButtonHighLight.SetActive(false);
        //AButtonHighLight.SetActive(false);
        //BButtonHighLight.SetActive(false);
        //MenuButtonHighLight.SetActive(false);
    }
    public void OnSkyboxButtonClick()
    {
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(true);

        LayerButton.SetActive(true);
        SkyboxButton.SetActive(false);
        LayerButtonPressed.SetActive(false);
        SkyboxButtonPressed.SetActive(true);

        //XButtonHighLight.SetActive(false);
        //YButtonHighLight.SetActive(false);
        //AButtonHighLight.SetActive(false);
        //BButtonHighLight.SetActive(false);
        //MenuButtonHighLight.SetActive(false);
    }
    public void OnSkyboxPressedButtonClick()
    {
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(false);

        LayerButton.SetActive(true);
        SkyboxButton.SetActive(true);
        LayerButtonPressed.SetActive(false);
        SkyboxButtonPressed.SetActive(false);

        //XButtonHighLight.SetActive(false);
        //YButtonHighLight.SetActive(false);
        //AButtonHighLight.SetActive(false);
        //BButtonHighLight.SetActive(false);
        //MenuButtonHighLight.SetActive(false);
    }

    private void Reset()
    {
        //gameobjects that need to disableld on start
        completeUpperBody.SetActive(false);
        completelowerBody.SetActive(false);
        completeThorax.SetActive(false);
        completeAbdomen.SetActive(false);
        completeHeadNeck.SetActive(false);
        ;
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

    public void CloseButtonNewClick()
    {
        //ChangeSceneGameManager.Instance.loginscreen = false;
        //ChangeSceneGameManager.Instance.grossanatomyscreen = true;
        SceneManager.LoadScene("DEFTXR_MainHUB");
    }

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

                AssetManagementScript.Instance.resetData();

                completeUpperBody.SetActive(true);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<Interactable>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<Interactable>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

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

                label.SetActive(false);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<BoxCollider>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

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
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                //LayerButton.GetComponent<Interactable>().enabled = true;
                SkyboxButton.SetActive(true);
                //SkyboxButton.GetComponent<Interactable>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

                /*XButtonHighLight.SetActive(false);
                YButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                BButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);*/

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
                label.SetActive(false);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<BoxCollider>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

                /*XButtonHighLight.SetActive(false);
                YButtonHighLight.SetActive(false);
                AButtonHighLight.SetActive(false);
                BButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);*/

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

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<Interactable>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<Interactable>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

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
                label.SetActive(false);

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<BoxCollider>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

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

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<Interactable>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<Interactable>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

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

                label.SetActive(false);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<BoxCollider>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

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

                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<Interactable>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<Interactable>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

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
                label.SetActive(false);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<BoxCollider>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

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

                completeSkeletalSystem.SetActive(true);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<Interactable>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<Interactable>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

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
                //label.SetActive(false);

                completeSkeletalSystem.SetActive(true);
                isIsolatedOn = false;
                closeButton.SetActive(false);
                closeButtonNew.SetActive(true);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(true);
                SkyboxUIPanel.SetActive(false);

                FeaturesUIPanel.SetActive(true);
                GizmoButton.SetActive(true);
                IsolateButton.SetActive(true);
                IsolateButtonPressed.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(false);
                LayerButton.GetComponent<BoxCollider>().enabled = true;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = true;
                LayerButtonPressed.SetActive(true);
                SkyboxButtonPressed.SetActive(false);

                englishName.text = "";
                latinName.text = "";
                content.text = "";
            }
        }
    }


    public void isolateButtonClick()
    {
        //touchInteraction.GetComponent<BoxCollider>().enabled = true;

        IsolateButton.SetActive(false);

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

                //Debug.Log(currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount);

                currentIsolatedObject.transform.GetChild(0).gameObject.SetActive(true);
                for (int i = 0; i < currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount; i++)
                {
                    GameObject chParent = currentIsolatedObject.transform.GetChild(0).transform.GetChild(i).gameObject;
                    chParent.SetActive(true);

                    //Debug.Log(chParent.transform.childCount);

                    for (int j = 0; j < chParent.transform.childCount; j++)
                    {
                        chParent.transform.GetChild(j).gameObject.SetActive(true);
                    }
                }

                AssetManagementScript.Instance.setIsolatedMuscleData();

                completeUpperBody.SetActive(false);
                label.SetActive(true);
                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);
                FeaturesUIPanel.SetActive(true);

                GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(true);
                LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

                isIsolatedOn = true;
            }

            if (state == State.bones)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;
                completeUpperBody.SetActive(false);

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);

                GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(false);
                UndoButton.SetActive(false);

                FeaturesUIPanel.SetActive(false);

                LayerButton.SetActive(true);
                LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

                isIsolatedOn = true;
            }
        }

        if (region == Region.lowerLimb)
        {

            if (state == State.muscle)
            {
                //PreviousCurrentObjects.Instance.clearObjData();
                currentIsolatedObject = AssetManagementScript.Instance.isolatedLowerLimbMuscleAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedMuscleData();

                //Debug.Log(currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount);

                currentIsolatedObject.transform.GetChild(0).gameObject.SetActive(true);
                for (int i = 0; i < currentIsolatedObject.transform.GetChild(0).gameObject.transform.childCount; i++)
                {
                    GameObject chParent = currentIsolatedObject.transform.GetChild(0).transform.GetChild(i).gameObject;
                    chParent.SetActive(true);

                    //Debug.Log(chParent.transform.childCount);

                    for (int j = 0; j < chParent.transform.childCount; j++)
                    {
                        chParent.transform.GetChild(j).gameObject.SetActive(true);
                    }
                }

                completelowerBody.SetActive(false);
                label.SetActive(true);

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);
                FeaturesUIPanel.SetActive(true);

                GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(true);
                //LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                //SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

                /*XButtonHighLight.SetActive(false);
                YButtonHighLight.SetActive(true);
                AButtonHighLight.SetActive(false);
                BButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);*/

                isIsolatedOn = true;
            }

            if (state == State.bones)
            {
                //PreviousCurrentObjects.Instance.clearObjData();
                currentIsolatedObject = AssetManagementScript.Instance.isolatedLowerLimbBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;
                completelowerBody.SetActive(false);

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);

                GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(false);
                UndoButton.SetActive(false);

                FeaturesUIPanel.SetActive(false);

                LayerButton.SetActive(true);
                LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

                /*XButtonHighLight.SetActive(false);
                YButtonHighLight.SetActive(true);
                AButtonHighLight.SetActive(false);
                BButtonHighLight.SetActive(false);
                MenuButtonHighLight.SetActive(false);*/

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
                label.SetActive(true);

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);
                FeaturesUIPanel.SetActive(true);

                GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(true);
                LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

                isIsolatedOn = true;
            }

            if (state == State.bones)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedThoraxBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;
                completeThorax.SetActive(false);

                closeButton.SetActive(true); ;
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);

                GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(false);
                UndoButton.SetActive(false);

                FeaturesUIPanel.SetActive(false);

                LayerButton.SetActive(true);
                LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

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
                label.SetActive(true);

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);
                FeaturesUIPanel.SetActive(true);

                GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(true);
                LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

                isIsolatedOn = true;
            }

            if (state == State.bones)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedAbdomenBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;

                completeAbdomen.SetActive(false);

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);

                GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(false);
                UndoButton.SetActive(false);

                FeaturesUIPanel.SetActive(false);

                LayerButton.SetActive(true);
                LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

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
                label.SetActive(true);

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);
                FeaturesUIPanel.SetActive(true);

                GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                LayerButton.SetActive(true);
                LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

                isIsolatedOn = true;
            }

            if (state == State.bones)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedHeadNeckBonesAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                AssetManagementScript.Instance.setIsolatedBonesData();
                selectedBone = currentIsolatedObject;

                completeHeadNeck.SetActive(false);

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);

                GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(false);
                UndoButton.SetActive(false);

                FeaturesUIPanel.SetActive(false);

                LayerButton.SetActive(true);
                LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

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

                completeSkeletalSystem.SetActive(false);

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);

                //GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(false);
                UndoButton.SetActive(false);

                FeaturesUIPanel.SetActive(false);

                //LayerButton.SetActive(true);
                //LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                //LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(true);

                isIsolatedOn = true;
            }
        }

        if (region == Region.muscularSystem)
        {
            Debug.Log("Isolatedddddddddddddddddddddddddddddddddddddddddd");
            if (state == State.muscle)
            {
                currentIsolatedObject = AssetManagementScript.Instance.isolatedMuscularSystemMuscleAssets[DEFTXR_UI_Manager.Instance.currentSelectedAssetNo];
                currentIsolatedObject.SetActive(true);
                //DEFTXR_UI_Manager.Instance.target = currentIsolatedObject.transform.GetChild(0).gameObject;

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

                //label.SetActive(true);
                completeSkeletalSystem.SetActive(false);

                closeButton.SetActive(true);
                closeButtonNew.SetActive(false);
                closetoWelcomeBtn.SetActive(false);

                //UI Changes
                MainUIPanel.SetActive(true);
                HandMenuBar.SetActive(true);
                LayersUIPanel.SetActive(false);
                SkyboxUIPanel.SetActive(false);
                FeaturesUIPanel.SetActive(true);

                //GizmoButton.SetActive(true);
                IsolateButton.SetActive(false);
                HideButton.SetActive(true);
                UndoButton.SetActive(true);

                //LayerButton.SetActive(true);
                //LayerButton.GetComponent<BoxCollider>().enabled = false;
                SkyboxButton.SetActive(true);
                SkyboxButton.GetComponent<BoxCollider>().enabled = false;
                //LayerButtonPressed.SetActive(false);
                SkyboxButtonPressed.SetActive(false);
                IsolateButtonPressed.SetActive(false);

                isIsolatedOn = true;
            }
        }
    }

    public void OnGizmoButtonClick()
    {
        /*GizmoButton.SetActive(false);
        GizmoButtonPressed.SetActive(true);

        if (region == Region.lowerLimb && isIsolatedOn == false)
        {
            completelowerBody.GetComponent<BoundsControl>().HandlesActive = true;
            completelowerBody.GetComponent<BoundsControl>().enabled = true;
            completelowerBody.GetComponent<ObjectManipulator>().enabled = true;
            //completelowerBody.GetComponent<BoxCollider>().enabled = true;
        }*/
        /*if (isIsolatedOn == true)
        {
            AttachMRTK.Instance.attachMRTKToIsolate(AssetManagementScript.Instance.isolated_object);
        }*/
    }
    public void OnGizmoPressedButtonClick()
    {
        /*GizmoButton.SetActive(true);
        GizmoButtonPressed.SetActive(false);

        if (region == Region.lowerLimb && isIsolatedOn == false)
        {
            //AttachMRTK.Instance.detachMRTKFromIsolate(completelowerBody);
            completelowerBody.GetComponent<BoundsControl>().HandlesActive = false;
            completelowerBody.GetComponent<BoundsControl>().enabled = false;
            completelowerBody.GetComponent<ObjectManipulator>().enabled = false;
            //completelowerBody.GetComponent<BoxCollider>().enabled = false;
        }*/
       /* if (isIsolatedOn == true)
        {
            AttachMRTK.Instance.detachMRTKFromIsolate(AssetManagementScript.Instance.isolated_object);
            currentIsolatedObject.GetComponent<BoxCollider>().enabled = false;
        }*/
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

        //UI Changes
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(false);

        LayerButton.SetActive(true);
        SkyboxButton.SetActive(true);
        LayerButtonPressed.SetActive(false);
        SkyboxButtonPressed.SetActive(false);

        FeaturesUIPanel.SetActive(true);
        GizmoButton.SetActive(true);
        IsolateButton.SetActive(false);
        HideButton.SetActive(false);
        UndoButton.SetActive(false);

        /*XButtonHighLight.SetActive(false);
        YButtonHighLight.SetActive(false);
        AButtonHighLight.SetActive(false);
        BButtonHighLight.SetActive(false);
        MenuButtonHighLight.SetActive(true);*/

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

        region = Region.lowerLimb;
        setContent();

        // Initially enable the right side and disable the left side
        ToggleGameObjectArray(HeadNeckRightSideArray, true);
        ToggleGameObjectArray(HeadNeckLeftSideArray, false);

        // Initially enable the right side button and disable the left side button
        RightSideButton.SetActive(true);
        LeftSideButton.SetActive(false);

        MenuButton.SetActive(false);
        MenuButtonPressed.SetActive(true);

        //UI Changes
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(true);
        SkyboxUIPanel.SetActive(false);

        LayerButton.SetActive(false);
        SkyboxButton.SetActive(true);
        LayerButtonPressed.SetActive(true);
        SkyboxButtonPressed.SetActive(false);

        FeaturesUIPanel.SetActive(true);
        GizmoButton.SetActive(true);
        IsolateButton.SetActive(false);
        HideButton.SetActive(false);
        UndoButton.SetActive(false);

        /*XButtonHighLight.SetActive(false);
        YButtonHighLight.SetActive(false);
        AButtonHighLight.SetActive(false);
        BButtonHighLight.SetActive(false);
        MenuButtonHighLight.SetActive(true);*/

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

        region = Region.thorax;
        setContent();

        //UI Changes
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(false);

        LayerButton.SetActive(true);
        SkyboxButton.SetActive(true);
        LayerButtonPressed.SetActive(false);
        SkyboxButtonPressed.SetActive(false);

        FeaturesUIPanel.SetActive(true);
        GizmoButton.SetActive(true);
        IsolateButton.SetActive(false);
        HideButton.SetActive(false);
        UndoButton.SetActive(false);

        /*XButtonHighLight.SetActive(false);
        YButtonHighLight.SetActive(false);
        AButtonHighLight.SetActive(false);
        BButtonHighLight.SetActive(false);
        MenuButtonHighLight.SetActive(true);*/

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

        region = Region.abdomen;
        setContent();

        //UI Changes
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(false);

        LayerButton.SetActive(true);
        SkyboxButton.SetActive(true);
        LayerButtonPressed.SetActive(false);
        SkyboxButtonPressed.SetActive(false);

        FeaturesUIPanel.SetActive(true);
        GizmoButton.SetActive(true);
        IsolateButton.SetActive(false);
        HideButton.SetActive(false);
        UndoButton.SetActive(false);

        /*XButtonHighLight.SetActive(false);
        YButtonHighLight.SetActive(false);
        AButtonHighLight.SetActive(false);
        BButtonHighLight.SetActive(false);
        MenuButtonHighLight.SetActive(true);*/

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

        region = Region.headNeck;
        setContent();

        //UI Changes
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(false);

        LayerButton.SetActive(true);
        SkyboxButton.SetActive(true);
        LayerButtonPressed.SetActive(false);
        SkyboxButtonPressed.SetActive(false);

        FeaturesUIPanel.SetActive(true);
        GizmoButton.SetActive(true);
        IsolateButton.SetActive(false);
        HideButton.SetActive(false);
        UndoButton.SetActive(false);

        /*XButtonHighLight.SetActive(false);
        YButtonHighLight.SetActive(false);
        AButtonHighLight.SetActive(false);
        BButtonHighLight.SetActive(false);
        MenuButtonHighLight.SetActive(true);*/

        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);

        isSkinOn = false;
        onSkinButtonClick();
    }
    public void skeletonButtonClick()
    {
        region = Region.skeletonSystem;

        //UI Changes
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(false);

        //LayerButton.SetActive(true);
        SkyboxButton.SetActive(true);
        //LayerButtonPressed.SetActive(false);
        SkyboxButtonPressed.SetActive(false);

        FeaturesUIPanel.SetActive(true);
        //GizmoButton.SetActive(true);
        IsolateButton.SetActive(false);
        HideButton.SetActive(false);
        UndoButton.SetActive(false);

        /*XButtonHighLight.SetActive(false);
        YButtonHighLight.SetActive(false);
        AButtonHighLight.SetActive(false);
        BButtonHighLight.SetActive(false);
        MenuButtonHighLight.SetActive(true);*/

        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);

        //isSkinOn = false;
        //onSkinButtonClick();
    }

    public void muscularButtonClick()
    {
        region = Region.muscularSystem;

        //UI Changes
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(false);

        //LayerButton.SetActive(true);
        SkyboxButton.SetActive(true);
        //LayerButtonPressed.SetActive(false);
        SkyboxButtonPressed.SetActive(false);

        FeaturesUIPanel.SetActive(true);
        //GizmoButton.SetActive(true);
        IsolateButton.SetActive(false);
        HideButton.SetActive(false);
        UndoButton.SetActive(false);

        /*XButtonHighLight.SetActive(false);
        YButtonHighLight.SetActive(false);
        AButtonHighLight.SetActive(false);
        BButtonHighLight.SetActive(false);
        MenuButtonHighLight.SetActive(true);*/

        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);

        //isSkinOn = false;
        //onSkinButtonClick();
    }

    public void FullBodyDissectionButtonClick()
    {
        //UI Changes
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(false);

        SkyboxButton.SetActive(true);
        SkyboxButtonPressed.SetActive(false);

        FeaturesUIPanel.SetActive(true);
        HideButton.SetActive(true);
        UndoButton.SetActive(false);

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
        isDisection = false;

        //UI Changes
        MainUIPanel.SetActive(true);
        HandMenuBar.SetActive(true);
        LayersUIPanel.SetActive(false);
        SkyboxUIPanel.SetActive(false);

        //LayerButton.SetActive(true);
        SkyboxButton.SetActive(true);
        //LayerButtonPressed.SetActive(true);
        SkyboxButtonPressed.SetActive(false);

        closeButtonNew.SetActive(true);
        closetoWelcomeBtn.SetActive(false);
        closeButton.SetActive(false);
    }

    public void onSkinButtonClick()
    {
        /*if (region == Region.lowerLimb)
        {
            completelowerBody.GetComponent<BoxCollider>().enabled = false;
        }*/
        //PreviousCurrentObjects.Instance.clearObjData();
        if (isSkinOn == false)
        {
            current_BodySkin.SetActive(true);
            //skinBtn.GetComponent<UIBlock2D>().Border.Enabled = true;
            skinBtnPressed.SetActive(true);

            current_BodyMuscles.SetActive(true);
            musclesBtnPressed.SetActive(true);

            current_BodyLigaments.SetActive(true);
            ligamentBtnPressed.SetActive(true);

            current_BodyArteries.SetActive(true);
            arteriesBtnPressed.SetActive(true);

            current_Bodybones.SetActive(true);
            bonesBtnPressed.SetActive(true);

            current_BodyNerves.SetActive(true);
            nervesBtnPressed.SetActive(true);

            current_BodyVains.SetActive(true);
            veinsBtnPressed.SetActive(true);

            current_BodylyphaticSystem.SetActive(true);
            lymphBtnPressed.SetActive(true);

            if (current_BodyOrgans != null)
            {
                current_BodyOrgans.SetActive(false);
                //organsBtn.SetActive(false);
                //organsBtnPressed.SetActive(true);
            }

            isSkinOn = true;
        }
        else
        {
            /*if (region == Region.lowerLimb)
            {
                completelowerBody.GetComponent<BoxCollider>().enabled = false;
            }*/
            current_BodySkin.SetActive(false);
            skinBtnPressed.SetActive(false);

            /*current_BodyMuscles.SetActive(true);

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
*/
            isSkinOn = false;
        }
    }

    public void onMusclesButtonClick()
    {
        //PreviousCurrentObjects.Instance.clearObjData();
        if (isMusclesOn == true)
        {
            current_BodyMuscles.SetActive(true);
            musclesBtn.SetActive(true);
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
        //PreviousCurrentObjects.Instance.clearObjData();
        if (isLigamentsOn == true)
        {
            current_BodyLigaments.SetActive(true);
            ligamentBtn.SetActive(true);
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
        //PreviousCurrentObjects.Instance.clearObjData();
        if (isArteriesOn == true)
        {
            current_BodyArteries.SetActive(true);
            arteriesBtn.SetActive(true);
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
        //PreviousCurrentObjects.Instance.clearObjData();
        if (isVainsOn == true)
        {
            current_BodyVains.SetActive(true);
            veinsBtn.SetActive(true);
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
        //PreviousCurrentObjects.Instance.clearObjData();
        if (isNervesOn == true)
        {
            current_BodyNerves.SetActive(true);
            nervesBtn.SetActive(true);
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
        //PreviousCurrentObjects.Instance.clearObjData();
        if (isBonesOn == true)
        {
            current_Bodybones.SetActive(true);
            bonesBtn.SetActive(true);
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
        //PreviousCurrentObjects.Instance.clearObjData();
        if (isLyphaticOn == true)
        {
            current_BodylyphaticSystem.SetActive(true);
            lymphBtn.SetActive(true);
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
        //PreviousCurrentObjects.Instance.clearObjData();
        if (isOrgansOn == true)
        {
            current_BodyOrgans.SetActive(true);
            //organsBtn.SetActive(false);
            //organsBtnPressed.SetActive(true);
            isOrgansOn = false;
        }
        else
        {
            current_BodyOrgans.SetActive(false);
            //organsBtn.SetActive(true);
            //organsBtnPressed.SetActive(false);
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
