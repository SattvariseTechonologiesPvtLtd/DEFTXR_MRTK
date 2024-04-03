using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine.UI;

public class T09 : MonoBehaviour
{
    // public GameObject ZoneA, ZoneB, ZoneC;
    //public GameObject zoneBObj;

    public GameObject insertionObj, originObj, DefaultObj, featuresObj;

    //public GameObject insertionDown, insertionUp, originDown, originUp,featuresDown, featuresUp;

    // public GameObject featureSelectBtn, insertionSelectBtn, originSelectBtn, ligamentSelectBtn;

    public bool attch, inserAttch, origAttach, featureAttach = false;

    //public Sprite enable, disable;

    public GameObject[] featuresList;
    public GameObject[] insertionsList;
    public GameObject[] originsList;

    //public bool isAllFeaturesSelected;
    //public bool isAllInsertionsSelected;
    //public bool isAllOriginsSelected;

    public GameObject feature_dropdown;
    //public GameObject featureSelectAllButtonTick;
    //public GameObject subButtonsParent;

    public GameObject origin_dropdown;
    //public GameObject originsSelectAllButtonTick;
    //public GameObject originsSubButtonsParent;

    public GameObject insertion_dropdown;
    //public GameObject insertionsSelectAllButtonTick;
    //public GameObject insertionsSubButtonsParent;

    public GameObject insertionBtn;
    public GameObject originBtn;
    public GameObject featureBtn;

    //public GameObject featureSelectText;
    //public GameObject featureDeselectText;

    //public GameObject originSelectText;
    //public GameObject originDeselectText;

    //public GameObject insertionSelectText;
    //public GameObject insertionDeselectText;

    // Use this for initialization
    void Start()
    {

        //isAllFeaturesSelected = false;
        //isAllInsertionsSelected = false;
        //isAllOriginsSelected = false;

        insertion_dropdown.SetActive(false);
        origin_dropdown.SetActive(false);
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

    private void insertionsButtonClickReset()
    {
        origAttach = true;
        onOriginsButtonClick();

        featureAttach = true;
        onFeaturesButtonClick();
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
            featuresObj.SetActive(false);
            insertion_dropdown.SetActive(true);

            inserAttch = true;
        }
        else
        {

            insertionObj.SetActive(false);
            originObj.SetActive(false);
            DefaultObj.SetActive(true);
            featuresObj.SetActive(false);
            insertion_dropdown.SetActive(false);

            inserAttch = false;
        }

    }

    private void originsButtonClickReset()
    {
        inserAttch = true;
        onInsertionsButtonClick();

        featureAttach = true;
        onFeaturesButtonClick();
    }

    public void onOriginsButtonClick()
    {


        if (origAttach == false)
        {
            originsButtonClickReset();
            insertionObj.SetActive(false);
            originObj.SetActive(true);
            DefaultObj.SetActive(false);
            featuresObj.SetActive(false);
            origin_dropdown.SetActive(true);

            origAttach = true;
        }
        else
        {
            insertionObj.SetActive(false);
            originObj.SetActive(false);
            DefaultObj.SetActive(true);
            featuresObj.SetActive(false);
            origin_dropdown.SetActive(false);

            origAttach = false;
        }
    }


    private void featureButtonClickReset()
    {
        inserAttch = true;
        onInsertionsButtonClick();

        origAttach = true;
        onOriginsButtonClick();
    }

    public void onFeaturesButtonClick()
    {


        if (featureAttach == false)
        {
            featureButtonClickReset();
            insertionObj.SetActive(false);
            originObj.SetActive(false);
            DefaultObj.SetActive(false);
            featuresObj.SetActive(true);
            feature_dropdown.SetActive(true);

            featureAttach = true;
        }
        else
        {

            insertionObj.SetActive(false);
            originObj.SetActive(false);
            DefaultObj.SetActive(true);
            featuresObj.SetActive(false);
            feature_dropdown.SetActive(false);
            featureAttach = false;
        }
    }
}
