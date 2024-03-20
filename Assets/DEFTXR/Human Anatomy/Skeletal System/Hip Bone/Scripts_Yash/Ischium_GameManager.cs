using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine.UI;

public class Ischium_GameManager : MonoBehaviour
{
    // public GameObject ZoneA, ZoneB, ZoneC;
    public GameObject zoneBObj;

    public GameObject originObj, femurDefaultObj, featuresObj;

    //public GameObject insertionDown, insertionUp, originDown, originUp, ligamentsDown, ligamentsUp, featuresDown, featuresUp;

    // public GameObject featureSelectBtn, insertionSelectBtn, originSelectBtn, ligamentSelectBtn;

    public bool attch, origAttach, featureAttach = false;

    //public Sprite enable, disable;

    public GameObject[] featuresList;
    //public GameObject[] insertionsList;
    public GameObject[] originsList;
    //public GameObject[] ligamentsList;

    //public bool isAllFeaturesSelected;
    //public bool isAllInsertionsSelected;
    // public bool isAllLigamentsSelected;
    //public bool isAllOriginsSelected;

    public GameObject feature_dropdown;
    //public GameObject featureSelectAllButtonTick;
    // public GameObject subButtonsParent;

    //public GameObject ligaments_dropdown;
    // public GameObject ligamentsSelectAllButtonTick;
    // public GameObject ligamentsSubButtonsParent;

    public GameObject origin_dropdown;
    // public GameObject originsSelectAllButtonTick;
    // public GameObject originsSubButtonsParent;

    //public GameObject insertion_dropdown;
    // public GameObject insertionsSelectAllButtonTick;
    // public GameObject insertionsSubButtonsParent;

    //public GameObject insertionBtn;
    //public GameObject ligamentsBtn;
    public GameObject originBtn;
    public GameObject featureBtn;

    // public GameObject featureSelectText;
    //public GameObject featureDeselectText;

    // public GameObject originSelectText;
    // public GameObject originDeselectText;

    // public GameObject ligamentsSelectText;
    // public GameObject ligamentsDeselectText;

    // public GameObject insertionSelectText;
    // public GameObject insertionDeselectText;

