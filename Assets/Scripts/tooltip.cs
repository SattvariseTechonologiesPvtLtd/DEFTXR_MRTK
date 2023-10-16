using UnityEngine;
using System.Collections;

public class tooltip : MonoBehaviour
{

    public LineRenderer line;

    public GameObject tootipUI;
   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, tootipUI.transform.position);
    }
}
