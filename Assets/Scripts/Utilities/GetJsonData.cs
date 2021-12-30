using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using SimpleJSON;

public class GetJsonData : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetJSON("http://localhost/zeroquest/webtest.php"));
    }

    IEnumerator GetJSON(string uri)
    {
        using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error: " + webRequest.error);
        }
        else
        {
            JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
            Debug.Log(jsonData);
        }
    }
}
