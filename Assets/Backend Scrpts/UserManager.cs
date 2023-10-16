
/// <summary>
/// DEFTXR product : Backend Script for user managment
/// This script will contain the Login flow of the user who will logged into the DEFTXR product.
/// Created By : Ayodhyanandan Bhosale.
/// </summary>


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// Class declaration for User Manager
/// </summary>
public class UserManager : MonoBehaviour
{
    //User input data referance variables
    private string userEmail, userPassword;

    //backend server URL
    public string serverURL;

    //field names to send via form
    public InputField emailInput, passwordInput;


    void Start()
    {
        StartCoroutine(Upload());
    }

    /// <summary>
    /// Login button click flow starts here
    /// TextField data has been taken from User Input
    /// Check Email validation
    /// Check Password validation
    /// </summary>
    public void login_Btn_click()
    {
        userEmail = emailInput.text;
        userPassword = passwordInput.text;
    }


    IEnumerator Upload()
    {
        Debug.Log("start");

        WWWForm form = new WWWForm();
        form.AddField("email", "ayodhyanandan@gmail.com");
        form.AddField("password", "R@D8jqz9");
        form.headers.Add("Accept", "application/json");

        Debug.Log(""+form.data.ToString());
        UnityWebRequest www = UnityWebRequest.Post("https://creintechs.sg-host.com/public/api/login", form);
        Debug.Log(www.ToString());
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
