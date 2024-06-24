using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private Transform transformComponent;
    private bool up = false;

    public float rotateSpeed = 200f;

    // Use this for initialization
    void Start()
    {
        transformComponent = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = rotateSpeed * Time.deltaTime;
        transformComponent.Rotate(Vector3.forward, currentSpeed);
    }
}
