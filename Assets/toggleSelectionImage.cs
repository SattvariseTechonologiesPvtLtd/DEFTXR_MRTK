using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleSelectionImage : MonoBehaviour
{
     bool selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatedSelection(bool value)
    {
       
        if(value == true)
        {
            //this.GetComponent<Image>().sprite = DEFTXR_UI_Manager.Instance.selected;
            Debug.Log(value);
        }
        else
        {
            //this.GetComponent<Image>().sprite = DEFTXR_UI_Manager.Instance.deselected;
            Debug.Log(value);

        }
    }
}
