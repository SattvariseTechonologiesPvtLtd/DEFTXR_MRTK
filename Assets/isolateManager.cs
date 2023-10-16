using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isolateManager : MonoBehaviour
{

    [SerializeField]
    public GameObject MainObject, isolateObject,isolatebutton, isolatePressed, InsertionObject, isolateBarMenu, InsertionPanel,insertionbutton, insertionPressed;

    // Start is called before the first frame update
    void Start()
    {
        isolateObject.SetActive(false);
        InsertionObject.SetActive(false);
        isolateBarMenu.SetActive(false);
        InsertionPanel.SetActive(false);
        insertionPressed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onFeaturesButtonClick()
    {
        isolateObject.SetActive(false);
        InsertionObject.SetActive(true);
        InsertionPanel.SetActive(true);
        insertionPressed.SetActive(true);
        insertionbutton.SetActive(false);
    }
    public void onIsolateButtonClick()
    {
        MainObject.SetActive(false);
        isolateBarMenu.SetActive(true);
        isolateObject.SetActive(true);
        isolatebutton.SetActive(false);
        isolatePressed.SetActive(true);
    }
}
