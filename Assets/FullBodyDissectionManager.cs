using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullBodyDissectionManager : MonoBehaviour
{
    public GameObject DissectionHN, DissectionUL, DissectionLL, DissectionThorax, DissectionAbdomen;

    public GameObject DissectionHNTick, DissectionULTick, DissectionLLTick, DissectionThoraxTick, DissectionAbdomenTick;

    public GameObject TempSkin;
    // Start is called before the first frame update
    void Start()
    {
        FullBodyDissectionHNButtonClick();
        TempSkin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FullBodyDissectionHNButtonClick()
    {
        DissectionHN.SetActive(true);
        DissectionUL.SetActive(false);
        DissectionLL.SetActive(false);
        DissectionThorax.SetActive(false);
        DissectionAbdomen.SetActive(false);

        DissectionHNTick.SetActive(true);
        DissectionULTick.SetActive(false);
        DissectionLLTick.SetActive(false);
        DissectionThoraxTick.SetActive(false);
        DissectionAbdomenTick.SetActive(false);
        TempSkin.SetActive(false);
    }

    public void FullBodyDissectionULButtonClick()
    {
        DissectionHN.SetActive(false);
        DissectionUL.SetActive(true);
        DissectionLL.SetActive(false);
        DissectionThorax.SetActive(false);
        DissectionAbdomen.SetActive(false);

        DissectionHNTick.SetActive(false);
        DissectionULTick.SetActive(true);
        DissectionLLTick.SetActive(false);
        DissectionThoraxTick.SetActive(false);
        DissectionAbdomenTick.SetActive(false);
        TempSkin.SetActive(false);
    }
    public void FullBodyDissectionLLButtonClick()
    {
        DissectionHN.SetActive(false);
        DissectionUL.SetActive(false);
        DissectionLL.SetActive(true);
        DissectionThorax.SetActive(false);
        DissectionAbdomen.SetActive(false);

        DissectionHNTick.SetActive(false);
        DissectionULTick.SetActive(false);
        DissectionLLTick.SetActive(true);
        DissectionThoraxTick.SetActive(false);
        DissectionAbdomenTick.SetActive(false);
        TempSkin.SetActive(false);
    }
    public void FullBodyDissectionThoraxButtonClick()
    {
        DissectionHN.SetActive(false);
        DissectionUL.SetActive(false);
        DissectionLL.SetActive(false);
        DissectionThorax.SetActive(true);
        DissectionAbdomen.SetActive(false);

        DissectionHNTick.SetActive(false);
        DissectionULTick.SetActive(false);
        DissectionLLTick.SetActive(false);
        DissectionThoraxTick.SetActive(true);
        DissectionAbdomenTick.SetActive(false);
        TempSkin.SetActive(false);
    }

    public void FullBodyDissectionAbdomenButtonClick()
    {
        DissectionHN.SetActive(false);
        DissectionUL.SetActive(false);
        DissectionLL.SetActive(false);
        DissectionThorax.SetActive(false);
        DissectionAbdomen.SetActive(true);

        DissectionHNTick.SetActive(false);
        DissectionULTick.SetActive(false);
        DissectionLLTick.SetActive(false);
        DissectionThoraxTick.SetActive(false);
        DissectionAbdomenTick.SetActive(true);
        TempSkin.SetActive(false);
    }
}
