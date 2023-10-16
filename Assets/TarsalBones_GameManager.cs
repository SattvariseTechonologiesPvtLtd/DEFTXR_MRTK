using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TarsalBones_GameManager : MonoBehaviour
{
    public GameObject zoneBObj;
    public GameObject TarsalBonesinsertionObj, TarsalBonesoriginObj, TarsalBonesDefaultObj, TarsalBonesligamentObj;

    public bool attch, inserAttch, ligamentAttach, origAttach = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onInsertionButtonClick()
    {
        if (inserAttch == false)
        {

            TarsalBonesinsertionObj.SetActive(true);
            TarsalBonesoriginObj.SetActive(false);
            TarsalBonesDefaultObj.SetActive(false);
            TarsalBonesligamentObj.SetActive(false);



            inserAttch = true;
        }
        else
        {

            TarsalBonesinsertionObj.SetActive(false);
            TarsalBonesoriginObj.SetActive(false);
            TarsalBonesDefaultObj.SetActive(true);
            TarsalBonesligamentObj.SetActive(false);

            inserAttch = false;
        }
    }

    public void onOriginButtonClick()
    {
        if (origAttach == false)
        {

            TarsalBonesinsertionObj.SetActive(false);
            TarsalBonesoriginObj.SetActive(true);
            TarsalBonesDefaultObj.SetActive(false);
            TarsalBonesligamentObj.SetActive(false);
            origAttach = true;
        }
        else
        {


            TarsalBonesinsertionObj.SetActive(false);
            TarsalBonesoriginObj.SetActive(false);
            TarsalBonesDefaultObj.SetActive(true);
            TarsalBonesligamentObj.SetActive(false);
            origAttach = false;
        }
    }

    public void onLigamentsButtonClick()
    {
        if (ligamentAttach == false)
        {

            TarsalBonesinsertionObj.SetActive(false);
            TarsalBonesoriginObj.SetActive(false);
            TarsalBonesDefaultObj.SetActive(false);
            TarsalBonesligamentObj.SetActive(true);
            ligamentAttach = true;
        }
        else
        {


            TarsalBonesinsertionObj.SetActive(false);
            TarsalBonesoriginObj.SetActive(false);
            TarsalBonesDefaultObj.SetActive(true);
            TarsalBonesligamentObj.SetActive(false);
            ligamentAttach = false;
        }
    }
}
