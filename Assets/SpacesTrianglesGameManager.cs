using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nova;

public class SpacesTrianglesGameManager : MonoBehaviour
{
    public GameObject[] gameObjects; // Array to hold your game objects
    public GameObject[] buttons; // Array to hold your buttons

    private void Start()
    {
        // Ensure the number of game objects and buttons match
        if (gameObjects.Length != buttons.Length)
        {
            Debug.LogError("Number of game objects and buttons do not match!");
            return;
        }

        // Disable all game objects except the first one
        for (int i = 1; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(false);
        }
    }

    public void OnButtonClick(int buttonIndex)
    {
        // Enable the corresponding game object
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(i == buttonIndex);
        }

        // Enable the border of the clicked button and disable borders of others
        for (int i = 0; i < buttons.Length; i++)
        {
            bool isClickedButton = i == buttonIndex;
            buttons[i].GetComponent<UIBlock2D>().Border.Enabled = isClickedButton;
        }
    }
}
