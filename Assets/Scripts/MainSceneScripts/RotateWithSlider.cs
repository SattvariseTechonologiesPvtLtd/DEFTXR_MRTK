using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotateWithSlider : MonoBehaviour
{
    // Assign in the inspector
    public GameObject objectToRotate;
    public Slider slider;

    // Preserve the original and current orientation
    private float previousValue;
    int xRot;

    void Awake()
    {
        // Assign a callback for when this slider changes
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);

        Debug.Log("How manyh time");
        // And current value
        this.slider.value = this.previousValue;
    }

    void OnSliderChanged(float value)
    {
        // How much we've changed
        float delta = value - this.previousValue;
        // this.objectToRotate.transform.Rotate(Vector3.right * delta * 360f);

      
        xRot = (int)Mathf.Repeat(xRot * delta * 360f, 360);

        this.objectToRotate.transform.rotation = Quaternion.AngleAxis(xRot, transform.right);

        // Set our previous value for the next change
        this.previousValue = value;

        Debug.Log("times ,anuuu");

    }
}