    // Use this for initialization
    void Start()
    {

        // isAllFeaturesSelected = false;
        // isAllInsertionsSelected = false;
        // isAllOriginsSelected = false;
        // isAllLigamentsSelected = false;

        //insertion_dropdown.SetActive(false);
        //ligaments_dropdown.SetActive(false);
        origin_dropdown.SetActive(false);
        feature_dropdown.SetActive(false);

        //featureBtn.GetComponent<Image>().sprite = disable;
        // insertionBtn.GetComponent<Image>().sprite = disable;
        //originBtn.GetComponent<Image>().sprite = disable;
        // ligamentsBtn.GetComponent<Image>().sprite = disable;

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

    /*private void insertionsButtonClickReset()
    {
        origAttach = true;
        onOriginsButtonClick();
        //isAllOriginsSelected = true;
        //selectAllOrigins();

        ligamentAttach = true;
        onLigamentsButtonClick();
        //isAllLigamentsSelected = true;
        // selectAllLigaments();

        featureAttach = true;
        onFeaturesButtonClick();
        //isAllFeaturesSelected = true;
        //selectAllFeatures();
    }*/

    /*public void onInsertionsButtonClick()
    {


        if (inserAttch == false)
        {
            insertionsButtonClickReset();
            insertionObj.SetActive(true);
            originObj.SetActive(false);
            femurDefaultObj.SetActive(false);
            ligamentObj.SetActive(false);
            featuresObj.SetActive(false);
            insertion_dropdown.SetActive(true);

            //insertionDown.SetActive(false);
            //insertionUp.SetActive(true);

            //insertionBtn.GetComponent<Image>().sprite = enable;

            inserAttch = true;
        }
        else
        {

            insertionObj.SetActive(false);
            originObj.SetActive(false);
            femurDefaultObj.SetActive(true);
            ligamentObj.SetActive(false);
            featuresObj.SetActive(false);
            insertion_dropdown.SetActive(false);

            //insertionDown.SetActive(true);
            //insertionUp.SetActive(false);

            //insertionBtn.GetComponent<Image>().sprite = disable;

            inserAttch = false;
        }

    }*/

    private void originsButtonClickReset()
    {
        //inserAttch = true;
        //onInsertionsButtonClick();
        //isAllInsertionsSelected = true;
        //selectAllInsertions();

        //ligamentAttach = true;
        //onLigamentsButtonClick();
        //isAllLigamentsSelected = true;
        //selectAllLigaments();

        featureAttach = true;
        onFeaturesButtonClick();
        //isAllFeaturesSelected = true;
        //selectAllFeatures();
    }

    public void onOriginsButtonClick()
    {


        if (origAttach == false)
        {
            originsButtonClickReset();

            //insertionObj.SetActive(false);
            originObj.SetActive(true);
            femurDefaultObj.SetActive(false);
            //ligamentObj.SetActive(false);
            featuresObj.SetActive(false);
            origin_dropdown.SetActive(true);

            // originDown.SetActive(false);
            // originUp.SetActive(true);

            //originBtn.GetComponent<Image>().sprite = enable;

            origAttach = true;
        }
        else
        {
            //insertionObj.SetActive(false);
            originObj.SetActive(false);
            femurDefaultObj.SetActive(true);
            //ligamentObj.SetActive(false);
            featuresObj.SetActive(false);
            origin_dropdown.SetActive(false);

            //originDown.SetActive(true);
            // originUp.SetActive(false);

            // originBtn.GetComponent<Image>().sprite = disable;

            origAttach = false;
        }
    }

    /*private void ligamentsButtonClickReset()
    {
        //inserAttch = true;
        //onInsertionsButtonClick();
        //isAllInsertionsSelected = true;
        //selectAllInsertions();

        origAttach = true;
        onOriginsButtonClick();
        //isAllOriginsSelected = true;
        //selectAllOrigins();

        featureAttach = true;
        onFeaturesButtonClick();
        //isAllFeaturesSelected = true;
        //selectAllFeatures();
    }*/

    /*public void onLigamentsButtonClick()
    {


        if (ligamentAttach == false)
        {
            ligamentsButtonClickReset();

            insertionObj.SetActive(false);
            originObj.SetActive(false);
            femurDefaultObj.SetActive(false);
            ligamentObj.SetActive(true);
            featuresObj.SetActive(false);
            ligaments_dropdown.SetActive(true);

            //ligamentsDown.SetActive(false);
            //ligamentsUp.SetActive(true);

            // ligamentsBtn.GetComponent<Image>().sprite = enable;

            ligamentAttach = true;
        }
        else
        {


            insertionObj.SetActive(false);
            originObj.SetActive(false);
            femurDefaultObj.SetActive(true);
            ligamentObj.SetActive(false);
            featuresObj.SetActive(false);
            ligaments_dropdown.SetActive(false);

            //ligamentsDown.SetActive(true);
            // ligamentsUp.SetActive(false);

            //ligamentsBtn.GetComponent<Image>().sprite = disable;


            ligamentAttach = false;
        }

    }*/

    private void featureButtonClickReset()
    {
        //inserAttch = true;
        //onInsertionsButtonClick();
        // isAllInsertionsSelected = true;
        // selectAllInsertions();

        origAttach = true;
        onOriginsButtonClick();
        //isAllOriginsSelected = true;
        // selectAllOrigins();

        //ligamentAttach = true;
        //onLigamentsButtonClick();
        // isAllLigamentsSelected = true;
        // selectAllLigaments();
    }

    public void onFeaturesButtonClick()
    {


        if (featureAttach == false)
        {
            featureButtonClickReset();
            //insertionObj.SetActive(false);
            originObj.SetActive(false);
            femurDefaultObj.SetActive(false);
            //ligamentObj.SetActive(false);
            featuresObj.SetActive(true);
            feature_dropdown.SetActive(true);

            // featuresDown.SetActive(false);
            //  featuresUp.SetActive(true);

            // featureBtn.GetComponent<Image>().sprite = enable;
            featureAttach = true;
        }
        else
        {

            //insertionObj.SetActive(false);
            originObj.SetActive(false);
            femurDefaultObj.SetActive(true);
            //ligamentObj.SetActive(false);
            featuresObj.SetActive(false);
            feature_dropdown.SetActive(false);

            //featuresDown.SetActive(true);
            // featuresUp.SetActive(false);
            //  featureBtn.GetComponent<Image>().sprite = disable;
            featureAttach = false;
        }
    }
}
