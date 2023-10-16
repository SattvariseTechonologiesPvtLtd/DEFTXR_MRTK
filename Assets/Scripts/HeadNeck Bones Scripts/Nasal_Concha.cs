using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nasal_Concha : MonoBehaviour
{
    // public GameObject ZoneA, ZoneB, ZoneC;
    //public GameObject zoneBObj;

    public GameObject DefaultObj, featuresObj;

    public GameObject featuresDown, featuresUp;

    // public GameObject featureSelectBtn, insertionSelectBtn, originSelectBtn, ligamentSelectBtn;

    public bool attch, featureAttach = false;

    public Sprite enable, disable;

    public GameObject[] featuresList;

    public bool isAllFeaturesSelected;

    public GameObject feature_dropdown;
    public GameObject featureSelectAllButtonTick;
    public GameObject subButtonsParent;

    public GameObject featureBtn;

    public GameObject featureSelectText;
    public GameObject featureDeselectText;


    // Use this for initialization
    void Start()
    {

        isAllFeaturesSelected = false;
        feature_dropdown.SetActive(false);

        //featureBtn.GetComponent<Image>().sprite = disable;
        //insertionBtn.GetComponent<Image>().sprite = disable;
        //originBtn.GetComponent<Image>().sprite = disable;
        //ligamentsBtn.GetComponent<Image>().sprite = disable;

    }

    // Update is called once per frame
    void Update()
    {

    }

    /* public void onFeaturesSubButtonClick()
     {
        featureSelectAllButtonTick.SetActive(true);
        isAllFeaturesSelected = true;

         foreach (int i in MultiSelectDropdown_Manager.Instance.selectedButtonIdList)
         {
             for (int j = 0;  j < featuresList.Length; j++)
             {
                 if (j == i)
                 {
                      featuresList[j].SetActive(true);
                 }
                 else
                 {
                     featuresList[j].SetActive(false);
                 }
             }
         }
     }

     public void onInsertionSubButtonClick()
     {
         insertionSelectAllButtonTick.SetActive(false);
         isAllInsertionSelected = false;

         foreach (int i in MultiSelectDropdown_Manager.Instance.selectedButtonIdList)
         {
             for (int j = 0; j < insertionList.Length; j++)
             {
                 if (j == i)
                 {
                     insertionList[j].SetActive(true);
                 }
                 else
                 {
                     insertionList[j].SetActive(false);
                 }
             }
         }
     }

     public void onOriginSubButtonClick()
     {
         originSelectAllButtonTick.SetActive(false);
         isAllOriginSelected = false;

         foreach (int i in MultiSelectDropdown_Manager.Instance.selectedButtonIdList)
         {
             for (int j = 0; j < originList.Length; j++)
             {
                 if (j == i)
                 {
                     originList[j].SetActive(true);
                 }
                 else
                 {
                     originList[j].SetActive(false);
                 }
             }
         }
     }

     public void onLigamentSubButtonClick()
     {
         ligamentSelectAllButtonTick.SetActive(false);
         isAllLigamentSelected = false;

         foreach (int i in MultiSelectDropdown_Manager.Instance.selectedButtonIdList)
         {
             for (int j = 0; j < ligamentList.Length; j++)
             {
                 if (j == i)
                 {
                     ligamentList[j].SetActive(true);
                 }
                 else
                 {
                     ligamentList[j].SetActive(false);
                 }
             }
         }
     }*/

    public void selectAllFeatures()
    {
        if (isAllFeaturesSelected == false)
        {
            featureSelectAllButtonTick.SetActive(true);

            for (int j = 0; j < featuresList.Length; j++)
            {
                featuresList[j].SetActive(true);
            }
            foreach (Transform t in subButtonsParent.transform)
            {
                // t.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
                t.Find("TickParent").transform.GetChild(0).gameObject.SetActive(true);

            }
            isAllFeaturesSelected = true;
            featureDeselectText.SetActive(true);
            featureSelectText.SetActive(false);
        }
        else
        {
            featureSelectAllButtonTick.SetActive(false);

            for (int j = 0; j < featuresList.Length; j++)
            {
                featuresList[j].SetActive(false);
            }

            foreach (Transform s in subButtonsParent.transform)
            {
                // s.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                s.Find("TickParent").transform.GetChild(0).gameObject.SetActive(false);

            }

            isAllFeaturesSelected = false;
            featureDeselectText.SetActive(false);
            featureSelectText.SetActive(true);
        }
    }

    private void featureButtonClickReset()
    {

    }

    public void onFeaturesButtonClick()
    {


        if (featureAttach == false)
        {
            featureButtonClickReset();
            DefaultObj.SetActive(false);
            featuresObj.SetActive(true);
            feature_dropdown.SetActive(true);

            featuresDown.SetActive(false);
            featuresUp.SetActive(true);

            //   featureBtn.GetComponent<Image>().sprite = enable;
            featureAttach = true;
        }
        else
        {

            DefaultObj.SetActive(true);
            featuresObj.SetActive(false);
            feature_dropdown.SetActive(false);

            featuresDown.SetActive(true);
            featuresUp.SetActive(false);

            //   featureBtn.GetComponent<Image>().sprite = disable;
            featureAttach = false;
        }
    }
}
