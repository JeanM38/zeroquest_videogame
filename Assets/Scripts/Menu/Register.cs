using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;

    public Button submitBtn;

    public void CallRegister()
    {
        StartCoroutine(RegisterAccount("http://localhost/zeroquest/register.php"));
    }

    IEnumerator RegisterAccount(string uri)
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
            if (webRequest.downloadHandler.text == "0")
            {
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                Debug.Log("User created successfully");
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("User creation failed. Error#" + webRequest.downloadHandler.text);
            }
        }
    }

    public void VerifyInput()
    {
        submitBtn.interactable = (
            usernameInput.text.Length >= 8 &&
            passwordInput.text.Length >= 8
        );
    }
}