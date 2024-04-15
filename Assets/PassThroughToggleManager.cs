using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughToggleManager : MonoBehaviour
{
    public GameObject PassThroughObj;

    public void OnPassthroughButtonClick()
    {
        if (PassThroughObj.activeSelf)
        {
            PassThroughObj.SetActive(false);
        }
        else
        {
            PassThroughObj.SetActive(true);
        }
    }
}
