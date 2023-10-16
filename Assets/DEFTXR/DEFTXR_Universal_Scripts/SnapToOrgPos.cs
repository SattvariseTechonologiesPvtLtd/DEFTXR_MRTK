using UnityEngine;
using System.Collections;

 public class SnapToOrgPos : MonoBehaviour
    {

        Vector3 startPos;
        Quaternion rotation;
        // Use this for initialization
        void Start()
        {
            startPos = this.transform.position;
            rotation = this.transform.rotation;
           
        }

        // Update is called once per frame
        void Update()
        {

            if (this.GetComponent<OVRGrabbable>().isGrabbed == false)
            {
                transform.position = Vector3.Lerp(this.transform.position, startPos, 0.5f);
                transform.rotation = rotation;
            }

        }
    }