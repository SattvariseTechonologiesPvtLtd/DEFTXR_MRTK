using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Systems_Game_Manager : MonoBehaviour
{

    // references to the respective system parent gameobject
    public GameObject skeletanSyetemObj, muscularSystemObj, LymphSystemObj, circulatorySystemObj,nervSystemObj;

    // Referance to the systems parent game object
    public GameObject Systems_Parent;

    // supine and prone position transform references
    public Transform supine, prone;

    public bool isSkeleton = false;
    public bool isMuscular = false;
    public bool isCirculatory = false;
    public bool isNervous = false;
    

    public Sprite enable, disable;

    public GameObject skeletonBtn;
    public GameObject muscularBtn;
    public GameObject circulatoryBtn;
    public GameObject nervousBtn;
    public GameObject supineBtn;
    public GameObject proneBtn;

    // Use this for initialization
    void Start()
    {
        skeletonBtn.GetComponent<Image>().sprite = enable;
        muscularBtn.GetComponent<Image>().sprite = enable;
        nervousBtn.GetComponent<Image>().sprite = enable;
        circulatoryBtn.GetComponent<Image>().sprite = enable;
        supineBtn.GetComponent<Image>().sprite = enable;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onSkeletalButtonClick()
    {

        if (isSkeleton == false)
        {
            skeletanSyetemObj.SetActive(false);
            skeletonBtn.GetComponent<Image>().sprite = disable;

            isSkeleton = true;
        }
        else
        {
            skeletanSyetemObj.SetActive(true);
            skeletonBtn.GetComponent<Image>().sprite = enable;

            isSkeleton = false;
        }
    }
    
    public void onMuscleButtonClick()
    {
        if(isMuscular == false)
        {
          
            muscularSystemObj.SetActive(false);
            muscularBtn.GetComponent<Image>().sprite = disable;
            isMuscular = true;
        }
        else
        {
           
            muscularSystemObj.SetActive(true);
            muscularBtn.GetComponent<Image>().sprite = enable;
            isMuscular = false;
        }
        
    }


    public void onCirculataryButtonClick()
    {
        if (isCirculatory == false)
        {
            circulatorySystemObj.SetActive(false);
            circulatoryBtn.GetComponent<Image>().sprite = disable;

            isCirculatory = true;
        }
        else
        {
            
            circulatorySystemObj.SetActive(true);
            circulatoryBtn.GetComponent<Image>().sprite = enable;
            isCirculatory = false;
        }
    }
    public void onNervousButtonClick()
    {
        if (isNervous == false)
        {
          
            nervSystemObj.SetActive(false);
            nervousBtn.GetComponent<Image>().sprite = disable;
            isNervous = true;
        }
        else
        {
           
            nervSystemObj.SetActive(true);
            nervousBtn.GetComponent<Image>().sprite = enable;
            isNervous = false;
        }
        
    }


    public void supineButtonClick()
    {
        
            Systems_Parent.transform.position = supine.position;
            Systems_Parent.transform.rotation = supine.rotation;
            supineBtn.GetComponent<Image>().sprite = enable;
            proneBtn.GetComponent<Image>().sprite = disable;
        
    }

    public void proneButtonClick()
    {
        
            Systems_Parent.transform.position = prone.position;
            Systems_Parent.transform.rotation = prone.rotation;
            proneBtn.GetComponent<Image>().sprite = enable;
            supineBtn.GetComponent<Image>().sprite = disable;

    }

}
