using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nova;

public class ButtonHover : MonoBehaviour
{
    public void OnButtonHover()
    {
        this.gameObject.GetComponent<ItemView>().enabled = true;
    }
}
