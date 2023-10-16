using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultiSelectDropdown_Manager : MonoBehaviour
{

    public static MultiSelectDropdown_Manager Instance;

    private void Awake()
    {
        Instance = this;
    }


    //get all the selected id's
  
    public List<int> selectedButtonIdList;

    // Use this for initialization
    void Start()
    {
        selectedButtonIdList = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void defaultButtonClick()
    { 
        
    }

    public void onDropDownButtonSelection()
    {
        foreach (int i in selectedButtonIdList)
        {
            Debug.Log("["+i+"] ");
        }
    }

}
