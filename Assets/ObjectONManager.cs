using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectONManager : MonoBehaviour
{
    public GameObject childObj;
    // Start is called before the first frame update

    public void ToggleCube()
    {
        childObj.SetActive(!childObj.activeSelf);
    }
}
