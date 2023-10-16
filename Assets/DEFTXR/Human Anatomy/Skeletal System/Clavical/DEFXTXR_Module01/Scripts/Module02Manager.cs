using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;

public class Module02Manager : MonoBehaviour
{
    public static Module02Manager Instace;
    [SerializeField]



    

    public bool attch, inserAttch, ligamentAttach, origAttach, featureAttach = false;
    public GameObject skeletonInfo, skeletonStatic;
    public GameObject UICan, text01, text02, text03, text04;

    public AudioClip[] tutorial_VO, sideDeterVO;
    public GameObject[] SDUIText;

    public GameObject ZoneA, ZoneB, ZoneC;  
    public GameObject zoneBObj;
    public GameObject pecularitiesObj, sidedeterMinObj;
    public Vector3 leftClavPos, RightClavPos;
    public GameObject LeftClavical;


    private void Awake()
    {
        Instace = this;
    }



    [Header("No of Steps in module explanation")]
    [SerializeField]
    int stepCount;


    [Header("3D object List")]
    [SerializeField]
    List<GameObject> explSteps;

    [Header("UI Explanation List")]
    [SerializeField]
    List<GameObject> explUISteps;

    [Header("VO Explanation List")]
    [SerializeField]
    List<AudioClip> pecularitiesVO, featuresVO, clinicalAnaVo, OssiVo;
    public GameObject pecuraltiesText, featuresParent, featureSlide01, featuresSlide02, ClinicalAnatomyText, OssificationText;
    public AudioSource audioSource;



    GameObject transition;
    GameObject transitionParent;

    public GameObject buttons;

    int reverse, left, right, center, clickCount;
    int offset = 60;
    public List<GameObject> transitions;
    public Material highlightMat, normalMat;

    public GameObject sideDeterParent, clavicalParts;

    public GameObject muscleAttach, muscleUI, insertionLeft, originLeft, clavDefaultLeft, ligamentLeft, featureLeft;
    public GameObject insertionRight, originRight, clavDefaultRight, ligamentRight;

    public bool isClickedStart = false;

    public Sprite enable, disable;

    public GameObject[] featuresList;
    public GameObject[] insertionsList;
    public GameObject[] originsList;
    public GameObject[] ligamentsList;

    public bool isAllFeaturesSelected;
    public bool isAllInsertionsSelected;
    public bool isAllLigamentsSelected;
    public bool isAllOriginsSelected;

    public GameObject feature_dropdown;
    public GameObject featureSelectAllButtonTick;
    public GameObject subButtonsParent;

    public GameObject ligaments_dropdown;
    public GameObject ligamentsSelectAllButtonTick;
    public GameObject ligamentsSubButtonsParent;

    public GameObject origin_dropdown;
    public GameObject originsSelectAllButtonTick;
    public GameObject originsSubButtonsParent;

    public GameObject insertion_dropdown;
    public GameObject insertionSelectAllButtonTick;
    public GameObject insertionSubButtonsParent;

    public GameObject insertionBtn;
    public GameObject ligamentsBtn;
    public GameObject originBtn;
    public GameObject featureBtn;

    // Use this for initialization
    void Start()
    {
        isClickedStart = false;

        leftClavPos = LeftClavical.transform.position;
      


        clickCount = 0;
        StartCoroutine(Startgame());

        isAllFeaturesSelected = false;
        isAllInsertionsSelected = false;
        isAllOriginsSelected = false;
        isAllLigamentsSelected = false;

        insertion_dropdown.SetActive(false);
        ligaments_dropdown.SetActive(false);
        origin_dropdown.SetActive(false);
        feature_dropdown.SetActive(false);

        featureBtn.GetComponent<Image>().sprite = disable;
        insertionBtn.GetComponent<Image>().sprite = disable;
        originBtn.GetComponent<Image>().sprite = disable;
        ligamentsBtn.GetComponent<Image>().sprite = disable;

    }






    public void prevClick()
    {
        if (clickCount == 0)
        {
            Debug.Log("List Ended");
            //transitions[clickCount].GetComponent<Image>().material = highlightMat;
        }
        else
        {
            clickCount--;
            //  changeTransitionUI(clickCount);

            //define what prev
            playNextStep(clickCount);
            playNextVO(clickCount);
            NextStepUI(clickCount);
        }
    }

