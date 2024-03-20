using System;
using UnityEngine;
using MixedReality.Toolkit.SpatialManipulation;

public class PreviousCurrentObjects : MonoBehaviour
{
    public static PreviousCurrentObjects Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject currentSelectedObject;
    public GameObject previousSelectedObject;

    public void AssignObjects(GameObject currentObj)
    {
        if(currentSelectedObject != null)
        {
            if (String.Compare(currentObj.gameObject.name, currentSelectedObject.name) == 0)
            {
                //Debug.Log("duplicate objs");
                EnableHandles(currentSelectedObject);
            }
            else
            {
                previousSelectedObject = currentSelectedObject;
                DisableHandles(previousSelectedObject);
                currentSelectedObject = currentObj;
                EnableHandles(currentSelectedObject);

                //Debug.Log(" " + currentSelectedObject.name + "  p:  " + previousSelectedObject.name);
            }
        }
        else
        {
            currentSelectedObject = currentObj;
            EnableHandles(currentSelectedObject);
        }
    }

    private void EnableHandles(GameObject obj)
    {
        if(obj.GetComponent<BoundsControl>() != null)
        {
            obj.GetComponent<BoundsControl>().HandlesActive = true;
        }
        
    }

    private void DisableHandles(GameObject obj)
    {
        if (obj.GetComponent<BoundsControl>() != null)
        {
            obj.GetComponent<BoundsControl>().HandlesActive = false;
        }
    }

    public void clearObjData()
    {
        if (currentSelectedObject != null)
        {
            DisableHandles(currentSelectedObject);
        }
        if (previousSelectedObject != null)
        {
            DisableHandles(previousSelectedObject);
        }

        currentSelectedObject = null;
        previousSelectedObject = null;
    }
}
