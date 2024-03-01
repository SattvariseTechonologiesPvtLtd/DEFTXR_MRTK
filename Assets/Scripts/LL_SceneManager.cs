using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit.SpatialManipulation;

public class LL_SceneManager : MonoBehaviour
{
    public static LL_SceneManager Instance;

    public bool isAttach = false;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject BoundingBox;
    public double DragToogleThresold = 0.005;
    // Start is called before the first frame update
    void Start()
    {
        DEFTXR_UI_Manager.Instance.lowerLimbButtonClick();
    }

    // Update is called once per frame
    public void attachMRTK(GameObject selected_Object)
    {
        if(isAttach == false)
        {
            selected_Object.gameObject.AddComponent<ObjectManipulator>();
            
            //selected_Object.gameObject.AddComponent<BoxCollider>();
            selected_Object.gameObject.AddComponent<BoundsControl>();
            selected_Object.gameObject.GetComponent<BoundsControl>().BoundsVisualsPrefab = LL_SceneManager.Instance.BoundingBox;
            selected_Object.gameObject.GetComponent<BoundsControl>().OverrideBounds = true;
            //selected_Object.gameObject.GetComponent<BoundsControl>().HandlesActive = true;
            selected_Object.gameObject.GetComponent<BoundsControl>().FlattenMode = FlattenMode.Never;
            selected_Object.gameObject.GetComponent<BoundsControl>().BoundsCalculationMethod = BoundsCalculator.BoundsCalculationMethod.ColliderOnly;
            selected_Object.gameObject.GetComponent<BoundsControl>().BoundsOverride = selected_Object.gameObject.transform;
            selected_Object.gameObject.GetComponent<BoundsControl>().Target = selected_Object.gameObject.transform;
            selected_Object.gameObject.GetComponent<BoundsControl>().DragToggleThreshold = (float)DragToogleThresold;
            selected_Object.gameObject.GetComponent<BoundsControl>().ConstraintsManager = selected_Object.gameObject.GetComponent<ConstraintManager>();
            selected_Object.gameObject.GetComponent<BoundsControl>().EnableConstraints = true;
            selected_Object.gameObject.AddComponent<ConstraintManager>();

            selected_Object.gameObject.AddComponent<MinMaxScaleConstraint>();
            selected_Object.gameObject.GetComponent<MinMaxScaleConstraint>().RelativeToInitialState = false;
            selected_Object.gameObject.GetComponent<MinMaxScaleConstraint>().MinimumScale = new Vector3(1, 1, 1);
            selected_Object.gameObject.GetComponent<MinMaxScaleConstraint>().MaximumScale = new Vector3(3, 3, 3);

            isAttach = true;

        }     
    }
}
