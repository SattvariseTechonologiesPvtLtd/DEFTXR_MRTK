using UnityEngine;
using UnityEditor;
using MixedReality.Toolkit.SpatialManipulation;
using MixedReality.Toolkit.UX;

public class AttachScriptsEditor : EditorWindow
{
    private GameObject[] selectedObjects;
    private GameObject boundsVisualsPrefab; // The reference to the prefab asset

    [MenuItem("Custom/Attach Scripts and Set Bounds Visuals Prefab")]
    static void Init()
    {
        AttachScriptsEditor window = (AttachScriptsEditor)EditorWindow.GetWindow(typeof(AttachScriptsEditor));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Select scripts to attach:");

        boundsVisualsPrefab = EditorGUILayout.ObjectField("Bounds Visuals Prefab", boundsVisualsPrefab, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Attach Scripts and Set Bounds Visuals Prefab"))
        {
            selectedObjects = Selection.gameObjects;

            foreach (GameObject obj in selectedObjects)
            {
                // Remove Rigidbody component if present
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    DestroyImmediate(rb);
                }

                // Remove BoxCollider component if present
                BoxCollider boxCollider = obj.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    DestroyImmediate(boxCollider);
                }

                // Untick Convex property of MeshCollider if present
                MeshCollider meshCollider = obj.GetComponent<MeshCollider>();
                if (meshCollider != null)
                {
                    SerializedObject meshColliderSerialized = new SerializedObject(meshCollider);
                    SerializedProperty convexProperty = meshColliderSerialized.FindProperty("m_Convex");
                    if (convexProperty != null)
                    {
                        convexProperty.boolValue = false;
                    }

                    SerializedProperty isTriggerProperty = meshColliderSerialized.FindProperty("m_IsTrigger");
                    if (isTriggerProperty != null)
                    {
                        isTriggerProperty.boolValue = false;
                    }

                    meshColliderSerialized.ApplyModifiedPropertiesWithoutUndo();
                }

                // Attach desired scripts
                obj.AddComponent<ObjectManipulator>();
                obj.AddComponent<BoundsControl>();
                obj.AddComponent<MinMaxScaleConstraint>();
                obj.AddComponent<UGUIInputAdapterDraggable>();

                // Access components and set properties
                var objectManipulator = obj.GetComponent<ObjectManipulator>();
                if (objectManipulator != null)
                {
                    objectManipulator.EnableConstraints = true;
                }

                var boundsControl = obj.GetComponent<BoundsControl>();
                if (boundsControl != null)
                {
                    boundsControl.Interactable = obj.GetComponent<ObjectManipulator>();
                    boundsControl.Target = obj.transform;
                    boundsControl.ConstraintsManager = obj.GetComponent<ConstraintManager>();

                    // Set the BoundsVisualsPrefab property via serialized object
                    SerializedObject boundsControlSerialized = new SerializedObject(boundsControl);
                    boundsControlSerialized.FindProperty("boundsVisualsPrefab").objectReferenceValue = boundsVisualsPrefab;
                    boundsControlSerialized.ApplyModifiedPropertiesWithoutUndo();
                }

                var minMaxScaleConstraint = obj.GetComponent<MinMaxScaleConstraint>();
                if (minMaxScaleConstraint != null)
                {
                    minMaxScaleConstraint.MinimumScale = new Vector3(1, 1, 1);
                    minMaxScaleConstraint.MaximumScale = new Vector3(3, 3, 3);
                }
            }

            Debug.Log("Scripts attached, Bounds Visuals Prefab set, Rigidbody and BoxCollider components removed, MeshCollider convex and isTrigger properties unticked from selected objects!");
        }
    }
}
