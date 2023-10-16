using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myBonesGrabBehavoir : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
         DEFTXR_UI_Manager.Instance.selectedBone = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       

    }

   
}
