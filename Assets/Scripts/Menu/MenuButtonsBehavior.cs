using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsBehavior : MonoBehaviour
{
    public void GoToRegister()
    {
        SceneManager.LoadScene("Register");
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene("Login");
    }
}