    public void nextClick()
    {
        if (clickCount == stepCount)
        {
            Debug.Log("List stops");
            // transitions[clickCount - 1].GetComponent<Image>().material = highlightMat;
        }
        else
        {
            if (clickCount < stepCount)
            {
                clickCount++;
                // changeTransitionUI(clickCount);

                //define what next
                playNextStep(clickCount);
                playNextVO(clickCount);
                NextStepUI(clickCount);
            }
            else
            {
                Debug.Log("done");
            }
        }
    }

    void playNextStep(int count)
    {
        for (int i = 0; i < stepCount; i++)
        {
            if (i == count) {

                explSteps[i].SetActive(true);
            }
            else {
                explSteps[i].SetActive(false);
            }
        }

        if (explSteps[count].GetComponent<Animator>() != null)
        {
            explSteps[count].GetComponent<Animator>().SetBool("play", true);
            StartCoroutine(waitToFInish(count));


            Debug.Log("Animation is present");
        }
        else {
            Debug.Log("Animation not Present");
        }
    }

    IEnumerator waitToFInish(int count)
    {
        yield return new WaitUntil(() => explSteps[count].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("1") == true);
        explSteps[count].GetComponent<Animator>().SetBool("play", false);
    }


    public void NextStepUI(int count)
    {
        for (int i = 0; i < stepCount; i++)
        {
            if (i == count)
            {

                explUISteps[i].SetActive(true);
            }
            else
            {
                explUISteps[i].SetActive(false);
            }
        }
    }

