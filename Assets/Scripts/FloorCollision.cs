using UnityEngine;
using System.Collections;
using System;

public class FloorCollision : MonoBehaviour
{

    public Vector3 myLoc;
    public Quaternion rotation;
    public Vector3 myscale;

    public void Start()
    {

        myLoc = this.transform.position;
        rotation = this.transform.rotation;
        myscale = this.transform.localScale;
    }

    public void OnCollisionEnter(Collision other) {

        if (String.Compare(other.gameObject.name, "floor") == 0)
        {
            Debug.Log(other.gameObject.name);
            this.gameObject.transform.position = myLoc;
            this.gameObject.transform.rotation = rotation;

        }
        else
        {
            this.gameObject.transform.position = myLoc;
            this.gameObject.transform.rotation = rotation;

            DEFTXR_UI_Manager.Instance.selectedBone.GetComponent<Rigidbody>().isKinematic = true;
            DEFTXR_UI_Manager.Instance.selectedBone.GetComponent<BoxCollider>().enabled = true;
            DEFTXR_UI_Manager.Instance.selectedBone.GetComponent<Rigidbody>().useGravity = false;
        }

    }

    public void resetToOrgpos()
    {
        this.gameObject.transform.position = myLoc;
        this.gameObject.transform.rotation = rotation;
    }

   
}
