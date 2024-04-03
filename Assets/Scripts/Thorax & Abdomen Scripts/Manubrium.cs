﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine.UI;

public class Manubrium : MonoBehaviour
{
    // public GameObject ZoneA, ZoneB, ZoneC;
    public GameObject zoneBObj;

    public GameObject originObj, femurDefaultObj;

    public bool attch, origAttach = false;

    public GameObject[] originsList;

    public GameObject origin_dropdown;

    public GameObject originBtn;

    // Use this for initialization
    void Start()
    {
        origin_dropdown.SetActive(false);
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

    /* public void selectAllFeatures()
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
                 //t.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
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

     public void selectAllInsertions()
     {
         if (isAllInsertionsSelected == false)
         {
             insertionsSelectAllButtonTick.SetActive(true);

             for (int i = 0; i < insertionsList.Length; i++)
             {
                 insertionsList[i].SetActive(true);
             }
             foreach (Transform a in insertionsSubButtonsParent.transform)
             {
                 // a.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
                 a.Find("TickParent").transform.GetChild(0).gameObject.SetActive(true);
             }
             isAllInsertionsSelected = true;
             insertionDeselectText.SetActive(true);
             insertionSelectText.SetActive(false);
         }
         else
         {
             insertionsSelectAllButtonTick.SetActive(false);

             for (int i = 0; i < insertionsList.Length; i++)
             {
                 insertionsList[i].SetActive(false);
             }

             foreach (Transform z in insertionsSubButtonsParent.transform)
             {
                // z.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                 z.Find("TickParent").transform.GetChild(0).gameObject.SetActive(false);

             }

             isAllInsertionsSelected = false;
             insertionDeselectText.SetActive(false);
             insertionSelectText.SetActive(true);
         }

     }

     public void selectAllOrigins()
     {
         if (isAllOriginsSelected == false)
         {
             originsSelectAllButtonTick.SetActive(true);

             for (int k = 0; k < originsList.Length; k++)
             {
                 originsList[k].SetActive(true);
             }
             foreach (Transform t in originsSubButtonsParent.transform)
             {
                // t.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
                 t.Find("TickParent").transform.GetChild(0).gameObject.SetActive(true);
             }
             isAllOriginsSelected = true;
             originDeselectText.SetActive(true);
             originSelectText.SetActive(false);
         }
         else
         {
             originsSelectAllButtonTick.SetActive(false);

             for (int k = 0; k < originsList.Length; k++)
             {
                 originsList[k].SetActive(false);
             }

             foreach (Transform t in originsSubButtonsParent.transform)
             {
                 //t.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                 t.Find("TickParent").transform.GetChild(0).gameObject.SetActive(false);

             }

             isAllOriginsSelected = false;
             originDeselectText.SetActive(false);
             originSelectText.SetActive(true);
         }
     }

     public void selectAllLigaments()
     {
         if (isAllLigamentsSelected == false)
         {
             ligamentsSelectAllButtonTick.SetActive(true);

             for (int l = 0; l < ligamentsList.Length; l++)
             {
                 ligamentsList[l].SetActive(true);
             }
             foreach (Transform t in ligamentsSubButtonsParent.transform)
             {
                // t.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
                 t.Find("TickParent").transform.GetChild(0).gameObject.SetActive(true);
             }

             isAllLigamentsSelected = true;
             ligamentsDeselectText.SetActive(true);
             ligamentsSelectText.SetActive(false);
         }
         else
         {
             ligamentsSelectAllButtonTick.SetActive(false);

             for (int l = 0; l < ligamentsList.Length; l++)
             {
                 ligamentsList[l].SetActive(false);
             }

             foreach (Transform t in ligamentsSubButtonsParent.transform)
             {
                 //t.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                 t.Find("TickParent").transform.GetChild(0).gameObject.SetActive(false);
             }

             isAllLigamentsSelected = false;
             ligamentsDeselectText.SetActive(false);
             ligamentsSelectText.SetActive(true);
         }
     }*/

    private void insertionsButtonClickReset()
    {
        origAttach = true;
        onOriginsButtonClick();
    }

    private void originsButtonClickReset()
    {

    }

    public void onOriginsButtonClick()
    {
        if (origAttach == false)
        {
            originsButtonClickReset();
            originObj.SetActive(true);
            femurDefaultObj.SetActive(false);
            origin_dropdown.SetActive(true);

            origAttach = true;
        }
        else
        {
            originObj.SetActive(false);
            femurDefaultObj.SetActive(true);
            origin_dropdown.SetActive(false);

            origAttach = false;
        }
    }
}
