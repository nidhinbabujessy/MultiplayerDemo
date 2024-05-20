using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public GameObject lobby;
    public GameObject loading;
    public float delay = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        StartCoroutine(EnableObjectAfterDelay());
    }
    private IEnumerator EnableObjectAfterDelay()
    {
        
        yield return new WaitForSeconds(delay);
        loading.SetActive(false);
       lobby.SetActive(true);

    }
}
