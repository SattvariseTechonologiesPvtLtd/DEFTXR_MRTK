/***
 * Author: Yunhan Li
 * Any issue please contact yunhn.lee@gmail.com
 ***/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace VRUiKits.Utils
{
    public class LaserPointer : MonoBehaviour
    {
        LineRenderer lr;
        public GameObject pointer;

        #region MonoBehaviour Callbacks
        void Awake()
        {
            lr = GetComponent<LineRenderer>();
        }

        void LateUpdate()
        {
            lr.SetPosition(0, transform.position);
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, out hit))
            {
                if (hit.collider)
                {
                    pointer.SetActive(true);
                    lr.SetPosition(1, hit.point);
                    pointer.transform.position = hit.point;
                }
            }
            else
            {
                lr.SetPosition(1, transform.forward * 5000);
                pointer.SetActive(false);

            }
        }

        void OnDisable()
        {
            if (null != lr)
            {
                // Reset position for smooth transtation when enbale laser pointer
                lr.SetPosition(0, Vector3.zero);
                lr.SetPosition(1, Vector3.zero);
            }
        }
        #endregion
    }
}
