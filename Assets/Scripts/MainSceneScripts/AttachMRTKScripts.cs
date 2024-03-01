using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit.SpatialManipulation;

public class AttachMRTKScripts : MonoBehaviour
{
    public static AttachMRTKScripts Instance;

    public bool isAttach = false;

    private void Awake()
    {
        Instance = this;
    }

    [Header("Bounds Control Script Properties")]
    public GameObject BoundsVisualPrefab;
    public double DragToogleThresold = 0.005;

    public void attachMRTK(GameObject selected_Object)
    {
        if (isAttach == false)
        {
            selected_Object.gameObject.AddComponent<ObjectManipulator>();

            selected_Object.gameObject.AddComponent<BoxCollider>();
            selected_Object.gameObject.AddComponent<BoundsControl>();
            selected_Object.gameObject.GetComponent<BoundsControl>().BoundsVisualsPrefab = LL_SceneManager.Instance.BoundingBox;
            selected_Object.gameObject.GetComponent<BoundsControl>().Target = selected_Object.gameObject.transform;
            selected_Object.gameObject.GetComponent<BoundsControl>().DragToggleThreshold = (float)DragToogleThresold;
            selected_Object.gameObject.GetComponent<BoundsControl>().ConstraintsManager = selected_Object.gameObject.GetComponent<ConstraintManager>();
            selected_Object.gameObject.AddComponent<ConstraintManager>();
            selected_Object.gameObject.AddComponent<MinMaxScaleConstraint>();

            isAttach = true;
        }
    }
}
