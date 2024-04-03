using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine.UI;

public class Rib_4 : MonoBehaviour
{
    // public GameObject ZoneA, ZoneB, ZoneC;
    //public GameObject zoneBObj;

    public GameObject insertionObj, originObj, DefaultObj;

    //public GameObject insertionDown, insertionUp, originDown, originUp;

    // public GameObject featureSelectBtn, insertionSelectBtn, originSelectBtn, ligamentSelectBtn;

    public bool attch, inserAttch, origAttach = false;

    //public Sprite enable, disable;

    public GameObject[] insertionsList;
    public GameObject[] originsList;

    //public bool isAllInsertionsSelected;
    //public bool isAllOriginsSelected;

    public GameObject origin_dropdown;
    //public GameObject originsSelectAllButtonTick;
    //public GameObject originsSubButtonsParent;

    public GameObject insertion_dropdown;
    //public GameObject insertionsSelectAllButtonTick;
    //public GameObject insertionsSubButtonsParent;

    public GameObject insertionBtn;
    public GameObject originBtn;

    //public GameObject originSelectText;
    //public GameObject originDeselectText;

    //public GameObject insertionSelectText;
    //public GameObject insertionDeselectText;

    // Use this for initialization
    void Start()
    {
        //isAllInsertionsSelected = false;
        //isAllOriginsSelected = false;

        insertion_dropdown.SetActive(false);
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

    private void insertionsButtonClickReset()
    {
        origAttach = true;
        onOriginsButtonClick();
    }

    public void onInsertionsButtonClick()
    {
        insertionsButtonClickReset();

        if (inserAttch == false)
        {
            insertionsButtonClickReset();
            insertionObj.SetActive(true);
            originObj.SetActive(false);
            DefaultObj.SetActive(false);
            insertion_dropdown.SetActive(true);

            inserAttch = true;
        }
        else
        {

            insertionObj.SetActive(false);
            originObj.SetActive(false);
            DefaultObj.SetActive(true);
            insertion_dropdown.SetActive(false);

            inserAttch = false;
        }

    }

    private void originsButtonClickReset()
    {
        inserAttch = true;
        onInsertionsButtonClick();
    }

    public void onOriginsButtonClick()
    {


        if (origAttach == false)
        {
            originsButtonClickReset();
            insertionObj.SetActive(false);
            originObj.SetActive(true);
            DefaultObj.SetActive(false);
            origin_dropdown.SetActive(true);

            origAttach = true;
        }
        else
        {
            insertionObj.SetActive(false);
            originObj.SetActive(false);
            DefaultObj.SetActive(true);
            origin_dropdown.SetActive(false);

            origAttach = false;
        }
    }
}
