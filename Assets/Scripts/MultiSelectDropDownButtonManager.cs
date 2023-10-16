using UnityEngine;
using System.Collections;

public class MultiSelectDropDownButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject myReferenceObject;

    public void tickMarkToggle()
    {
        myReferenceObject.SetActive(!myReferenceObject.activeSelf);
    }
}
