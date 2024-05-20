using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField create;
    public TMP_InputField join;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(create.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(join.text);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Game");
        print("started");
    }

}
