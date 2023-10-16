using UnityEngine;
using UnityEngine.EventSystems;
using Microsoft.MixedReality.Toolkit.Input;

public class ObjectSelector : MonoBehaviour, IMixedRealityPointerHandler
{
    private GameObject currentGameObject;

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData) 
    {
        // Check if the pointer event hit an object
        if (eventData.Pointer.Result?.CurrentPointerTarget != null)
        {
            // Get the GameObject that was hit
            currentGameObject = eventData.Pointer.Result.CurrentPointerTarget.gameObject;

            // You can now perform any operations on the currentGameObject
            // For example, change its color, scale, or call a specific function on it
            Debug.Log("Selected Object: " + currentGameObject.name);
        }
    }
    public void OnPointerDragged(MixedRealityPointerEventData eventData) { }
    public void OnPointerUp(MixedRealityPointerEventData eventData) { }
}
