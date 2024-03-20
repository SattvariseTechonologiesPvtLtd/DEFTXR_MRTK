using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit.SpatialManipulation;

public class AttachMRTK : MonoBehaviour
{
    public static AttachMRTK Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject BoundingBox;
    public double DragToggleThreshold = 0.005;

    public void attachMRTK(GameObject selected_Object)
    {
        /*------------ Object Manipulator Script and Their Properties -------------*/
        selected_Object.AddComponent<ObjectManipulator>().EnableConstraints = true;

        /*----------- Bounds Control Script and Their Properties -----------*/
        var boundsControl = selected_Object.AddComponent<BoundsControl>();
        boundsControl.BoundsVisualsPrefab = BoundingBox;
        boundsControl.HandlesActive = true;
        boundsControl.IncludeInactiveObjects = true;
        boundsControl.OverrideBounds = true;
        boundsControl.FlattenMode = FlattenMode.Never;
        boundsControl.BoundsCalculationMethod = BoundsCalculator.BoundsCalculationMethod.ColliderOnly;
        boundsControl.BoundsOverride = selected_Object.transform;
        boundsControl.Target = selected_Object.transform;
        boundsControl.DragToggleThreshold = (float)DragToggleThreshold;
        boundsControl.ConstraintsManager = selected_Object.GetComponent<ConstraintManager>();
        boundsControl.EnableConstraints = true;

        /*----------- ConstraintManager Script and Their Properties -----------*/
        selected_Object.AddComponent<ConstraintManager>();

        /*----------- MinMaxScaleConstraint Script and Their Properties -----------*/
        var minMaxScaleConstraint = selected_Object.AddComponent<MinMaxScaleConstraint>();
        minMaxScaleConstraint.RelativeToInitialState = false;
        minMaxScaleConstraint.MinimumScale = new Vector3(1, 1, 1);
        minMaxScaleConstraint.MaximumScale = new Vector3(3, 3, 3);

        PreviousCurrentObjects.Instance.AssignObjects(selected_Object);

        Debug.Log("" + selected_Object.name);
    }

    public void attachMRTKToIsolate(GameObject selected_Object)
    {
        /*------------ Object Manipulator Script and Their Properties -------------*/
        selected_Object.AddComponent<ObjectManipulator>().EnableConstraints = true;

        /*----------- Bounds Control Script and Their Properties -----------*/
        var boundsControl = selected_Object.AddComponent<BoundsControl>();
        boundsControl.BoundsVisualsPrefab = BoundingBox;
        boundsControl.HandlesActive = true;
        //boundsControl.IncludeInactiveObjects = true;
       // boundsControl.OverrideBounds = true;
        boundsControl.FlattenMode = FlattenMode.Never;
        boundsControl.BoundsCalculationMethod = BoundsCalculator.BoundsCalculationMethod.ColliderOnly;
        boundsControl.BoundsOverride = selected_Object.transform;
        boundsControl.Target = selected_Object.transform;
        boundsControl.DragToggleThreshold = (float)DragToggleThreshold;
        boundsControl.ConstraintsManager = selected_Object.GetComponent<ConstraintManager>();
        boundsControl.EnableConstraints = true;

        /*----------- ConstraintManager Script and Their Properties -----------*/
        //selected_Object.AddComponent<ConstraintManager>();

        /*----------- MinMaxScaleConstraint Script and Their Properties -----------*/
        //var minMaxScaleConstraint = selected_Object.AddComponent<MinMaxScaleConstraint>();
        //minMaxScaleConstraint.RelativeToInitialState = true;
        //minMaxScaleConstraint.MinimumScale = new Vector3(1, 1, 1);
        //minMaxScaleConstraint.MaximumScale = new Vector3(3, 3, 3);

        Debug.Log("" + selected_Object.name);
    }

    public void detachMRTKFromIsolate(GameObject selected_Object)
    {
        // Remove ObjectManipulator
        ObjectManipulator objectManipulator = selected_Object.GetComponent<ObjectManipulator>();
        if (objectManipulator != null)
        {
            Destroy(objectManipulator);
        }

        // Remove BoundsControl
        BoundsControl boundsControl = selected_Object.GetComponent<BoundsControl>();
        if (boundsControl != null)
        {
            Destroy(boundsControl);
        }

        // Remove ConstraintManager
        ConstraintManager constraintManager = selected_Object.GetComponent<ConstraintManager>();
        if (constraintManager != null)
        {
            Destroy(constraintManager);
        }

        // Remove MinMaxScaleConstraint
        /*MinMaxScaleConstraint minMaxScaleConstraint = selected_Object.GetComponent<MinMaxScaleConstraint>();
        if (minMaxScaleConstraint != null)
        {
            Destroy(minMaxScaleConstraint);
        }*/

        // Additional cleanup if needed

        Debug.Log("Detached MRTK components from: " + selected_Object.name);
    }
}
