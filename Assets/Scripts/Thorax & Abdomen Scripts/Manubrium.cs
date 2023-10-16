using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine.UI;

public class Manubrium : MonoBehaviour
{
    // public GameObject ZoneA, ZoneB, ZoneC;
    //public GameObject zoneBObj;

    public GameObject originObj, DefaultObj;

    public GameObject originDown, originUp;

    // public GameObject featureSelectBtn, insertionSelectBtn, originSelectBtn, ligamentSelectBtn;

    public bool attch, origAttach = false;

    public Sprite enable, disable;

    public GameObject[] originsList;

    public bool isAllOriginsSelected;

    public GameObject origin_dropdown;
    public GameObject originsSelectAllButtonTick;
    public GameObject originsSubButtonsParent;

    public GameObject originBtn;

    public GameObject originSelectText;
    public GameObject originDeselectText;

    // Use this for initialization
    void Start()
    {
        isAllOriginsSelected = false;

        origin_dropdown.SetActive(false);

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
                //t.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
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
                //Debug.Log("| " + t.GetChild(1).name + " | ");


                t.Find("TickParent").transform.GetChild(0).gameObject.SetActive(false);

            }

            isAllOriginsSelected = false;
            originDeselectText.SetActive(false);
            originSelectText.SetActive(true);
        }
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
            DefaultObj.SetActive(false);
            origin_dropdown.SetActive(true);

            originDown.SetActive(false);
            originUp.SetActive(true);
            //  originBtn.GetComponent<Image>().sprite = enable;

            origAttach = true;
        }
        else
        {
            originObj.SetActive(false);
            DefaultObj.SetActive(true);
            origin_dropdown.SetActive(false);

            originDown.SetActive(true);
            originUp.SetActive(false);
            // originBtn.GetComponent<Image>().sprite = disable;

            origAttach = false;
        }
    }
}
