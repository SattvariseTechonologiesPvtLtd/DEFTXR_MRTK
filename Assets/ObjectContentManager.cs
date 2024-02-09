using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContentManager : MonoBehaviour
{
    public GameObject Label;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableObject()
    {
        Label.SetActive(true);
    }
    public void DisableObject()
    {
        Label.SetActive(false);
    }
}
