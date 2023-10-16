using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalButtonTrigger : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;
    [SerializeField] private GameObject clicker;
    [SerializeField] private Material selected,deselected;

    private bool _isPressed;
    private bool isSelected;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public AudioSource audioSource;
    public AudioClip buttonClick;

    public UnityEvent onPressed, onReleased;

    private void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        isSelected = false;
    }

    private void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
        {
            buttonPressed();
        }

        if (_isPressed && GetValue() - threshold <= 0)
        {
            buttonReleased();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1, 1);
    }

    private void buttonPressed()
    {
        _isPressed = true;
        select_deselect();
        audioSource.PlayOneShot(buttonClick);
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void buttonReleased()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");

    }

    private void select_deselect()
    {
        if (isSelected == false)
        {
            isSelected = true;
            clicker.GetComponent<Renderer>().material = selected;

        }
        else {
            isSelected = false;
            clicker.GetComponent<Renderer>().material = deselected;
        }
    }
}