    void playNextVO(int count)
    {
        for (int i = 0; i < stepCount; i++)
        {
            audioSource.PlayOneShot(pecularitiesVO[count]);



        }
    }

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
                t.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            }
            isAllFeaturesSelected = true;
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
                s.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);

            }

            isAllFeaturesSelected = false;
        }
    }

    public void selectAllInsertions()
    {
        if (isAllInsertionsSelected == false)
        {
            insertionSelectAllButtonTick.SetActive(true);

            for (int i = 0; i < insertionsList.Length; i++)
            {
                insertionsList[i].SetActive(true);
            }
            foreach (Transform a in insertionSubButtonsParent.transform)
            {
                a.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            }
            isAllInsertionsSelected = true;
        }
        else
        {
            insertionSelectAllButtonTick.SetActive(false);

            for (int i = 0; i < insertionsList.Length; i++)
            {
                insertionsList[i].SetActive(false);
            }

            foreach (Transform z in insertionSubButtonsParent.transform)
            {
                z.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);

            }

            isAllInsertionsSelected = false;
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
                t.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            }
            isAllOriginsSelected = true;
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
                t.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);

            }

            isAllOriginsSelected = false;
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
                t.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            }
            isAllLigamentsSelected = true;
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
                t.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);

            }

            isAllLigamentsSelected = false;
        }
    }


    public void onPecularitiesButtonClick()
    {
        isClickedStart = true;

        sideDeterParent.SetActive(false);
        sidedeterMinObj.SetActive(false);
        clavicalParts.SetActive(false);

        audioSource.Stop();
        StopAllCoroutines();
       
        pecularities();
    }

    public void onFeaturesButtonClick()
    {
        isClickedStart = true;

        sideDeterParent.SetActive(false);
        sidedeterMinObj.SetActive(false);
        clavicalParts.SetActive(false);

        audioSource.Stop();
        StopAllCoroutines();
        features();
    }

    public void onFeaturesPrevButtonClick()
    {
        isClickedStart = true;

        sideDeterParent.SetActive(false);
        sidedeterMinObj.SetActive(false);
        clavicalParts.SetActive(false);
        audioSource.Stop();
        StopAllCoroutines();
        StartCoroutine(features_explanation_slie01());
    }

    public void onFeaturesNextButtonClick()
    {
        isClickedStart = true;
        audioSource.Stop();
        StopAllCoroutines();
        StartCoroutine(features_explanation_slie02());
    }

    public void onOssificationButtonClick()
    {
        isClickedStart = true;
        audioSource.Stop();
        StopAllCoroutines();
        StartCoroutine(ossicfication());
    }
    public void onClinicalAnatomyButtonClick()
    {
        isClickedStart = true;

        sideDeterParent.SetActive(false);
        sidedeterMinObj.SetActive(false);
        clavicalParts.SetActive(false);
        audioSource.Stop();
        StopAllCoroutines();
        StartCoroutine(clinicalAnatomy());
    }

    public void onSideDeterminationButtonClick()
    {
        isClickedStart = true;

        sideDeterParent.SetActive(false);
        sidedeterMinObj.SetActive(false);
        clavicalParts.SetActive(false);

        audioSource.Stop();
        StopAllCoroutines();
     
        StartCoroutine(sideDetermination());
    }

    public void onInsertionButtonClick()
    {
        if (inserAttch == false)
        {
          
            insertionLeft.SetActive(true);
            originLeft.SetActive(false);
            clavDefaultLeft.SetActive(false);
            ligamentLeft.SetActive(false);
            insertion_dropdown.SetActive(true);


            inserAttch = true;
        }
        else
        {

            insertionLeft.SetActive(false);
            originLeft.SetActive(false);
            clavDefaultLeft.SetActive(true);
            ligamentLeft.SetActive(false);
            insertion_dropdown.SetActive(false);

            inserAttch = false;
        }
    }

    public void onOriginButtonClick()
    {
        if (origAttach == false)
        {
          
            originLeft.SetActive(true);
            insertionLeft.SetActive(false);
            clavDefaultLeft.SetActive(false);
            ligamentLeft.SetActive(false);
            origin_dropdown.SetActive(true);

            origAttach = true;
        }
        else
        {

        
            originLeft.SetActive(false);
            insertionLeft.SetActive(false);
            clavDefaultLeft.SetActive(true);
            ligamentLeft.SetActive(false);
            origin_dropdown.SetActive(false);

            origAttach = false;
        }
    }

    public void onLigamentsButtonClick()
    {
        if (ligamentAttach == false)
        {
           
            originLeft.SetActive(false);
            insertionLeft.SetActive(false);
            clavDefaultLeft.SetActive(false);
            ligamentLeft.SetActive(true);
            ligaments_dropdown.SetActive(true);

            ligamentAttach = true;
        }
        else
        {
    
            originLeft.SetActive(false);
            insertionLeft.SetActive(false);
            clavDefaultLeft.SetActive(true);
            ligamentLeft.SetActive(false);
            ligaments_dropdown.SetActive(false);

            ligamentAttach = false;
        }

    }

    public void onFeatureButtonClick()
    {
        if (featureAttach == false)
        {

            originLeft.SetActive(false);
            insertionLeft.SetActive(false);
            clavDefaultLeft.SetActive(false);
            ligamentLeft.SetActive(false);
            featureLeft.SetActive(true);
            feature_dropdown.SetActive(true);

            featureAttach = true;
        }
        else
        {

            originLeft.SetActive(false);
            insertionLeft.SetActive(false);
            clavDefaultLeft.SetActive(true);
            ligamentLeft.SetActive(false);
            featureLeft.SetActive(false);

            feature_dropdown.SetActive(false);

            featureAttach = false;
        }

    }



    // Update is called once per frame
    void Update()
    {
        

           // ClickandSelect();
        


    }


    IEnumerator sideDetermination()
    {


        featuresParent.SetActive(false);
        pecuraltiesText.SetActive(false);
        featureSlide01.SetActive(false);
        featuresSlide02.SetActive(false);
        ClinicalAnatomyText.SetActive(false);
        OssificationText.SetActive(false);

        pecularitiesObj.SetActive(false);
        sideDeterParent.SetActive(true);
        sidedeterMinObj.SetActive(true);
        clavicalParts.SetActive(true);
        yield return new WaitForSeconds(1f);

        buttons.SetActive(false);

        //sideDeterUI.SetActive(true);

        clavicalParts.GetComponent<Animator>().enabled = true;




        audioSource.PlayOneShot(sideDeterVO[0]);
        clavicalParts.GetComponent<Animator>().SetInteger("sidestep", 1);
        SDUIText[0].SetActive(true);



        yield return new WaitForSeconds(sideDeterVO[0].length);

        //A pause between VOs
        yield return new WaitForSeconds(3f);

        audioSource.PlayOneShot(sideDeterVO[1]);
        clavicalParts.GetComponent<Animator>().SetInteger("sidestep", 2);
        SDUIText[1].SetActive(true);
        SDUIText[0].SetActive(false);




        yield return new WaitForSeconds(sideDeterVO[1].length);
        //A pause between VOs
        yield return new WaitForSeconds(3f);

        audioSource.PlayOneShot(sideDeterVO[2]);
        clavicalParts.GetComponent<Animator>().SetInteger("sidestep", 3);
        SDUIText[2].SetActive(true);
        SDUIText[1].SetActive(false);
        yield return new WaitForSeconds(sideDeterVO[2].length);

        sideDeterParent.SetActive(false);
        sidedeterMinObj.SetActive(false);
        clavicalParts.SetActive(false);
        isClickedStart = false;
    }

    IEnumerator Startgame()
    {

        yield return new WaitForSeconds(5f);
        skeletonStatic.SetActive(false);
        skeletonInfo.SetActive(true);

        ZoneA.SetActive(true);
        skeletonInfo.GetComponent<Animator>().enabled = true;
        UICan.SetActive(true);

        audioSource.PlayOneShot(tutorial_VO[0]);
        skeletonInfo.GetComponent<Animator>().SetInteger("step", 1);
        text01.SetActive(true);

        float temp = tutorial_VO[0].length / 2;

        yield return new WaitForSeconds(temp);

        skeletonInfo.GetComponent<Animator>().SetInteger("step", 2);
        yield return new WaitForSeconds(temp);


        //A pause between VOs
        yield return new WaitForSeconds(3f);

        text02.SetActive(true);
        text01.SetActive(false);
        skeletonInfo.GetComponent<Animator>().SetInteger("step", 3);
        audioSource.PlayOneShot(tutorial_VO[1]);
        yield return new WaitForSeconds(tutorial_VO[1].length);

        //A pause between VOs
        /*
        yield return new WaitForSeconds(3f);
        text02.SetActive(false);
        audioSource.PlayOneShot(tutorial_VO[2]);
      

        skeletonInfo.GetComponent<Animator>().SetInteger("step", 4); text03.SetActive(true);
        audioSource.PlayOneShot(tutorial_VO[2]);
        yield return new WaitForSeconds(tutorial_VO[2].length);*/

        //A pause between VOs
        yield return new WaitForSeconds(3f);
        text02.SetActive(false);
        //text03.SetActive(false);
        skeletonInfo.GetComponent<Animator>().SetInteger("step", 4); text04.SetActive(true);
        audioSource.PlayOneShot(tutorial_VO[3]);
        yield return new WaitForSeconds(tutorial_VO[3].length);


        skeletonStatic.SetActive(true);
        skeletonInfo.SetActive(false);
        ZoneA.SetActive(false);
        yield return new WaitForSeconds(5f);
        //A pause between VOs
        yield return new WaitForSeconds(3f);

        //ZoneB and Zone C activated

        UIManager.Instance.zoneBplat.SetActive(true);
        UIManager.Instance.zoneCplat.SetActive(true);
        UIManager.Instance.zoneAPlat.SetActive(false);


        ZoneA.SetActive(false);
        ZoneB.SetActive(true);
        zoneBObj.SetActive(true);
        sidedeterMinObj.SetActive(false);
        ZoneC.SetActive(true);

       // buttons.SetActive(true);

        pecularitiesObj.SetActive(true);


    }


    void pecularities()
    {
        

        StartCoroutine(pecularties_explain());




        // playNextStep(clickCount);
        //  playNextVO(clickCount);
        //  NextStepUI(clickCount);
    }

    IEnumerator pecularties_explain()
    {
        featuresParent.SetActive(false);
        pecuraltiesText.SetActive(false);
        featureSlide01.SetActive(false);
        featuresSlide02.SetActive(false);
        ClinicalAnatomyText.SetActive(false);
        OssificationText.SetActive(false);


        pecuraltiesText.SetActive(true);

        pecuraltiesText.GetComponent<Animator>().SetInteger("pecustep", 0);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(pecularitiesVO[0]);
        yield return new WaitForSeconds(pecularitiesVO[0].length);

        pecuraltiesText.GetComponent<Animator>().SetInteger("pecustep", 1);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(pecularitiesVO[1]);
        yield return new WaitForSeconds(pecularitiesVO[1].length);

        pecuraltiesText.GetComponent<Animator>().SetInteger("pecustep", 2);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(pecularitiesVO[2]);
        yield return new WaitForSeconds(pecularitiesVO[2].length);

        pecuraltiesText.GetComponent<Animator>().SetInteger("pecustep", 3);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(pecularitiesVO[3]);
        yield return new WaitForSeconds(pecularitiesVO[3].length);

        pecuraltiesText.GetComponent<Animator>().SetInteger("pecustep", 4);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(pecularitiesVO[4]);
        yield return new WaitForSeconds(pecularitiesVO[4].length);

        pecuraltiesText.GetComponent<Animator>().SetInteger("pecustep", 5);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(pecularitiesVO[5]);
        yield return new WaitForSeconds(pecularitiesVO[5].length);

        pecuraltiesText.GetComponent<Animator>().SetInteger("pecustep", 6);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(pecularitiesVO[6]);
        yield return new WaitForSeconds(pecularitiesVO[6].length);
      
        isClickedStart = false;
    }


    void features()
    {

        pecuraltiesText.SetActive(false);
        featureSlide01.SetActive(false);
        featuresSlide02.SetActive(false);
        ClinicalAnatomyText.SetActive(false);
        OssificationText.SetActive(false);
        




        featuresParent.SetActive(true);



        StartCoroutine(features_explanation_slie01());

    }

    IEnumerator features_explanation_slie01() {

        featureSlide01.SetActive(true);
        featuresSlide02.SetActive(false);

        featureSlide01.GetComponent<Animator>().SetInteger("feat01Step", 1);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(featuresVO[0]);
        yield return new WaitForSeconds(featuresVO[0].length);

        featureSlide01.GetComponent<Animator>().SetInteger("feat01Step", 2);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(featuresVO[1]);
        yield return new WaitForSeconds(featuresVO[1].length);
        yield return new WaitForSeconds(2f);
        StartCoroutine(features_explanation_slie02());

    }

    IEnumerator features_explanation_slie02()
    {
        featureSlide01.SetActive(false);
        featuresSlide02.SetActive(true);


        featuresSlide02.GetComponent<Animator>().SetInteger("feat02Step", 1);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(featuresVO[2]);
        yield return new WaitForSeconds(featuresVO[2].length);

        featuresSlide02.GetComponent<Animator>().SetInteger("feat02Step", 2);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(featuresVO[3]);
        yield return new WaitForSeconds(featuresVO[3].length);

        featuresSlide02.GetComponent<Animator>().SetInteger("feat02Step", 3);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(featuresVO[4]);
        yield return new WaitForSeconds(featuresVO[4].length);

       
        isClickedStart = false;

    }

    IEnumerator clinicalAnatomy()
    {
        featuresParent.SetActive(false);
        pecuraltiesText.SetActive(false);
        sideDeterParent.SetActive(false);
        featuresParent.SetActive(false);
        OssificationText.SetActive(false);
        ClinicalAnatomyText.SetActive(true);
        audioSource.PlayOneShot(clinicalAnaVo[0]);
        yield return new WaitForSeconds(clinicalAnaVo[0].length);
        isClickedStart = false;
     

    }

    IEnumerator ossicfication()
    {
        featuresParent.SetActive(false);
        pecuraltiesText.SetActive(false);
        sideDeterParent.SetActive(false);
        featuresParent.SetActive(false);
        OssificationText.SetActive(true);
        ClinicalAnatomyText.SetActive(false);
        audioSource.PlayOneShot(OssiVo[0]);
        yield return new WaitForSeconds(OssiVo[0].length);
      
        isClickedStart = false;
    }




    

   

}


