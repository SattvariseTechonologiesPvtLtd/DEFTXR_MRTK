using UnityEngine;
using System.Collections;
using MixedReality.Toolkit.SpatialManipulation;

public class AssetManagementScript : MonoBehaviour
{
    private Quaternion originalRotation;
    private Vector3 originalScale;

    [SerializeField]
    public GameObject[] isolatedMuscleAssets;
    public GameObject[] isolatedBonesAssets;
    public GameObject[] isolatedUpperBonesMenuPanels;

    [SerializeField]
    public GameObject[] isolatedLowerLimbMuscleAssets;
    public GameObject[] isolatedLowerLimbBonesAssets;
    public GameObject[] isolatedLowerLimbBonesMenuPanels;

    [SerializeField]
    public GameObject[] isolatedThoraxMuscleAssets;
    public GameObject[] isolatedThoraxBonesAssets;
    public GameObject[] isolatedThoraxBonesMenuPanels;

    [SerializeField]
    public GameObject[] isolatedAbdomenMuscleAssets;
    public GameObject[] isolatedAbdomenBonesAssets;
    public GameObject[] isolatedAbdomenBonesMenuPanels;

    [SerializeField]
    public GameObject[] isolatedHeadNeckMuscleAssets;
    public GameObject[] isolatedHeadNeckBonesAssets;
    public GameObject[] isolatedHeadNeckBonesMenuPanels;

    [SerializeField]
    public GameObject[] isolatedSkeletonBonesAssets;
    public GameObject[] isolatedSkeletonBonesMenuPanels;

    [SerializeField]
    public GameObject[] isolatedMuscularSystemMuscleAssets;


    public static AssetManagementScript Instance;

    public GameObject isolatedNerves, isolatedMuscles, isolatedArt, isolatedBones;
    public GameObject isolated_object;

    private void Awake()
    {
        Instance = this;
        originalRotation = transform.rotation;
        originalScale = transform.localScale;
    }
    public void setIsolatedMuscleData()
    {
        isolated_object = DEFTXR_UI_Manager.Instance.currentIsolatedObject.transform.GetChild(0).gameObject;

        isolatedMuscles = isolated_object.transform.Find("Muscles").gameObject;
        isolatedBones = isolated_object.transform.Find("Bones").gameObject;
        isolatedArt = isolated_object.transform.Find("Arteries").gameObject;
        isolatedNerves = isolated_object.transform.Find("Nerves").gameObject;
    }

    public void setIsolatedBonesData()
    {
        isolated_object = DEFTXR_UI_Manager.Instance.currentIsolatedObject;
        // isolated_object.SetActive(false);

        if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.upperLimb)
        {
            for (int i = 0; i < isolatedUpperBonesMenuPanels.Length; i++)
            {
                if (i == DEFTXR_UI_Manager.Instance.currentSelectedAssetNo)
                {
                    isolatedUpperBonesMenuPanels[i].SetActive(true);
                }
                else
                {
                    isolatedUpperBonesMenuPanels[i].SetActive(false);

                }
            }
        }
        else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.lowerLimb)
        {
            for (int i = 0; i < isolatedLowerLimbBonesMenuPanels.Length; i++)
            {
                if (i == DEFTXR_UI_Manager.Instance.currentSelectedAssetNo)
                {
                    isolatedLowerLimbBonesMenuPanels[i].SetActive(true);
                }
                else
                {
                    isolatedLowerLimbBonesMenuPanels[i].SetActive(false);
                }
            }
        }
        else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.thorax)
        {
            for (int i = 0; i < isolatedThoraxBonesMenuPanels.Length; i++)
            {
                if (i == DEFTXR_UI_Manager.Instance.currentSelectedAssetNo)
                {
                    isolatedThoraxBonesMenuPanels[i].SetActive(true);
                }
                else
                {
                    isolatedThoraxBonesMenuPanels[i].SetActive(false);
                }
            }
        }
        else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.abdomen)
        {
            for (int i = 0; i < isolatedAbdomenBonesMenuPanels.Length; i++)
            {
                if (i == DEFTXR_UI_Manager.Instance.currentSelectedAssetNo)
                {
                    isolatedAbdomenBonesMenuPanels[i].SetActive(true);
                }
                else
                {
                    isolatedAbdomenBonesMenuPanels[i].SetActive(false);
                }
            }
        }
        else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.headNeck)
        {
            for (int i = 0; i < isolatedHeadNeckBonesMenuPanels.Length; i++)
            {
                if (i == DEFTXR_UI_Manager.Instance.currentSelectedAssetNo)
                {
                    isolatedHeadNeckBonesMenuPanels[i].SetActive(true);
                }
                else
                {
                    isolatedHeadNeckBonesMenuPanels[i].SetActive(false);
                }
            }
        }
        else if (DEFTXR_UI_Manager.Instance.region == DEFTXR_UI_Manager.Region.skeletonSystem)
        {
            for (int i = 0; i < isolatedSkeletonBonesMenuPanels.Length; i++)
            {
                if (i == DEFTXR_UI_Manager.Instance.currentSelectedAssetNo)
                {
                    isolatedSkeletonBonesMenuPanels[i].SetActive(true);

                }
                else
                {
                    isolatedSkeletonBonesMenuPanels[i].SetActive(false);
                }
            }
        }
    }

    public void ResetIsolatedObj()
    {
        if (isolated_object != null)
        {
            // Reset rotation to the original rotation
            isolated_object.transform.rotation = originalRotation;

            // Reset scale to the original scale
            isolated_object.transform.localScale = originalScale;

            if (DEFTXR_UI_Manager.Instance.isIsolatedOn == true)
            {
                AttachMRTK.Instance.detachMRTKFromIsolate(AssetManagementScript.Instance.isolated_object);
                isolated_object.GetComponent<BoxCollider>().enabled = false;
            }

            DEFTXR_UI_Manager.Instance.GizmoButtonPressed.SetActive(false);
            DEFTXR_UI_Manager.Instance.GizmoButton.SetActive(true);

        }
    }

    public void resetData()
    {
        isolated_object.transform.localRotation = Quaternion.identity;


        isolated_object.SetActive(false);

        isolated_object = null;

        isolatedMuscles = null;
        isolatedBones = null;

        isolatedArt = null;

        isolatedNerves = null;

        for (int i = 0; i < isolatedUpperBonesMenuPanels.Length; i++)
        {           
            isolatedUpperBonesMenuPanels[i].SetActive(false);            
        }
        for (int i = 0; i < isolatedLowerLimbBonesMenuPanels.Length; i++)
        {
            isolatedLowerLimbBonesMenuPanels[i].SetActive(false);
        }
        for (int i = 0; i < isolatedThoraxBonesMenuPanels.Length; i++)
        {
            isolatedThoraxBonesMenuPanels[i].SetActive(false);
        }
        for (int i = 0; i < isolatedAbdomenBonesMenuPanels.Length; i++)
        {
            isolatedAbdomenBonesMenuPanels[i].SetActive(false);
        }
        for (int i = 0; i < isolatedHeadNeckBonesMenuPanels.Length; i++)
        {
            isolatedHeadNeckBonesMenuPanels[i].SetActive(false);
        }
        for (int i = 0; i < isolatedSkeletonBonesMenuPanels.Length; i++)
        {
            isolatedSkeletonBonesMenuPanels[i].SetActive(false);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
