using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MyCollisionBehaviourMRTK : MonoBehaviour, IMixedRealityPointerHandler
{
    //public static MyCollisionBehaviourMRTK Instance; 

    /*private GameObject activeObject; // Reference to the active object

    [SerializeField]
    private GameObject childObject; // Reference to the child object

    [SerializeField]
    public GameObject MainObject; // Reference to the Main object

    [SerializeField]
    private TextMeshPro informationText; // Reference to the information text

    [SerializeField]
    private string enteredText = string.Empty;

    [SerializeField]
    private GameObject highlightObject1; // Reference to the first highlight object

    [SerializeField]
    private GameObject highlightObject2, yButtonHighlight; // Reference to the second highlight object

    private Renderer parentRenderer; // Reference to the renderer component of the parent object

    private Renderer childRenderer; // Reference to the renderer component of the child object

    private bool isObjectHidden; // Flag to indicate if the object is currently hidden*/

    private GameObject currentGameObject;
    private GameObject previouslyHiddenObject;

    Material myOriginalMat, selctionMaterial;
    [SerializeField] GameObject myLable;
    public GameObject publicLable;
    string myEnglishName, myLatinName;
    [SerializeField] AudioClip myEnglishVO;

    [SerializeField] bool isArtries, isBones, isMuscle, isVains, isLymphs, isNervs, isligaments;

    [SerializeField] int myAssetNo;

    [SerializeField] string myContent;

    private void Start()
    {
        /*// Disable the child object and information text at the start
        childObject.SetActive(false);
        informationText.gameObject.SetActive(false);

        // Get the renderer components of the parent and child objects
        parentRenderer = GetComponent<Renderer>();
        childRenderer = childObject.GetComponent<Renderer>();

        // Disable the highlight objects at the start
        highlightObject1.SetActive(false);
        highlightObject2.SetActive(false);

        isObjectHidden = false;
        yButtonHighlight.SetActive(false);*/

        if (myLable != null)
        {
            publicLable = myLable;
            myLable.SetActive(true);
            myEnglishName = myLable.transform.Find("LabelCanvas").transform.Find("Lable").transform.Find("EnglishName").gameObject.GetComponent<TMP_Text>().text;
            myLatinName = myLable.transform.Find("LabelCanvas").transform.Find("Lable").transform.Find("LatinName").gameObject.GetComponent<TMP_Text>().text;

        }
        //myOriginalMat = currentGameObject.gameObject.GetComponent<Renderer>().material;
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        // Check if the pointer event hit an object
        if (eventData.Pointer.Result?.CurrentPointerTarget != null)
        {
            // Get the GameObject that was hit
            currentGameObject = eventData.Pointer.Result.CurrentPointerTarget.gameObject;

            // You can now perform any operations on the currentGameObject
            // For example, change its color, scale, or call a specific function on it
            Debug.Log("Selected Object: " + currentGameObject.name);

            if (String.Compare(IntractionManager.Instance.selectObjName, "") == 0)
            {
                IntractionManager.Instance.selectObjName = currentGameObject.gameObject.name;
                DEFTXR_UI_Manager.Instance.currentIsolatedObject = currentGameObject.gameObject;
                DEFTXR_UI_Manager.Instance.currentSelectObject = currentGameObject.gameObject;

                //DEFTXR_UI_Manager.Instance.lock_unlockParent.SetActive(true);
                //DEFTXR_UI_Manager.Instance.lockImg.SetActive(false);
               // DEFTXR_UI_Manager.Instance.unlockImg.SetActive(true);

                if (myAssetNo > -1)
                {
                    DEFTXR_UI_Manager.Instance.currentSelectedAssetNo = myAssetNo;
                }

                changeSelectionMaterialProperties(currentGameObject.gameObject.GetComponent<Renderer>().material);

                if (myLable != null)
                {
                    myLable.SetActive(true);
                    if (myEnglishName != null && myLatinName != null)
                    {
                        DEFTXR_UI_Manager.Instance.englishName.text = myEnglishName;
                        DEFTXR_UI_Manager.Instance.latinName.text = myLatinName;

                        DEFTXR_UI_Manager.Instance.VOButton.SetActive(true);

                        DEFTXR_UI_Manager.Instance.content.text = myContent;
                        DEFTXR_UI_Manager.Instance.seletcedEnglishVO = myEnglishVO;

                        if (isBones || isMuscle)
                        {
                            if (myAssetNo > -1 && DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
                            {
                                if (DEFTXR_UI_Manager.Instance.isDisection == false)
                                {
                                    //DEFTXR_UI_Manager.Instance.isolationPanel.SetActive(true);
                                    //DEFTXR_UI_Manager.Instance.isolateButton.SetActive(true);
                                    //DEFTXR_UI_Manager.Instance.isolateButton.GetComponent<Button>().interactable = true;

                                    //DEFTXR_UI_Manager.Instance.hideButton.GetComponent<Button>().interactable = true;
                                    //DEFTXR_UI_Manager.Instance.undoButton.GetComponent<Button>().interactable = true;
                                }

                            }
                        }
                        else
                        {
                            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == true)
                            {

                            }
                            else
                            {
                                if (DEFTXR_UI_Manager.Instance.isDisection == false)
                                {
                                    //DEFTXR_UI_Manager.Instance.isolationPanel.SetActive(true);
                                    //DEFTXR_UI_Manager.Instance.isolateButton.GetComponent<Button>().interactable = false;

                                    //DEFTXR_UI_Manager.Instance.hideButton.GetComponent<Button>().interactable = false;
                                    //DEFTXR_UI_Manager.Instance.undoButton.GetComponent<Button>().interactable = false;
                                }
                            }
                        }


                        //  DEFTXR_UI_Manager.Instance.selectedLatinVO = myLatinVO;

                    }

                }
            }
            else
            {

                if (String.Compare(currentGameObject.gameObject.name, IntractionManager.Instance.selectObjName) == 0)
                {



                }
                else
                {
                    IntractionManager.Instance.selectObjName = currentGameObject.gameObject.name;
                    DEFTXR_UI_Manager.Instance.currentIsolatedObject = currentGameObject.gameObject;
                    DEFTXR_UI_Manager.Instance.currentSelectObject = currentGameObject.gameObject;
                    //DEFTXR_UI_Manager.Instance.lock_unlockParent.SetActive(true);
                    //DEFTXR_UI_Manager.Instance.lockImg.SetActive(false);
                    //DEFTXR_UI_Manager.Instance.unlockImg.SetActive(true);

                    if (myAssetNo > -1)
                    {
                        DEFTXR_UI_Manager.Instance.currentSelectedAssetNo = myAssetNo;
                    }

                    changeSelectionMaterialProperties(currentGameObject.gameObject.GetComponent<Renderer>().material);
                    if (myLable != null)
                    {
                        myLable.SetActive(true);

                        if (myEnglishName != null && myLatinName != null)
                        {
                            DEFTXR_UI_Manager.Instance.englishName.text = myEnglishName;
                            DEFTXR_UI_Manager.Instance.latinName.text = myLatinName;
                            DEFTXR_UI_Manager.Instance.content.text = myContent;

                            DEFTXR_UI_Manager.Instance.VOButton.SetActive(true);

                            DEFTXR_UI_Manager.Instance.seletcedEnglishVO = myEnglishVO;

                            if (isBones || isMuscle)
                            {
                                if (myAssetNo > -1 && DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
                                {
                                    if (DEFTXR_UI_Manager.Instance.isDisection == false)
                                    {
                                        //DEFTXR_UI_Manager.Instance.isolationPanel.SetActive(true);
                                        //DEFTXR_UI_Manager.Instance.isolateButton.SetActive(true);
                                        //DEFTXR_UI_Manager.Instance.isolateButton.GetComponent<Button>().interactable = true;
                                    }
                                }
                            }
                            else
                            {
                                if (DEFTXR_UI_Manager.Instance.isIsolatedOn == true)
                                {

                                }
                                else
                                {
                                    if (DEFTXR_UI_Manager.Instance.isDisection == false)
                                    {
                                        //DEFTXR_UI_Manager.Instance.isolationPanel.SetActive(true);
                                        //DEFTXR_UI_Manager.Instance.isolateButton.GetComponent<Button>().interactable = false;
                                    }
                                }
                            }

                            //DEFTXR_UI_Manager.Instance.selectedLatinVO = myLatinVO;

                        }
                    }

                }
            }
            Debug.Log("name : " + currentGameObject.gameObject.name);
        }
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        // Implement if needed
    }

   public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        // Implement if needed
        Debug.Log("disable Object: " + currentGameObject.name);
    }

    //public void SetEnteredText(string newText)
   // {
    //    enteredText = newText;
   // }

    // Example of an additional operation on the active object
    public void RotateActiveObject(Vector3 rotationAxis, float rotationSpeed)
    {
        // Implement if needed
    }

    // Example of another operation on the active object
    public void ScaleActiveObject(Vector3 scale)
    {
        // Implement if needed
    }

    /*private void Update()
    {
        // Check for the "B" button press to hide the object
        if (OVRInput.GetDown(OVRInput.RawButton.B) == true || Input.GetKeyDown(KeyCode.B) == true)
        {
            HideCurrentObject();
        }

        // Check for the "A" button press to undo the hide operation
        if (OVRInput.GetDown(OVRInput.RawButton.A) == true || Input.GetKeyDown(KeyCode.M) == true)
        {
            UndoHideObject();
        }
    }*/

    void changeSelectionMaterialProperties(Material mat)
    {
        selctionMaterial = mat;

        if (isBones)
        {
            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
            {
                DEFTXR_UI_Manager.Instance.state = DEFTXR_UI_Manager.State.bones;

            }

            Color myColor = new Color();
            ColorUtility.TryParseHtmlString("#00FFD7", out myColor);

            selctionMaterial.color = myColor;
            selctionMaterial.SetFloat("_Glossiness", 0f);
        }
        if (isMuscle)
        {
            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
            {
                DEFTXR_UI_Manager.Instance.state = DEFTXR_UI_Manager.State.muscle;
            }

            Color myColor = new Color();
            ColorUtility.TryParseHtmlString("#00FFD7", out myColor);

            selctionMaterial.color = myColor;
            selctionMaterial.SetFloat("_Glossiness", 0f);
        }
        if (isligaments)
        {

            Color myColor = new Color();
            ColorUtility.TryParseHtmlString("#00FFD7", out myColor);

            selctionMaterial.color = myColor;
            selctionMaterial.SetFloat("_Glossiness", 0f);
        }

        if (isArtries)
        {
            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
            {
                DEFTXR_UI_Manager.Instance.state = DEFTXR_UI_Manager.State.art;
            }

            currentGameObject.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance._hArt;
        }
        if (isVains)
        {
            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
            {
                DEFTXR_UI_Manager.Instance.state = DEFTXR_UI_Manager.State.vains;
            }

            currentGameObject.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance._hVains;

        }
        if (isLymphs)
        {
            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
            {
                DEFTXR_UI_Manager.Instance.state = DEFTXR_UI_Manager.State.lymph;
            }

            currentGameObject.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance._hLymph;

        }
        if (isNervs)
        {
            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
            {
                DEFTXR_UI_Manager.Instance.state = DEFTXR_UI_Manager.State.nerves;
            }

            currentGameObject.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance._hNervs;

        }
    }

    // Update is called once per frame
    void Update()
    {

        /*if (String.Equals(currentGameObject.gameObject.name, IntractionManager.Instance.selectObjName) == false)
        {
            //Debug.Log("called here" + currentGameObject.gameObject.GetComponent<Renderer>().material.name);
            if (isBones)
            {
                myOriginalMat = currentGameObject.gameObject.GetComponent<Renderer>().material;


                myOriginalMat.color = Color.white;
                myOriginalMat.SetFloat("_Glossiness", 1f);
            }
            if (isMuscle)
            {
                myOriginalMat = currentGameObject.gameObject.GetComponent<Renderer>().material;


                myOriginalMat.color = Color.white;
                myOriginalMat.SetFloat("_Glossiness", 1f);
            }
            if (isligaments)
            {
                myOriginalMat = currentGameObject.gameObject.GetComponent<Renderer>().material;


                myOriginalMat.color = Color.white;
                myOriginalMat.SetFloat("_Glossiness", 1f);
            }
            if (isArtries)
            {
                currentGameObject.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance.orgArt;
            }
            if (isVains)
            {
                currentGameObject.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance.orgVains;

            }
            if (isLymphs)
            {
                currentGameObject.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance.orgLymph;

            }
            if (isNervs)
            {
                currentGameObject.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance.orgNervs;

            }

            if (myLable != null)
            {
                myLable.SetActive(false);
            }
        }*/
    }
}
