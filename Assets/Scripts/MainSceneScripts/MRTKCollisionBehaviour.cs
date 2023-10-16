using UnityEngine;
using System.Collections;
using System;
using TMPro;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class MRTKCollisionBehaviour : MonoBehaviour, IMixedRealityPointerHandler
{
    //00FFD7
    public static MRTKCollisionBehaviour Instance;
    private bool uiActive = false;
    private bool YActive = false;// Track the UI state

    Material myOriginalMat, selctionMaterial;
    [SerializeField] GameObject myLable;
    public GameObject publicLable;
    string myEnglishName, myLatinName;
    [SerializeField] AudioClip myEnglishVO;

    [SerializeField] bool isArtries, isBones, isMuscle, isVains, isLymphs, isNervs, isligaments;

    [SerializeField] int myAssetNo;

    [SerializeField] string myContent;
    [SerializeField] TextMeshPro contentText;

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {

    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        if (String.Compare(IntractionManager.Instance.selectObjName, "") == 0)
        {

            IntractionManager.Instance.selectObjName = this.gameObject.name;
            DEFTXR_UI_Manager.Instance.currentIsolatedObject = this.gameObject;
            DEFTXR_UI_Manager.Instance.currentSelectObject = this.gameObject;

            //DEFTXR_UI_Manager.Instance.lock_unlockParent.SetActive(true);
            //DEFTXR_UI_Manager.Instance.lockImg.SetActive(false);
            //DEFTXR_UI_Manager.Instance.unlockImg.SetActive(true);


            if (myAssetNo > -1)
            {
                DEFTXR_UI_Manager.Instance.currentSelectedAssetNo = myAssetNo;
            }

            changeSelectionMaterialProperties(this.gameObject.GetComponent<Renderer>().material);

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

            if (String.Compare(this.gameObject.name, IntractionManager.Instance.selectObjName) == 0)
            {



            }
            else
            {
                IntractionManager.Instance.selectObjName = this.gameObject.name;
                DEFTXR_UI_Manager.Instance.currentIsolatedObject = this.gameObject;
                DEFTXR_UI_Manager.Instance.currentSelectObject = this.gameObject;
                //DEFTXR_UI_Manager.Instance.lock_unlockParent.SetActive(true);
                //DEFTXR_UI_Manager.Instance.lockImg.SetActive(false);
                //DEFTXR_UI_Manager.Instance.unlockImg.SetActive(true);

                if (myAssetNo > -1)
                {
                    DEFTXR_UI_Manager.Instance.currentSelectedAssetNo = myAssetNo;
                }

                changeSelectionMaterialProperties(this.gameObject.GetComponent<Renderer>().material);
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

    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {

    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {

    }

    /*private void OnTriggerEnter(Collider other)
    {

        if (String.Compare(other.gameObject.name, "TouchPos") == 0)
        {
            OnHoverFx();

            if (String.Compare(IntractionManager.Instance.selectObjName, "") == 0)
            {


                IntractionManager.Instance.selectObjName = this.gameObject.name;
                DEFTXR_UI_Manager.Instance.currentIsolatedObject = this.gameObject;
                DEFTXR_UI_Manager.Instance.currentSelectObject = this.gameObject;

                DEFTXR_UI_Manager.Instance.lock_unlockParent.SetActive(true);
                DEFTXR_UI_Manager.Instance.lockImg.SetActive(false);
                DEFTXR_UI_Manager.Instance.unlockImg.SetActive(true);


                if (myAssetNo > -1)
                {
                    DEFTXR_UI_Manager.Instance.currentSelectedAssetNo = myAssetNo;
                }


                changeSelectionMaterialProperties(this.gameObject.GetComponent<Renderer>().material);

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
                                    DEFTXR_UI_Manager.Instance.isolationPanel.SetActive(true);
                                    DEFTXR_UI_Manager.Instance.isolateButton.SetActive(true);
                                    DEFTXR_UI_Manager.Instance.isolateButton.GetComponent<Button>().interactable = true;

                                    DEFTXR_UI_Manager.Instance.hideButton.GetComponent<Button>().interactable = true;
                                    DEFTXR_UI_Manager.Instance.undoButton.GetComponent<Button>().interactable = true;
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
                                    DEFTXR_UI_Manager.Instance.isolationPanel.SetActive(true);
                                    DEFTXR_UI_Manager.Instance.isolateButton.GetComponent<Button>().interactable = false;

                                    DEFTXR_UI_Manager.Instance.hideButton.GetComponent<Button>().interactable = false;
                                    DEFTXR_UI_Manager.Instance.undoButton.GetComponent<Button>().interactable = false;
                                }
                            }
                        }

                        //  DEFTXR_UI_Manager.Instance.selectedLatinVO = myLatinVO;

                    }

                }
            }
            else
            {

                if (String.Compare(this.gameObject.name, IntractionManager.Instance.selectObjName) == 0)
                {



                }
                else
                {
                    IntractionManager.Instance.selectObjName = this.gameObject.name;
                    DEFTXR_UI_Manager.Instance.currentIsolatedObject = this.gameObject;
                    DEFTXR_UI_Manager.Instance.currentSelectObject = this.gameObject;
                    DEFTXR_UI_Manager.Instance.lock_unlockParent.SetActive(true);
                    DEFTXR_UI_Manager.Instance.lockImg.SetActive(false);
                    DEFTXR_UI_Manager.Instance.unlockImg.SetActive(true);

                    if (myAssetNo > -1)
                    {
                        DEFTXR_UI_Manager.Instance.currentSelectedAssetNo = myAssetNo;
                    }

                    changeSelectionMaterialProperties(this.gameObject.GetComponent<Renderer>().material);
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
                                        DEFTXR_UI_Manager.Instance.isolationPanel.SetActive(true);
                                        DEFTXR_UI_Manager.Instance.isolateButton.SetActive(true);
                                        DEFTXR_UI_Manager.Instance.isolateButton.GetComponent<Button>().interactable = true;
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
                                        DEFTXR_UI_Manager.Instance.isolationPanel.SetActive(true);
                                        DEFTXR_UI_Manager.Instance.isolateButton.GetComponent<Button>().interactable = false;
                                    }
                                }
                            }

                            //DEFTXR_UI_Manager.Instance.selectedLatinVO = myLatinVO;

                        }
                    }

                }
            }
            Debug.Log("name : " + this.gameObject.name);
        }
    }*/



    // Use this for initialization
    void Start()
    {
        if (myLable != null)
        {
            publicLable = myLable;
            myLable.SetActive(true);
            myEnglishName = myLable.transform.Find("LabelCanvas").transform.Find("Lable").transform.Find("EnglishName").gameObject.GetComponent<TMP_Text>().text;
            myLatinName = myLable.transform.Find("LabelCanvas").transform.Find("Lable").transform.Find("LatinName").gameObject.GetComponent<TMP_Text>().text;

        }
        myOriginalMat = this.gameObject.GetComponent<Renderer>().material;

    }


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

            this.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance._hArt;
        }
        if (isVains)
        {
            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
            {
                DEFTXR_UI_Manager.Instance.state = DEFTXR_UI_Manager.State.vains;
            }

            this.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance._hVains;

        }
        if (isLymphs)
        {
            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
            {
                DEFTXR_UI_Manager.Instance.state = DEFTXR_UI_Manager.State.lymph;
            }

            this.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance._hLymph;

        }
        if (isNervs)
        {
            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == false)
            {
                DEFTXR_UI_Manager.Instance.state = DEFTXR_UI_Manager.State.nerves;
            }

            this.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance._hNervs;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (String.Equals(this.gameObject.name, IntractionManager.Instance.selectObjName) == false)
        {
            //Debug.Log("called here" + this.gameObject.GetComponent<Renderer>().material.name);
            if (isBones)
            {
                myOriginalMat = this.gameObject.GetComponent<Renderer>().material;


                myOriginalMat.color = Color.white;
                myOriginalMat.SetFloat("_Glossiness", 1f);
            }
            if (isMuscle)
            {
                myOriginalMat = this.gameObject.GetComponent<Renderer>().material;


                myOriginalMat.color = Color.white;
                myOriginalMat.SetFloat("_Glossiness", 1f);
            }
            if (isligaments)
            {
                myOriginalMat = this.gameObject.GetComponent<Renderer>().material;


                myOriginalMat.color = Color.white;
                myOriginalMat.SetFloat("_Glossiness", 1f);
            }
            if (isArtries)
            {
                this.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance.orgArt;
            }
            if (isVains)
            {
                this.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance.orgVains;

            }
            if (isLymphs)
            {
                this.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance.orgLymph;

            }
            if (isNervs)
            {
                this.gameObject.GetComponent<Renderer>().material = DEFTXR_UI_Manager.Instance.orgNervs;

            }

            if (myLable != null)
            {
                myLable.SetActive(false);
            }
        }


    }

    public void OnHoverFx()
    {
        DEFTXR_UI_Manager.Instance.audioSource.pitch = 1f;
        DEFTXR_UI_Manager.Instance.audioSource.volume = 0.5f;
        DEFTXR_UI_Manager.Instance.audioSource.PlayOneShot(DEFTXR_UI_Manager.Instance.tickSound);
    }
}
