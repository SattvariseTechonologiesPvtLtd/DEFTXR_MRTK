using UnityEngine;
using Nova;
using System.Collections;
using System;

public class ButtonBGChanger : MonoBehaviour
{
    private Color originalColor;
    public Color targetColor = Color.blue;
    public float changeDuration = 0.2f; // Duration for how long to stay changed

    private void Start()
    {
        // Store the original color of the UIBlock2D component
        originalColor = GetComponent<UIBlock2D>().Color;
    }

    public void OnButtonClick()
    {
        // Change the color immediately
        GetComponent<UIBlock2D>().Color = targetColor;

        // Start a coroutine to revert the color after a short delay
        StartCoroutine(RevertColorAfterDelay());
    }

    private IEnumerator RevertColorAfterDelay()
    {
        // Wait for a short duration
        yield return new WaitForSeconds(changeDuration);

        // Revert to the original color
        GetComponent<UIBlock2D>().Color = originalColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("" + other.gameObject.name);
        if (String.Compare(other.gameObject.name, "TouchPos") == 0)
        {
            // Enable the Outline component
            GetComponent<UIBlock2D>().Border.Enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (String.Compare(other.gameObject.name, "TouchPos") == 0)
        {
            // Disable the Outline component
            GetComponent<UIBlock2D>().Border.Enabled = false;
        }
    }
}
