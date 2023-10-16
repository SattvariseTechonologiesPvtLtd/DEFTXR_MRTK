using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneGameManager : MonoBehaviour
{
    public bool loginscreen, grossanatomyscreen;
    public static ChangeSceneGameManager Instance;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(Instance);

    }

    private void Start()
    {
        loginscreen = true;
        grossanatomyscreen = false;
    }
}

