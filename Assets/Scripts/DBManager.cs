using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DBManager : MonoBehaviour
{
    public Text playerDisplay;

    public static string username;
    public static bool LoggedIn { get { return username != null; } }
    
    public static void LoggedOut()
    {
        username = null;
    }

    private void Start()
    {
        if (LoggedIn)
        {
            playerDisplay.text = "Player: " + username;
        }
    }
}
