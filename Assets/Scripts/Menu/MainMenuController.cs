using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MainMenuController : MonoBehaviourPunCallbacks
{
    public void LoadGame(string input)
    {
        StateNameController.characterName = input;
        PhotonNetwork.LoadLevel("Lobby");
    }
}
