using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isolatedMusclesManager : MonoBehaviour
{
    public static isolatedMusclesManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public bool isNervesOn, isMusclesOn, isVainsOn, isBonesOn;
    //public float angleX, angleY;

    //public Slider speedSlider;
    //public float speedAngle;

    //[SerializeField] private Slider horizontalSlider, verticleSlider;

    List<GameObject> parts;
    int index;
    private float horizontal_prevValue, verticle_prevValue;

    // Use this for initialization
    void Start()
    {
        isMusclesOn = isVainsOn = isNervesOn = isBonesOn = true;
        //speedSlider.value = 0.1f;
        parts = new List<GameObject>();
        index = -1;

        //slider init

        //horizontalSlider.onValueChanged.AddListener(OnHorizontalSliderChanged);
        //verticleSlider.onValueChanged.AddListener(OnVerticleSliderChanged);
        //verticle_prevValue = horizontal_prevValue = 0.5f;
        //horizontalSlider.value = 0.5f;
        //verticleSlider.value = 0.5f;

        //DEFTXR_UI_Manager.Instance.isolateMuscleBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
        //DEFTXR_UI_Manager.Instance.isolateBoneBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
        //DEFTXR_UI_Manager.Instance.isolateNervesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
        //DEFTXR_UI_Manager.Instance.isolateArteriesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
    }

    void OnHorizontalSliderChanged(float value)
    {
        // How much we've changed

        //Debug.Log("Value" + value);
        if (value == 0.5f)
        {
            Debug.Log("No Change" + value);
        }
        else
        {
            Debug.Log("Change" + value);
            float delta = value - horizontal_prevValue;
            //AssetManagementScript.Instance.isolated_object.transform.Rotate(Vector3.right * delta * 360f);
            if (AssetManagementScript.Instance.isolated_object != null)
            {
                if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.upperLimb)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, Vector3.right);
                }
                else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.lowerLimb)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, Vector3.right);
                }
                else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.thorax)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, Vector3.right);
                }
                else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.abdomen)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, Vector3.right);
                }
                else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.headNeck)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, Vector3.right);
                }
                else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.muscularSystem)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, Vector3.right);
                }
            }

            // Set our previous value for the next change
            //horizontal_prevValue = value;

        }

    }

    void OnVerticleSliderChanged(float value)
    {

        if (value == 0.5f)
        {
            Debug.Log("No Change" + value);
        }
        else
        {           // How much we've changed
            float delta = value - verticle_prevValue;

            if (AssetManagementScript.Instance.isolated_object != null)
            {
                //AssetManagementScript.Instance.isolated_object.transform.Rotate(Vector3.up * delta * 360f);

                if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.upperLimb)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, Vector3.up);
                }
                else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.lowerLimb)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, -Vector3.up);
                }
                else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.thorax)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, -Vector3.up);
                }
                else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.abdomen)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, -Vector3.up);
                }
                else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.headNeck)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, -Vector3.up);
                }
                else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.muscularSystem)
                {
                    AssetManagementScript.Instance.isolated_object.transform.rotation = Quaternion.AngleAxis(delta * 360f, -Vector3.up);
                }
            }
            // Set our previous value for the next change
            // verticle_prevValue = value;

        }

    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log("" + speedSlider.value*100);
    }



    public void onMusclesButtonClick()
    {
        if (isMusclesOn == false)
        {
            AssetManagementScript.Instance.isolatedMuscles.SetActive(true);
            DEFTXR_UI_Manager.Instance.isolateMuscleBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            isMusclesOn = true;
        }
        else
        {
            AssetManagementScript.Instance.isolatedMuscles.SetActive(false);
            DEFTXR_UI_Manager.Instance.isolateMuscleBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            isMusclesOn = false;
        }
    }

    public void onVainsButtonClick()
    {
        if (isVainsOn == false)
        {
            AssetManagementScript.Instance.isolatedArt.SetActive(true);
            DEFTXR_UI_Manager.Instance.isolateArteriesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            isVainsOn = true;
        }
        else
        {
            AssetManagementScript.Instance.isolatedArt.SetActive(false);
            DEFTXR_UI_Manager.Instance.isolateArteriesBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            isVainsOn = false;
        }
    }

    public void onNervesButtonClick()
    {
        if (isNervesOn == false)
        {
            AssetManagementScript.Instance.isolatedNerves.SetActive(true);
            DEFTXR_UI_Manager.Instance.isolateNervesBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            isNervesOn = true;
        }
        else
        {
            AssetManagementScript.Instance.isolatedNerves.SetActive(false);
            DEFTXR_UI_Manager.Instance.isolateNervesBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            isNervesOn = false;
        }
    }
    public void onBonesButtonClick()
    {
        if (isBonesOn == false)
        {
            AssetManagementScript.Instance.isolatedBones.SetActive(true);
            DEFTXR_UI_Manager.Instance.isolateBoneBtn.GetComponent<toggleSelectionImage>().updatedSelection(true);
            isBonesOn = true;
        }
        else
        {
            AssetManagementScript.Instance.isolatedBones.SetActive(false);
            DEFTXR_UI_Manager.Instance.isolateBoneBtn.GetComponent<toggleSelectionImage>().updatedSelection(false);
            isBonesOn = false;
        }
    }

    public void varticleRotateButtonClick()
    {
        //speedAngle = speedSlider.value * 100;
        // DEFTXR_UI_Manager.Instance.deltoid_isolate.transform.Rotate(0, speedAngle, 0);

        //AssetManagementScript.Instance.isolated_object.transform.localEulerAngles += new Vector3(0, speedAngle, 0);
        //AssetManagementScript.Instance.isolated_object.transform.localEulerAngles += new Vector3(0, verticleSlider.value, 0);

        //angleY = AssetManagementScript.Instance.isolated_object.transform.rotation.y;
    }

    public void horizontalRotateButtonClick()
    {
        //speedAngle = speedSlider.value * 100;
        //DEFTXR_UI_Manager.Instance.deltoid_isolate.transform.Rotate(speedAngle, 0, 0);

        //AssetManagementScript.Instance.isolated_object.transform.Rotate(speedAngle, 0, 0);
        //AssetManagementScript.Instance.isolated_object.transform.Rotate(horizontalSlider.value, 0, 0);

        // AssetManagementScript.Instance.isolated_object.transform.localEulerAngles += new Vector3(speedAngle, 0, 0);

    }

    public void hideButtonClick()
    {

        parts.Add(DEFTXR_UI_Manager.Instance.currentSelectObject);
        index++;
        DEFTXR_UI_Manager.Instance.currentSelectObject.SetActive(false);

        //DEFTXR_UI_Manager.Instance.BButtonHighLight.SetActive(false);
        //DEFTXR_UI_Manager.Instance.AButtonHighLight.SetActive(true); 
    }
    public void undoButtonClick()
    {
        if (index >= 0)
        {
            DEFTXR_UI_Manager.Instance.currentSelectObject = parts[index];
            DEFTXR_UI_Manager.Instance.currentSelectObject.SetActive(true);
            parts.RemoveAt(index);
            index--;

            //DEFTXR_UI_Manager.Instance.BButtonHighLight.SetActive(true);
            //DEFTXR_UI_Manager.Instance.AButtonHighLight.SetActive(false);
        }
        else
        {
            //DEFTXR_UI_Manager.Instance.AButtonHighLight.SetActive(false);
        }
    }
}


