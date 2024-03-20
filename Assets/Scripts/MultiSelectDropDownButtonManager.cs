using UnityEngine;
using System.Collections;
using Nova;
using NovaSamples;

public class MultiSelectDropDownButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject myReferenceObject;

    public void tickMarkToggle()
    {
        myReferenceObject.SetActive(!myReferenceObject.activeSelf);

        this.gameObject.GetComponent<UIBlock2D>().Border.Enabled = myReferenceObject.activeSelf;
    }
}
