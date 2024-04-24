using System;
using UnityEngine;

public class ControllerRaycast : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject cubePrefab;
    public float raycastDistance = 10f;


    void Update()
    {
        Vector3 controllerDirection = transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, controllerDirection, out hit, raycastDistance))
        {
            //Debug.Log("" + hit.transform.gameObject.name);
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

            if (String.Compare(hit.transform.gameObject.name, "TouchPos") == 0)
            {


            }
            else
            {

                cubePrefab.transform.position = hit.point;
              
            }
        }
        else
        {
           lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + controllerDirection * raycastDistance);

          
        }
    }
}
