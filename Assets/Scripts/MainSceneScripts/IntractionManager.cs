using UnityEngine;
using System.Collections;
using OVRTouchSample;

public class IntractionManager : MonoBehaviour
{

    public static IntractionManager Instance;

    public bool isDefaultHandGrabAllow;

    public string selectObjName;
    public bool isNextSelected;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] Hand leftHandRef, rightHandRef;

    // Use this for initialization
    void Start()
    {
        isDefaultHandGrabAllow = false;
        isNextSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        

    }


}
