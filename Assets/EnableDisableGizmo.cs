using UnityEngine;
using MixedReality.Toolkit.SpatialManipulation;

public class EnableDisableGizmo : MonoBehaviour
{
    public static EnableDisableGizmo Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject Target;
    public GameObject BoundingBox;
    public double DragToggleThreshold = 0.005;

    public void Start()
    {

    }

    public void OnGizmoButtonClick()
    {
        /*------------ Object Manipulator Script and Their Properties -------------*/
        Target.AddComponent<ObjectManipulator>().EnableConstraints = true;

        /*----------- Bounds Control Script and Their Properties -----------*/
        var boundsControl = Target.AddComponent<BoundsControl>();
        boundsControl.BoundsVisualsPrefab = BoundingBox;
        boundsControl.HandlesActive = true;
        boundsControl.IncludeInactiveObjects = true;
        boundsControl.OverrideBounds = true;
        boundsControl.FlattenMode = FlattenMode.Never;
        boundsControl.BoundsCalculationMethod = BoundsCalculator.BoundsCalculationMethod.ColliderOnly;
        boundsControl.BoundsOverride = Target.transform;
        boundsControl.Target = Target.transform;
        boundsControl.DragToggleThreshold = (float)DragToggleThreshold;
        boundsControl.ConstraintsManager = Target.GetComponent<ConstraintManager>();
        boundsControl.EnableConstraints = true;

        /*----------- ConstraintManager Script and Their Properties -----------*/
        Target.AddComponent<ConstraintManager>();

        /*----------- MinMaxScaleConstraint Script and Their Properties -----------*/
        var minMaxScaleConstraint = Target.AddComponent<MinMaxScaleConstraint>();
        minMaxScaleConstraint.RelativeToInitialState = false;
        minMaxScaleConstraint.MinimumScale = new Vector3(1, 1, 1);
        minMaxScaleConstraint.MaximumScale = new Vector3(3, 3, 3);
    }
}
