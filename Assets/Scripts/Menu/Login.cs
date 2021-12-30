using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;

    public GameObject noUsernameErrorMessage;
    public GameObject incorrectPasswordErrorMessage;

    public Button submitBtn;
    
    public void CallLogin()
    {
        StartCoroutine(LoginAccount("http://localhost/zeroquest/login.php"));
    }

    IEnumerator LoginAccount(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameInput.text);
        form.AddField("password", passwordInput.text);

        using UnityWebRequest webRequest = UnityWebRequest.Post(uri, form);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error: " + webRequest.error);
        }
        else
        {
            string returnCode = webRequest.downloadHandler.text;
            if (returnCode == "0")
            {
                DBManager.username = usernameInput.text;
                SceneManager.LoadScene(0);
            } else if (returnCode == "5")
            {
                // Username does not exist
                noUsernameErrorMessage.SetActive(true);
            } else if (returnCode == "6")
            {
                // Incorrect password
                incorrectPasswordErrorMessage.SetActive(true);
            }
        }
    }
    public void VerifyInput()
    {
        submitBtn.interactable = (
            usernameInput.text.Length >= 8 &&
            passwordInput.text.Length >= 8
        );
        noUsernameErrorMessage.SetActive(false);
        incorrectPasswordErrorMessage.SetActive(false);
    }
}
