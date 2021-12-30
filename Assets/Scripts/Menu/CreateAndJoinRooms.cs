using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField JoinRoomInput, CreateRoomInput;

    public void createRoom()
    {
        PhotonNetwork.CreateRoom(CreateRoomInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinRoomInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Board");
    }
}
