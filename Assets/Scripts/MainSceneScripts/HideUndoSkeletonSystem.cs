using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HideUndoSkeletonSystem : MonoBehaviour
{
    List<GameObject> parts;
    public GameObject menuPanel;

    int index;
    private float horizontal_prevValue, verticle_prevValue;

    // Use this for initialization
    void Start()
    {
        parts = new List<GameObject>();


        index = -1;
        //DEFTXR_UI_Manager.Instance.setDisection();

        //slider init

    }



    // Update is called once per frame
    void Update()
    {
        // Debug.Log("" + speedSlider.value*100);
    }





    public void hideButtonClick()
    {

        parts.Add(DEFTXR_UI_Manager.Instance.currentSelectObject);
        index++;
        DEFTXR_UI_Manager.Instance.currentSelectObject.SetActive(false);
        //DEFTXR_UI_Manager.Instance.undoButton.SetActive(true);

    }
    public void undoButtonClick()
    {
        if (index >= 0)
        {
            DEFTXR_UI_Manager.Instance.currentSelectObject = parts[index];
            DEFTXR_UI_Manager.Instance.currentSelectObject.SetActive(true);
            parts.RemoveAt(index);
            index--;
        }
        else
        {
            //DEFTXR_UI_Manager.Instance.undoButton.SetActive(false);
        }


    }
}
