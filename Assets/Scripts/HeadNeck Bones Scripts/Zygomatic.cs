using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zygomatic : MonoBehaviour
{
    //public GameObject zoneBObj;
    public GameObject originObj, DefaultObj, featuresObj;

    //public GameObject originDown, originUp, featuresDown, featuresUp;

    public bool attch, origAttach, featureAttach = false;

    //public Sprite enable, disable;

    public GameObject[] featuresList;
    public GameObject[] originsList;


    //public bool isAllFeaturesSelected;
    //public bool isAllOriginsSelected;

    public GameObject feature_dropdown;
    //public GameObject featureSelectAllButtonTick;
    // public GameObject subButtonsParent;

    public GameObject origin_dropdown;
    //public GameObject originsSelectAllButtonTick;
    //public GameObject originsSubButtonsParent;

    public GameObject originBtn;
    public GameObject featureBtn;

    //public GameObject featureSelectText;
    //public GameObject featureDeselectText;

    // public GameObject originSelectText;
    // public GameObject originDeselectText;

    // Use this for initialization
    void Start()
    {
        //isAllFeaturesSelected = false;

        //isAllOriginsSelected = false;
        origin_dropdown.SetActive(false);
        feature_dropdown.SetActive(false);

        // featureBtn.GetComponent<Image>().sprite = disable;
        //insertionBtn.GetComponent<Image>().sprite = disable;
        // originBtn.GetComponent<Image>().sprite = disable;
        // ligamentsBtn.GetComponent<Image>().sprite = disable;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*public void selectAllFeatures()
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
                // t.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                t.Find("TickParent").transform.GetChild(0).gameObject.SetActive(false);

            }

            isAllOriginsSelected = false;
            originDeselectText.SetActive(false);
            originSelectText.SetActive(true);
        }
    }*/


    private void originsButtonClickReset()
    {
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


            originObj.SetActive(true);
            DefaultObj.SetActive(false);

            featuresObj.SetActive(false);
            origin_dropdown.SetActive(true);

            //originDown.SetActive(false);
            //originUp.SetActive(true);

            // originBtn.GetComponent<Image>().sprite = enable;

            origAttach = true;
        }
        else
        {



            originObj.SetActive(false);
            DefaultObj.SetActive(true);

            featuresObj.SetActive(false);
            origin_dropdown.SetActive(false);

            //originDown.SetActive(true);
            //originUp.SetActive(false);

            // originBtn.GetComponent<Image>().sprite = disable;

            origAttach = false;
        }
    }


    private void featureButtonClickReset()
    {

        origAttach = true;
        onOriginsButtonClick();
        //isAllOriginsSelected = true;
        //selectAllOrigins();

    }

    public void onFeaturesButtonClick()
    {
        if (featureAttach == false)
        {
            featureButtonClickReset();
            originObj.SetActive(false);
            DefaultObj.SetActive(false);
            featuresObj.SetActive(true);
            feature_dropdown.SetActive(true);

            //featuresDown.SetActive(false);
            //featuresUp.SetActive(true);

            // featureBtn.GetComponent<Image>().sprite = enable;

            featureAttach = true;
        }
        else
        {

            originObj.SetActive(false);
            DefaultObj.SetActive(true);
            featuresObj.SetActive(false);
            feature_dropdown.SetActive(false);

            //featuresDown.SetActive(true);
            //featuresUp.SetActive(false);

            // featureBtn.GetComponent<Image>().sprite = disable;

            featureAttach = false;
        }
    }
}
