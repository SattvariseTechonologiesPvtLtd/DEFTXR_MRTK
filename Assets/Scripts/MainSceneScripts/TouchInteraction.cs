using UnityEngine;
using System.Collections;

public class TouchInteraction : MonoBehaviour
{

    public GameObject tracker;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = tracker.transform.position;

        this.gameObject.transform.rotation = tracker.transform.rotation;
    }
}
